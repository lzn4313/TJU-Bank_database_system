using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace Bank_database_system
{
    /*********************************************************
     * 
     *负责办理转账业务
     *
     *********************************************************/
    public static class Transfer
    {
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        /********************************************************************* 
         *办理转账，检查转入的账号是否冻结，余额是否充足，但不检查转出的账号是否冻结，不检查密码是否正确
         *参数：
         *outCard 转出的卡号 string
         *inCard 转入的卡号 string
         *IP IP地址 string （待定）
         *amount 存款金额 decimal
         *staff ID 办理业务的员工的id string
         *outcome 承接办理结果（成功还是失败） bool
         *返回成功/失败信息 string
         **********************************************************************/
        private static String TransferBusiness(String  outCard, String inCard, String IP, decimal amount, String staffID , out bool outcome)
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
                    using (OracleCommand command = new OracleCommand("TRANSFER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OracleParameter returnValue = new OracleParameter("return_value", OracleDbType.Varchar2, 2000)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnValue);

                        command.Parameters.Add("inCard", OracleDbType.Varchar2).Value = inCard;
                        command.Parameters.Add("outCard", OracleDbType.Varchar2).Value = outCard;
                        command.Parameters.Add("amount", OracleDbType.Decimal).Value = amount; // 注意这里使用 OracleDbType.Decimal
                        command.Parameters.Add("IP", OracleDbType.Varchar2).Value = IP;
                        command.Parameters.Add("staffID", OracleDbType.Varchar2).Value = staffID;

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

        /********************************************************************* 
         *撤销转账，只能撤销还在转账中的转账，不检查账号是否冻结，不检查密码是否正确
         *参数：
         *outCard 办理撤销的卡号 string
         *transactionID 撤销的转账记录的ID string
         *IP IP地址 string （待定）
         *staff ID 办理业务的员工的id string
         *outcome 承接办理结果（成功还是失败） bool
         *返回成功/失败信息 string
         **********************************************************************/
        private static String CancleBusiness(String outCard, String inCard, String IP, decimal amount, String staffID, out bool outcome)
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
                    using (OracleCommand command = new OracleCommand("CANCLE_TRANSFER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OracleParameter returnValue = new OracleParameter("return_value", OracleDbType.Varchar2, 2000)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnValue);
                        command.Parameters.Add("outCard", OracleDbType.Varchar2).Value = outCard;
                        command.Parameters.Add("IP", OracleDbType.Varchar2).Value = IP;
                        command.Parameters.Add("staffID", OracleDbType.Varchar2).Value = staffID;

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
