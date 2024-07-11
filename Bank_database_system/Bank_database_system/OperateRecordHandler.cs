using System;
using System.Data;
using System.Net;
using Oracle.ManagedDataAccess.Client;

public static class OperateRecordHandler
{
    private static string connectionString =
        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));" +
        "User Id=system;Password=Tongji123456;";

    private static string GenerateOperateId()
    {
        return Guid.NewGuid().ToString("N").ToUpper();
    }

    private static DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }

    private static string GetLocalIPAddress()
    {
        string localIP = "";
        foreach (var address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                localIP = address.ToString();
                break;
            }
        }
        return localIP;
    }

    // 插入操作记录
    // 贷款、存款、租用保险柜、交易需要传入loanId、depositId、hireId、transactionId
    // 贷款、存款、租用保险柜、交易对应的操作类型operateKind是1、2、3、4
    public static bool InsertOperateRecord(string staffId, string operateKind, string operateContent, string loanId, string depositId, string hireId, string transactionId)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string operateId = GenerateOperateId();
                DateTime operateTime = GetCurrentTime();
                string operateIp = GetLocalIPAddress();

                string query = @"
                    INSERT INTO OPERATE_RECORD (
                        OPERATE_ID, STAFF_ID, OPERATE_KIND, OPERATE_CONTENT, OPERATE_TIME, OPERATE_IP, LOAN_ID, DEPOSIT_ID, HIRE_ID, TRANSACTION_ID
                    ) VALUES (
                        :operateId, :staffId, :operateKind, :operateContent, :operateTime, :operateIp, :loanId, :depositId, :hireId, :transactionId
                    )";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("operateId", operateId));
                    command.Parameters.Add(new OracleParameter("staffId", staffId));
                    command.Parameters.Add(new OracleParameter("operateKind", operateKind));
                    command.Parameters.Add(new OracleParameter("operateContent", operateContent));
                    command.Parameters.Add(new OracleParameter("operateTime", operateTime));
                    command.Parameters.Add(new OracleParameter("operateIp", operateIp));
                    command.Parameters.Add(new OracleParameter("loanId", string.IsNullOrEmpty(loanId) ? (object)DBNull.Value : loanId));
                    command.Parameters.Add(new OracleParameter("depositId", string.IsNullOrEmpty(depositId) ? (object)DBNull.Value : depositId));
                    command.Parameters.Add(new OracleParameter("hireId", string.IsNullOrEmpty(hireId) ? (object)DBNull.Value : hireId));
                    command.Parameters.Add(new OracleParameter("transactionId", string.IsNullOrEmpty(transactionId) ? (object)DBNull.Value : transactionId));

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}
