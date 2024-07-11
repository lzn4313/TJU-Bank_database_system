using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Bank_database_system
{
    /*
     * 负责定期存款的办理
     */
    public static class TimeDeposit
    {
        public const string connectionString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        // 查询可办理的定期存款的类型
        public static DataTable QueryDepositType()
        {
            // 返回的表
            DataTable dataTable = new DataTable();
            // 创建数据库连接对象
            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();

                    // 数据库操作
                    string selectQuery = "SELECT * FROM TIME_DEPOSIT_TYPE";
                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                        // 执行查询
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader); // 将查询结果加载到 DataTable                           
                            return dataTable;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                // 处理 Oracle 数据库相关异常
                MessageBox.Show($"数据库操作失败：{ex.Message}", "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
            catch (Exception ex)
            {
                // 处理其他类型的异常
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /********************************************************************* 
         *办理定期存款,不检查账号是否冻结，密码是否正确
         *参数：
         *card 办理的卡号 string
         *type ID 选择的定期存款类型 string
         *amount 存款金额 decimal
         *IP IP地址 string （待定）
         *staff ID 办理业务的员工的id string
         *months 办理的时间长度，以月为单位（每月三十天） decimal
         *outcome 承接办理结果（成功还是失败） bool
         *返回成功/失败信息 string
         **********************************************************************/
        private static String ApplyDeposit(String card, String typeID, decimal amount, String IP, String staffID, decimal months, out bool outcome)
        {
            string results = "N/A";
            outcome = false;

            // 创建数据库连接对象
            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();
                    // 数据库操作
                    using (OracleCommand command = new OracleCommand("FIXED_DEPOSIT", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OracleParameter returnValue = new OracleParameter("return_value", OracleDbType.Varchar2, 2000)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnValue);

                        command.Parameters.Add("card", OracleDbType.Varchar2).Value = card;
                        command.Parameters.Add("typeID", OracleDbType.Varchar2).Value = typeID;
                        command.Parameters.Add("amount", OracleDbType.Decimal).Value = amount; // 注意这里使用 OracleDbType.Decimal
                        command.Parameters.Add("IP", OracleDbType.Varchar2).Value = IP;
                        command.Parameters.Add("staffID", OracleDbType.Varchar2).Value = staffID;
                        command.Parameters.Add("months", OracleDbType.Decimal).Value = months;

                        // Output parameter
                        OracleParameter outcomeParam = new OracleParameter("outcome", OracleDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outcomeParam);

                        command.ExecuteNonQuery();
                        if (returnValue.Value != DBNull.Value)
                        {
                            results = returnValue.Value.ToString();
                        }
                        outcome = outcomeParam.Value.ToString() != "1";
                    }
                }
            }
            catch (OracleException ex)
            {
                // 处理 Oracle 数据库相关异常
                MessageBox.Show($"数据库操作失败：{ex.Message}", "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // 处理其他类型的异常
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return results;
        }
    }
}
