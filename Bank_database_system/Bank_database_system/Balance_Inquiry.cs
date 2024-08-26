//using Oracle.ManagedDataAccess.Client;  // 引入 Oracle 数据库访问的命名空间
//using System;  // 引入基础类库命名空间
//using System.Data;  // 引入数据处理的命名空间

//namespace Bank_database_system  // 定义命名空间 Bank_database_system
//{
//    public class Balance_Inquiry  // 定义类 Balance_Inquiry
//    {

//        // 定义数据库连接字符串作为常量
//        public const string connectionString =
//            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
//            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

//        public int BalanceInquiry(string creditCardNumber)
//        {
//            int accountBalance = -1;  // 初始化余额为-1

//            using (OracleConnection connection = new OracleConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();  // 打开数据库连接

//                    using (OracleCommand command = new OracleCommand("BALANCE_INQUIRY", connection))
//                    {
//                        command.CommandType = CommandType.StoredProcedure;
//                    }

//                        // 添加输入参数// 定义数据库连接字符串作为常量
//        public const string connectionString =
//            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
//            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";
//        command.Parameters.Add("INQUIRY_CREDIT_CARD_NUMBERS", OracleDbType.Varchar2).Value = creditCardNumber;

//                        // 添加返回值参数
//                        command.Parameters.Add("RETURN_VALUE", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;

//                        // 执行存储过程
//                        command.ExecuteNonQuery();

//                        // 获取返回值
//                        accountBalance = Convert.ToInt32(command.Parameters["RETURN_VALUE"].Value.ToString());
//                    }
//}
//                catch (OracleException ex)
//                {
//                    // 处理数据库异常
//                    Console.WriteLine("OracleException: " + ex.Message);
//accountBalance = -1;  // 数据库异常时返回-1
//                }
//                catch (Exception ex)
//                {
//                    // 处理其他异常
//                    Console.WriteLine("Exception: " + ex.Message);
//accountBalance = -1;  // 其他异常时返回-1
//                }
//            }

//            return accountBalance;
//        }
//    }
//}
