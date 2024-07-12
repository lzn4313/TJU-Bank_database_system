using Oracle.ManagedDataAccess.Client;  // 引入 Oracle 数据库访问的命名空间
using System;  // 引入基础类库命名空间
using System.Data;  // 引入数据处理的命名空间

namespace Bank_database_system  // 定义命名空间 Bank_database_system
{
    public class Deposit_Operations  // 定义类 Deposit_Operations
    {
        // 定义数据库连接字符串作为常量
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

        // 定义 Deposit 方法
        public static string Deposit(
            string depositCurrencyKind,
            string depositCreditCardNumbers,
            decimal depositAmount,
            string depositBranchId,
            string ip,
            string depositStaffId)
        {
            string result = null;

            // 使用 OracleConnection 对象建立数据库连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 定义调用存储函数的 SQL 语句
                    string functionCall = "DEPOSIT";

                    // 使用 OracleCommand 对象调用存储函数
                    using (OracleCommand command = new OracleCommand(functionCall, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 添加参数并设置其值
                        command.Parameters.Add("DEPOSIT_CURRENCY_KIND", OracleDbType.Varchar2).Value = depositCurrencyKind;
                        command.Parameters.Add("DEPOSIT_CREDIT_CARD_NUMBERS", OracleDbType.Varchar2).Value = depositCreditCardNumbers;
                        command.Parameters.Add("DEPOSIT_AMOUNT", OracleDbType.Decimal).Value = depositAmount;
                        command.Parameters.Add("DEPOSIT_BRANCH_ID", OracleDbType.Varchar2).Value = depositBranchId;
                        command.Parameters.Add("IP", OracleDbType.Varchar2).Value = ip;
                        command.Parameters.Add("DEPOSIT_STAFF_ID", OracleDbType.Varchar2).Value = depositStaffId;

                        // 添加返回值参数
                        command.Parameters.Add("RETURN_VALUE", OracleDbType.Varchar2, 200).Direction = ParameterDirection.ReturnValue;

                        // 执行存储函数
                        command.ExecuteNonQuery();

                        // 获取返回值
                        result = command.Parameters["RETURN_VALUE"].Value.ToString();
                    }
                }
                catch (Exception ex)  // 捕获并处理可能发生的异常
                {
                    // 输出错误信息到控制台
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return result;  // 返回存储函数的返回值
        }

        // 定义 PasswordCheck 函数
        public static int PasswordCheck(
            string password,
            string depositCreditCardNumbers,
            string depositCurrencyKind,
            decimal depositAmount,
            string depositBranchId,
            string depositStaffId,
            string ip)
        {
            // 从 ACCOUNT 表中查找 depositCreditCardNumbers 对应的密码
            string storedPassword = GetPasswordByCreditCardNumber(depositCreditCardNumbers);

            // 如果找不到密码，直接返回 0
            if (string.IsNullOrEmpty(storedPassword))
            {
                return 0;
            }

            // 调用 PasswordHandler 的 VerifyPassword 方法进行密码验证
            if (PasswordHandler.VerifyPassword(password, storedPassword))
            {
                // 如果密码验证通过，调用 Deposit 方法
                Deposit(depositCurrencyKind, depositCreditCardNumbers, depositAmount, depositBranchId, ip, depositStaffId);
                return 1;
            }
            else
            {
                // 如果密码验证不通过，直接返回 0
                return 0;
            }
        }

        // 从 ACCOUNT 表中查找 depositCreditCardNumbers 对应的密码
        private static string GetPasswordByCreditCardNumber(string depositCreditCardNumbers)
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
                        command.Parameters.Add(new OracleParameter(":creditCardNumber", depositCreditCardNumbers));

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
