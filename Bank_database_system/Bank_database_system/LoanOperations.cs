using Oracle.ManagedDataAccess.Client;
using System.Data;
using static AccountOperations.BankAccountGenerator;
using static LoanCalculator.LoanCalculator;

namespace Bank_database_system
{
    public static class LoanOperations
    {
        public const string connectionString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        public static DataTable debug()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = @"
select * from DBA_SCHEDULER_JOBS
where JOB_NAME = 'PROCESS_REPAYMENTS_JOB'
";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }

        private static void CreateScheduleProgram()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = @"
BEGIN
   DBMS_SCHEDULER.create_job (
      job_name        => 'PROCESS_REPAYMENTS_JOB',
      job_type        => 'PLSQL_BLOCK',
      job_action      => 'BEGIN DEDUCTION; END;',
      start_date      => TO_TIMESTAMP('2024-09-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'),
      repeat_interval => 'FREQ=MONTHLY; BYMONTHDAY=1; BYHOUR=12; BYMINUTE=0; BYSECOND=0',
      enabled         => TRUE
   );
END;";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteScheduleProgram()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = @"
BEGIN
   DBMS_SCHEDULER.drop_job(
      job_name => 'PROCESS_REPAYMENTS_JOB'
   );
END;";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool LoanProcessing(string cardID, decimal amount, int year, RepaymentType type)
        {
            string loanID = LoanIDGenerator.GenerateUniqueLoanID();
            return LoanProcessing(loanID, cardID, amount, year, type);
        }

        // 贷款办理
        private static bool LoanProcessing(string loanID, string cardID, decimal amount, int year, RepaymentType type)
        {
            decimal sum = GetSumPrincipleInterest(amount, year, type);
            // 创建连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    decimal interestRate = GetInterestRate(amount, year);
                    connection.Open();

                    // 插入贷款
                    string insertQuery = "INSERT INTO LOAN (LOAN_ID, CREDIT_CARD_NUMBERS, AMOUNT, REPAYMENT_BALANCE, INTEREST_RATE, BEGIN_TIME, END_TIME, STATE, IS_EQUAL_PRINCIPLE) " +
                                 "VALUES (:loanId, :cardID, :amount, :repaymentBalance, :interestRate, :beginTime, :endTime, :state, :isPrinciple)";

                    // 创建命令对象
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 设置参数
                        command.Parameters.Add(new OracleParameter("loanId", OracleDbType.Varchar2, 20)).Value = loanID;
                        command.Parameters.Add(new OracleParameter("creditCardNumber", OracleDbType.Varchar2, 20)).Value = cardID;
                        command.Parameters.Add(new OracleParameter("amount", OracleDbType.Decimal)).Value = amount;  // 贷款金额
                        command.Parameters.Add(new OracleParameter("repaymentBalance", OracleDbType.Decimal)).Value = sum;  // 还款剩余金额
                        command.Parameters.Add(new OracleParameter("interestRate", OracleDbType.Decimal)).Value = interestRate;  // 利率
                        DateTime now = DateTime.Now;
                        DateTime nextMonth = new DateTime(now.Year, now.Month, 1).AddMonths(year * 12);
                        DateTime adjustedDate = new DateTime(nextMonth.Year, nextMonth.Month, 1, 12, 0, 0);
                        command.Parameters.Add(new OracleParameter("beginTime", OracleDbType.Date)).Value = now;  // 开始时间
                        command.Parameters.Add(new OracleParameter("endTime", OracleDbType.Date)).Value = adjustedDate;  // 结束时间
                        command.Parameters.Add(new OracleParameter("state", OracleDbType.Varchar2, 20)).Value = "还款中";  // 状态
                        if (type == RepaymentType.EqualPrincipal)
                        {
                            command.Parameters.Add(new OracleParameter("isPrinciple", OracleDbType.Varchar2, 1)).Value = 1;
                        }
                        else
                        {
                            command.Parameters.Add(new OracleParameter("isPrinciple", OracleDbType.Varchar2, 1)).Value = 0;
                        }

                        // 执行插入操作
                        if (command.ExecuteNonQuery() > 0 && CreateLoanRepayment(loanID, cardID, amount, year, type))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (OracleException ex)
                {
                    // 处理 Oracle 数据库相关异常
                    MessageBox.Show($"数据库操作失败：{ex.Message}", "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    // 处理其他类型的异常
                    MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // 计算对应的剩余还款总和
        private static decimal GetSumPrincipleInterest(decimal amount, int year, RepaymentType type)
        {
            decimal[] repayments = CalculateMonthlyRepayment(amount, year, type);
            decimal sum = 0;
            for (int i = 0; i < repayments.Length; i++)
            {
                sum += repayments[i];
            }
            return sum;
        }

        // 查找当前利率
        public static decimal GetInterestRate(decimal amount, int year)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT INTEREST_RATE 
                FROM LOAN_INTEREST_RATE 
                WHERE :principal BETWEEN LOAN_AMOUNT_MIN AND LOAN_AMOUNT_MAX
                  AND :years BETWEEN LOAN_YEARS_MIN AND LOAN_YEARS_MAX";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("principal", amount));
                        command.Parameters.Add(new OracleParameter("years", year));

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            decimal interestRate = Convert.ToDecimal(result);
                            return interestRate;
                        }
                        else
                        {
                            throw new Exception("未找到合适的利率");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return new decimal(0);
            }
        }

        // 创建每条贷款对应的多条还款任务
        private static bool CreateLoanRepayment(string loanID, string cardID, decimal principal, int year, RepaymentType type)
        {
            decimal[] repayments = CalculateMonthlyRepayment(principal, year, type);
            int taskID = GetBiggestTaskID() + repayments.Length;
            for (int i = 0; i < repayments.Length; i++)
            {
                DateTime now = DateTime.Now;
                DateTime firstDayOfNextMonth = new DateTime(now.Year, now.Month, 1).AddMonths(i + 1);
                DateTime adjustedDate = new DateTime(firstDayOfNextMonth.Year, firstDayOfNextMonth.Month, 1, 12, 0, 0);
                if (!CreateSingleRepaymentstring(taskID, repayments[i], adjustedDate, loanID, cardID))
                {
                    return false;
                }
                taskID--;
            }
            return true;
        }

        // 创建每条贷款对应的单条还款任务
        public static bool CreateSingleRepaymentstring(int taskID, decimal repayment, DateTime adjustedDate, string loanID, string cardID)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // 插入还款任务
                    string insertQuery = "INSERT INTO REPAYMENT_TASKS (TASK_ID, CARD_ID, AMOUNT, DUE_DATE, LOAN_ID) " +
                        "VALUES (:taskID, :cardID, :amount, :adjustedDate, :loanID)";

                    // 创建命令对象
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 设置参数
                        command.Parameters.Add(new OracleParameter("taskID", OracleDbType.Varchar2, 20)).Value = taskID;
                        command.Parameters.Add(new OracleParameter("cardID", OracleDbType.Varchar2, 20)).Value = cardID;
                        decimal value = Math.Round(repayment, 2);
                        command.Parameters.Add(new OracleParameter("amount", OracleDbType.Decimal)).Value = value;  // 每月还款金额
                        command.Parameters.Add(new OracleParameter("adjustedDate", OracleDbType.Date)).Value = adjustedDate;
                        command.Parameters.Add(new OracleParameter("loanId", OracleDbType.Varchar2, 20)).Value = loanID;

                        // 执行插入操作
                        if (command.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (OracleException ex)
                {
                    // 处理 Oracle 数据库相关异常
                    MessageBox.Show($"数据库操作失败：{ex.Message}", "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    // 处理其他类型的异常
                    MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private static int GetBiggestTaskID()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // 获取贷款利率
                    string query = @"
                select MAX(TASK_ID) from REPAYMENT_TASKS";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            int taskID = Convert.ToInt32(result);
                            return taskID;
                        }
                        else
                        {
                            throw new Exception("");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        // 使用银行卡号进行贷款查询
        public static DataTable GetLoansByCardNumber(string cardNumber, int pageNumber, int pageSize)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    int offset = (pageNumber - 1) * pageSize;

                    string query = @"
                SELECT *
                FROM (
                    SELECT a.*, ROWNUM rnum
                    FROM (
                        SELECT LOAN_ID, CREDIT_CARD_NUMBERS, AMOUNT, REPAYMENT_BALANCE, INTEREST_RATE, BEGIN_TIME, END_TIME, STATE
                        FROM LOAN
                        WHERE CREDIT_CARD_NUMBERS = :cardNumber
                        ORDER BY LOAN_ID
                    ) a
                    WHERE ROWNUM <= :maxRow
                )
                WHERE rnum > :minRow";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("cardNumber", cardNumber));
                        command.Parameters.Add(new OracleParameter("maxRow", offset + pageSize));
                        command.Parameters.Add(new OracleParameter("minRow", offset));

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return new DataTable(); // 出错返回空表
            }
        }

        // 使用贷款号进行贷款查询
        public static DataTable GetLoansByLoanID(string loanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    // 数据库操作
                    string selectQuery = "SELECT * FROM LOAN WHERE LOAN_ID = :loanID";
                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                        OracleParameter param = new OracleParameter(":loanID", OracleDbType.Varchar2);
                        param.Value = loanID; // 替换成实际的银行卡号
                        command.Parameters.Add(param);

                        // 执行查询
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader); // 将查询结果加载到 DataTable
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return new DataTable(); // 出错返回空表
            }
        }
    }

    public static class LoanIDGenerator
    {
        private static Random random = new Random();

        public static string GenerateUniqueLoanID()
        {
            string loanID;
            do
            {
                loanID = GenerateRandom20ID();
            } while (LoanOperations.GetLoansByLoanID(loanID).Rows.Count > 0);

            return loanID;
        }
    }

}
