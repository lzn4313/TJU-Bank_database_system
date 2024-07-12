using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Bank_database_system
{
    public static class LoanOperations
    {
        public const string connectionString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        // 贷款办理
        public static bool LoanProcessing(string loanId, string cardID, double amount, double interestRate, int year)
        {
            // 创建连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 插入贷款
                    string insertQuery = "INSERT INTO LOAN (LOAN_ID, CREDIT_CARD_NUMBERS, AMOUNT, REPAYMENT_BALANCE, INTEREST_RATE, BEGIN_TIME, END_TIME, STATE) " +
                                 "VALUES (:loanId, :cardID, :amount, :repaymentBalance, :interestRate, :beginTime, :endTime, :state)";

                    // 创建命令对象
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 设置参数
                        command.Parameters.Add(new OracleParameter("loanId", OracleDbType.Varchar2, 20)).Value = loanId;
                        command.Parameters.Add(new OracleParameter("creditCardNumber", OracleDbType.Varchar2, 20)).Value = cardID;
                        command.Parameters.Add(new OracleParameter("amount", OracleDbType.Decimal)).Value = amount;  // 贷款金额
                        command.Parameters.Add(new OracleParameter("repaymentBalance", OracleDbType.Decimal)).Value = amount;  // 还款剩余金额
                        command.Parameters.Add(new OracleParameter("interestRate", OracleDbType.Decimal)).Value = interestRate;  // 利率
                        command.Parameters.Add(new OracleParameter("beginTime", OracleDbType.Date)).Value = DateTime.Today;  // 开始时间
                        command.Parameters.Add(new OracleParameter("endTime", OracleDbType.Date)).Value = DateTime.Today.AddYears(year);  // 结束时间
                        command.Parameters.Add(new OracleParameter("state", OracleDbType.Varchar2, 20)).Value = "还款中";  // 状态

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


        // 贷款查询
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

    }

}
