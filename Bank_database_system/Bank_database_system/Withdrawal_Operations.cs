using Oracle.ManagedDataAccess.Client;  // 引入 Oracle 数据库访问的命名空间
using System;  // 引入基础类库命名空间
using System.Data;  // 引入数据处理的命名空间

namespace Bank_database_system  // 定义命名空间 Bank_database_system
{
    public class Withdrawal_Operations  // 定义类 Withdrawal_Operations
    {
        // 定义数据库连接字符串作为常量
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

        // 定义 Withdrawal 方法
        /*public static string Withdrawal()
            
        {
            
        }*/

        // 定义 PasswordCheck 函数
        public static string PasswordCheck(
            string password,
            string withdrawalCreditCardNumbers,
            string withdrawalCurrencyKind,
            decimal withdrawalAmount,
            string withdrawalBranchId,
            string withdrawalStaffId,
            string ip)
        {
            // 首先验证密码
            if (PasswordCheck(password, withdrawalCreditCardNumbers) == 1)
            {
                string result = string.Empty;

                // 使用 OracleConnection 对象建立数据库连接
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        // 打开数据库连接
                        connection.Open();

                        // 定义 OracleCommand 对象并设置其属性
                        using (OracleCommand command = new OracleCommand("WITHDRAWAL", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // 添加输入参数
                            command.Parameters.Add("WITHDRAWAL_CURRENCY_KIND", OracleDbType.Varchar2).Value = withdrawalCurrencyKind;
                            command.Parameters.Add("WITHDRAWAL_CREDIT_CARD_NUMBERS", OracleDbType.Varchar2).Value = withdrawalCreditCardNumbers;
                            command.Parameters.Add("WITHDRAWAL_AMOUNT", OracleDbType.Decimal).Value = withdrawalAmount;
                            command.Parameters.Add("WITHDRAWAL_BRANCH_ID", OracleDbType.Varchar2).Value = withdrawalBranchId;
                            command.Parameters.Add("IP", OracleDbType.Varchar2).Value = ip;
                            command.Parameters.Add("WITHDRAWAL_STAFF_ID", OracleDbType.Varchar2).Value = withdrawalStaffId;

                            // 添加返回值参数
                            command.Parameters.Add("RETURN_VALUE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.ReturnValue;

                            // 执行存储过程
                            command.ExecuteNonQuery();

                            // 获取返回值
                            result = command.Parameters["RETURN_VALUE"].Value.ToString();
                        }
                    }
                    catch (OracleException ex)
                    {
                        // 处理数据库异常
                        Console.WriteLine("OracleException: " + ex.Message);
                        result = "取款失败";
                    }
                    catch (Exception ex)
                    {
                        // 处理其他异常
                        Console.WriteLine("Exception: " + ex.Message);
                        result = "取款失败";
                    }
                }

                return result;
            }
            else
            {
                return "密码验证失败";
            }
        }

        // 定义 PasswordCheck 函数
        public static int PasswordCheck(string password, string creditCardNumber)
        {
            // 从 ACCOUNT 表中查找 creditCardNumber 对应的密码
            string storedPassword = GetPasswordByCreditCardNumber(creditCardNumber);

            // 如果找不到密码，直接返回 0
            if (string.IsNullOrEmpty(storedPassword))
            {
                return 0;
            }

            // 调用 PasswordHandler 的 VerifyPassword 方法进行密码验证
            return PasswordHandler.VerifyPassword(password, storedPassword) ? 1 : 0;
        }

        // 从 ACCOUNT 表中查找 creditCardNumber 对应的密码
        private static string GetPasswordByCreditCardNumber(string creditCardNumber)
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
                        command.Parameters.Add(new OracleParameter(":creditCardNumber", creditCardNumber));

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
