using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;

public static class FunctionsforITDepartment
{
    private const string connectionString =
        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));" +
        "User Id=system;Password=Tongji123456;";

    // 查找员工
    public static DataTable GetStaff(string staffIdPrefix, string name, string branchId, string department, int pageNumber, int pageSize)
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
                        SELECT *
                        FROM STAFF
                        WHERE (:staffIdPrefix IS NULL OR STAFF_ID LIKE :staffIdPrefix || '%')
                          AND (:name IS NULL OR NAME LIKE :name || '%')
                          AND (:branchId IS NULL OR BRANCH_ID = :branchId)
                          AND (:department IS NULL OR DEPARTMENT = :department)
                        ORDER BY STAFF_ID
                    ) a
                    WHERE ROWNUM <= :maxRow
                )
                WHERE rnum > :minRow";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("staffIdPrefix", string.IsNullOrEmpty(staffIdPrefix) ? (object)DBNull.Value : staffIdPrefix));
                    command.Parameters.Add(new OracleParameter("staffIdPrefix", string.IsNullOrEmpty(staffIdPrefix) ? (object)DBNull.Value : staffIdPrefix));
                    command.Parameters.Add(new OracleParameter("name", string.IsNullOrEmpty(name) ? (object)DBNull.Value : name));
                    command.Parameters.Add(new OracleParameter("name", string.IsNullOrEmpty(name) ? (object)DBNull.Value : name));
                    command.Parameters.Add(new OracleParameter("branchId", string.IsNullOrEmpty(branchId) ? (object)DBNull.Value : branchId));
                    command.Parameters.Add(new OracleParameter("branchId", string.IsNullOrEmpty(branchId) ? (object)DBNull.Value : branchId));
                    command.Parameters.Add(new OracleParameter("department", string.IsNullOrEmpty(department) ? (object)DBNull.Value : department));
                    command.Parameters.Add(new OracleParameter("department", string.IsNullOrEmpty(department) ? (object)DBNull.Value : department));
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
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return new DataTable(); // 出错返回空表
        }
    }
    // 重置密码
    public static bool ResetPassword(string staffId)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string newHashedPassword = PasswordHandler.HashPassword("123456");

                string query = @"
                UPDATE STAFF
                SET SYSTEM_KEY = :newHashedPassword
                WHERE STAFF_ID = :staffId";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("newHashedPassword", newHashedPassword));
                    command.Parameters.Add(new OracleParameter("staffId", staffId));

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }


    // 添加支行
    public static bool AddBranch(string branchId, string branchName, string branchAddress, string branchPhoneNumber)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO BRANCH (BRANCH_ID, BRANCH_NAME, BRANCH_ADDRESS, BRANCH_PHONENUMBER)
                VALUES (:branchId, :branchName, :branchAddress, :branchPhoneNumber)";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("branchId", branchId));
                    command.Parameters.Add(new OracleParameter("branchName", branchName));
                    command.Parameters.Add(new OracleParameter("branchAddress", branchAddress));
                    command.Parameters.Add(new OracleParameter("branchPhoneNumber", branchPhoneNumber));

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
    // 修改支行信息
    // 不允许修改ID
    public static bool UpdateBranch(string branchId, string branchName, string branchAddress, string branchPhoneNumber)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = @"
                UPDATE BRANCH
                SET BRANCH_NAME = :branchName,
                    BRANCH_ADDRESS = :branchAddress,
                    BRANCH_PHONENUMBER = :branchPhoneNumber
                WHERE BRANCH_ID = :branchId";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("branchName", branchName));
                    command.Parameters.Add(new OracleParameter("branchAddress", branchAddress));
                    command.Parameters.Add(new OracleParameter("branchPhoneNumber", branchPhoneNumber));
                    command.Parameters.Add(new OracleParameter("branchId", branchId));
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
    // 查找支行
    public static DataTable GetBranch(string branchId, string branchName, string branchAddress, string branchPhoneNumber, int pageNumber, int pageSize)
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
                    SELECT *
                    FROM BRANCH
                    WHERE (:branchId IS NULL OR BRANCH_ID LIKE :branchId || '%')
                      AND (:branchName IS NULL OR BRANCH_NAME LIKE :branchName || '%')
                      AND (:branchAddress IS NULL OR BRANCH_ADDRESS LIKE :branchAddress || '%')
                      AND (:branchPhoneNumber IS NULL OR BRANCH_PHONENUMBER LIKE :branchPhoneNumber || '%')
                    ORDER BY BRANCH_ID
                ) a
                WHERE ROWNUM <= :maxRow
            )
            WHERE rnum > :minRow";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("branchId", string.IsNullOrEmpty(branchId) ? (object)DBNull.Value : branchId));
                    command.Parameters.Add(new OracleParameter("branchId", string.IsNullOrEmpty(branchId) ? (object)DBNull.Value : branchId));
                    command.Parameters.Add(new OracleParameter("branchName", string.IsNullOrEmpty(branchName) ? (object)DBNull.Value : branchName));
                    command.Parameters.Add(new OracleParameter("branchName", string.IsNullOrEmpty(branchName) ? (object)DBNull.Value : branchName));
                    command.Parameters.Add(new OracleParameter("branchAddress", string.IsNullOrEmpty(branchAddress) ? (object)DBNull.Value : branchAddress));
                    command.Parameters.Add(new OracleParameter("branchAddress", string.IsNullOrEmpty(branchAddress) ? (object)DBNull.Value : branchAddress));
                    command.Parameters.Add(new OracleParameter("branchPhoneNumber", string.IsNullOrEmpty(branchPhoneNumber) ? (object)DBNull.Value : branchPhoneNumber));
                    command.Parameters.Add(new OracleParameter("branchPhoneNumber", string.IsNullOrEmpty(branchPhoneNumber) ? (object)DBNull.Value : branchPhoneNumber));
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
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return new DataTable(); // 出错返回空表
        }
    }


    // 查找操作记录
    public static DataTable GetOperateRecords(string staffId, string operateKind, DateTime? startTime, DateTime? endTime, int pageNumber, int pageSize)
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
                    SELECT *
                    FROM OPERATE_RECORD
                    WHERE (:staffId IS NULL OR STAFF_ID Like :staffId || '%')
                      AND (:operateKind IS NULL OR OPERATE_KIND = :operateKind)
                      AND (:startTime IS NULL OR OPERATE_TIME >= :startTime)
                      AND (:endTime IS NULL OR OPERATE_TIME <= :endTime)
                    ORDER BY OPERATE_TIME
                ) a
                WHERE ROWNUM <= :maxRow
            )
            WHERE rnum > :minRow";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("staffId", string.IsNullOrEmpty(staffId) ? (object)DBNull.Value : staffId));
                    command.Parameters.Add(new OracleParameter("staffId", string.IsNullOrEmpty(staffId) ? (object)DBNull.Value : staffId));
                    command.Parameters.Add(new OracleParameter("operateKind", string.IsNullOrEmpty(operateKind) ? (object)DBNull.Value : operateKind));
                    command.Parameters.Add(new OracleParameter("operateKind", string.IsNullOrEmpty(operateKind) ? (object)DBNull.Value : operateKind));
                    command.Parameters.Add(new OracleParameter("startTime", startTime.HasValue ? (object)startTime.Value : DBNull.Value));
                    command.Parameters.Add(new OracleParameter("startTime", startTime.HasValue ? (object)startTime.Value : DBNull.Value));
                    command.Parameters.Add(new OracleParameter("endTime", endTime.HasValue ? (object)endTime.Value : DBNull.Value));
                    command.Parameters.Add(new OracleParameter("endTime", endTime.HasValue ? (object)endTime.Value : DBNull.Value));
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
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return new DataTable(); // 出错返回空表
        }
    }
    public static DataTable GetOperateRecords(string operateId)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT *
                    FROM OPERATE_RECORD
                    WHERE OPERATE_ID = :operateId";                
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("operateId", operateId));
 
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
            // 报错信息，测试用
            // Console.WriteLine("Error: " + ex.Message);
            return new DataTable(); // 出错返回空表
        }
    }
    public static DataTable GetOperateDetailsByOperateId(string operateId)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                // 查询操作记录，获取操作类型及相关ID
                string operateRecordQuery = @"
                    SELECT *
                    FROM OPERATE_RECORD
                    WHERE OPERATE_ID = :operateId";

                using (OracleCommand operateRecordCommand = new OracleCommand(operateRecordQuery, connection))
                {
                    operateRecordCommand.Parameters.Add(new OracleParameter("operateId", operateId));
                    using (OracleDataReader operateRecordReader = operateRecordCommand.ExecuteReader())
                    {
                        if (operateRecordReader.Read())
                        {
                            string operateKind = operateRecordReader["OPERATE_KIND"].ToString();
                            string loanId = operateRecordReader["LOAN_ID"].ToString();
                            string depositId = operateRecordReader["DEPOSIT_ID"].ToString();
                            string hireId = operateRecordReader["HIRE_ID"].ToString();
                            string transactionId = operateRecordReader["TRANSACTION_ID"].ToString();

                            string detailsQuery = "";
                            string detailId = "";
                            string detailTable = "";

                            // 根据操作类型选择查询的表和ID
                            switch (operateKind)
                            {
                                case "1":
                                    detailsQuery = "SELECT * FROM LOAN WHERE LOAN_ID = :detailId";
                                    detailId = loanId;
                                    detailTable = "LOAN";
                                    break;
                                case "2":
                                    detailsQuery = "SELECT * FROM TIME_DEPOSIT WHERE DEPOSIT_ID = :detailId";
                                    detailId = depositId;
                                    detailTable = "TIME_DEPOSIT";
                                    break;
                                case "3":
                                    detailsQuery = "SELECT * FROM SAFE_BOX_HIRE WHERE HIRE_ID = :detailId";
                                    detailId = hireId;
                                    detailTable = "SAFE_BOX_HIRE";
                                    break;
                                case "4":
                                    detailsQuery = "SELECT * FROM TRANSACTION_HISTORY WHERE TRANSACTION_ID = :detailId";
                                    detailId = transactionId;
                                    detailTable = "TRANSACTION_HISTORY";
                                    break;
                                default:
                                    throw new Exception("不支持的操作类型: " + operateKind);
                            }

                            if (!string.IsNullOrEmpty(detailsQuery) && !string.IsNullOrEmpty(detailId))
                            {
                                using (OracleCommand detailsCommand = new OracleCommand(detailsQuery, connection))
                                {
                                    detailsCommand.Parameters.Add(new OracleParameter("detailId", detailId));

                                    using (OracleDataReader detailsReader = detailsCommand.ExecuteReader())
                                    {
                                        DataTable dataTable = new DataTable();
                                        dataTable.Load(detailsReader);
                                        return dataTable;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("未找到操作记录: " + operateId);
                            }
                        }
                        else
                        {
                            throw new Exception("未找到操作记录: " + operateId);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // 可以记录异常信息以便调试
            Console.WriteLine("Error: " + ex.Message);
            return new DataTable(); // 出错返回空表
        }
    }

}