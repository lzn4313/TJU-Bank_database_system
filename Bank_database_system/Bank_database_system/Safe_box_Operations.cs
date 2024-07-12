using Oracle.ManagedDataAccess.Client;  // 引入 Oracle 数据库访问的命名空间
using System;  // 引入基础类库命名空间
using System.Data;  // 引入数据处理的命名空间

namespace Bank_database_system  // 定义命名空间 Bank_database_system
{
    public class Safe_Box_Operations  // 定义类 Safe_Box_Operations
    {
        // 定义数据库连接字符串作为常量
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

        // 查询并返回所有保险箱数据的方法
        public static DataTable QueryAndReturnSafeBoxData()
        {
            DataTable safeBoxTable = new DataTable();

            // 使用 OracleConnection 对象建立数据库连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 定义 SQL 查询语句
                    string query = "SELECT SAFE_BOX_ID, BRANCH_ID, BOX_SIZE, STATE FROM SAFE_BOX";

                    // 使用 OracleCommand 对象执行 SQL 查询
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 使用 OracleDataAdapter 填充数据表
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(safeBoxTable);  // 填充数据表
                        }
                    }
                }
                catch (Exception ex)  // 捕获并处理可能发生的异常
                {
                    // 输出错误信息到控制台
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return safeBoxTable;
        }

        // 查询并返回特定保险箱数据的方法
        public static DataTable SelectSafeBox(string safeBoxId)
        {
            DataTable safeBoxTable = new DataTable();

            // 使用 OracleConnection 对象建立数据库连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 定义 SQL 查询语句
                    string query = "SELECT SAFE_BOX_ID, BRANCH_ID, BOX_SIZE, BOX_CASH_PLEDGE, RENTAL_AMOUNT, STATE FROM SAFE_BOX WHERE SAFE_BOX_ID = :safeBoxId";

                    // 使用 OracleCommand 对象执行 SQL 查询
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 添加参数并设置其值
                        command.Parameters.Add(new OracleParameter(":safeBoxId", safeBoxId));

                        // 使用 OracleDataAdapter 填充数据表
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(safeBoxTable);  // 填充数据表
                        }
                    }
                }
                catch (Exception ex)  // 捕获并处理可能发生的异常
                {
                    // 输出错误信息到控制台
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return safeBoxTable;
        }

        // 调用 HIRE_SAFE_BOX SQL 函数的方法
        public static string HireSafeBox(
            string hireCreditCardNumbers,
            string safeBoxHireId,
            int hireDuration,
            decimal boxCashPledge,
            decimal hireRentalAmount,
            string hireStaffId,
            string ip)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 定义 OracleCommand 对象
                    using (OracleCommand command = new OracleCommand("HIRE_SAFE_BOX", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 添加输入参数
                        command.Parameters.Add("HIRE_CREDIT_CARD_NUMBERS", OracleDbType.Varchar2).Value = hireCreditCardNumbers;
                        command.Parameters.Add("SAFE_BOX_HIRE_ID", OracleDbType.Varchar2).Value = safeBoxHireId;
                        command.Parameters.Add("HIRE_DURATION", OracleDbType.Int32).Value = hireDuration;
                        command.Parameters.Add("BOX_CASH_PLEDGE", OracleDbType.Decimal).Value = boxCashPledge;
                        command.Parameters.Add("HIRE_RENTAL_AMOUNT", OracleDbType.Decimal).Value = hireRentalAmount;
                        command.Parameters.Add("HIRE_STAFF_ID", OracleDbType.Varchar2).Value = hireStaffId;
                        command.Parameters.Add("IP", OracleDbType.Varchar2).Value = ip;

                        // 添加输出参数
                        command.Parameters.Add("RESULT", OracleDbType.Varchar2, 100).Direction = ParameterDirection.ReturnValue;

                        // 执行存储过程
                        command.ExecuteNonQuery();

                        // 获取返回值
                        return command.Parameters["RESULT"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // 输出错误信息到控制台
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return "An error occurred: " + ex.Message;
                }
            }
        }

        // 调用 PasswordCheck 函数的方法
        public static int PasswordCheck(
            string password,
            string hireCreditCardNumbers,
            string safeBoxHireId,
            int hireDuration,
            decimal boxCashPledge,
            decimal hireRentalAmount,
            string hireStaffId,
            string ip)
        {
            // 从 ACCOUNT 表中查找 hireCreditCardNumbers 对应的密码
            string storedPassword = GetPasswordByCreditCardNumber(hireCreditCardNumbers);

            // 如果找不到密码，直接返回 0
            if (string.IsNullOrEmpty(storedPassword))
            {
                return 0;
            }

            // 调用 PasswordHandler 的 VerifyPassword 方法进行密码验证
            if (PasswordHandler.VerifyPassword(password, storedPassword))
            {
                // 如果密码验证通过，调用 HireSafeBox 方法
                HireSafeBox(hireCreditCardNumbers, safeBoxHireId, hireDuration, boxCashPledge, hireRentalAmount, hireStaffId, ip);
                return 1;
            }
            else
            {
                // 如果密码验证不通过，直接返回 0
                return 0;
            }
        }

        // 从 ACCOUNT 表中查找 hireCreditCardNumbers 对应的密码
        private static string GetPasswordByCreditCardNumber(string hireCreditCardNumbers)
        {
            string password = null;

            // 使用 OracleConnection 对象建立数据库连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 定义 SQL 查询语句
                    string query = "SELECT PASSWORD FROM ACCOUNT WHERE CREDIT_CARD_NUMBER = :creditCardNumber";

                    // 使用 OracleCommand 对象执行 SQL 查询
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 添加参数并设置其值
                        command.Parameters.Add(new OracleParameter(":creditCardNumber", hireCreditCardNumbers));

                        // 执行查询并获取结果
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 获取查询结果中的密码
                                password = reader["PASSWORD"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)  // 捕获并处理可能发生的异常
                {
                    // 输出错误信息到控制台
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return password;
        }
    }
}
