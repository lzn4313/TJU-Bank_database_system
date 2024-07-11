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

        // 查询并打印所有保险箱数据的方法
        public static void QueryAndPrintSafeBoxData()
        {
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
                            // 创建 DataTable 对象来存储查询结果
                            DataTable safeBoxTable = new DataTable();
                            adapter.Fill(safeBoxTable);  // 填充数据表

                            // 遍历数据表中的每一行，输出结果
                            foreach (DataRow row in safeBoxTable.Rows)
                            {
                                Console.WriteLine($"SAFE_BOX_ID: {row["SAFE_BOX_ID"]}, BRANCH_ID: {row["BRANCH_ID"]}, BOX_SIZE: {row["BOX_SIZE"]}, STATE: {row["STATE"]}");
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
        }

        // 查询并打印特定保险箱数据的方法
        public static void SELECT_SAFE_BOX(string safeBoxId)
        {
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

                        // 执行查询并获取结果
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 输出查询结果
                                Console.WriteLine($"SAFE_BOX_ID: {reader["SAFE_BOX_ID"]}, BRANCH_ID: {reader["BRANCH_ID"]}, BOX_SIZE: {reader["BOX_SIZE"]}, BOX_CASH_PLEDGE: {reader["BOX_CASH_PLEDGE"]}, RENTAL_AMOUNT: {reader["RENTAL_AMOUNT"]}, STATE: {reader["STATE"]}");
                            }
                            else
                            {
                                Console.WriteLine("No safe box found with the given ID.");
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
    }
}
