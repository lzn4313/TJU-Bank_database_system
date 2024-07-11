using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Bank_database_system
{
    /*
     * AccountOperations类中包含账户操作的函数，函数中的所有的MessageBox显示信息都是暂时调试用的
     */
    public static class AccountOperations
    {
        // 进行账户操作时的操作数
        public enum OperateNumber
        {
            Freeze, // 冻结
            Unfreeze, // 解冻
            accountClosure // 销户
        };

        public const string connectionString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        // 显示银行卡查询的结果
        public static void BankCardInquiryResult(string bankCardID)
        {
            DataTable accountTable = BankCardInquiry(bankCardID);

            // 处理查询结果
            if (accountTable.Rows.Count == 0)
            {
                MessageBox.Show("查询失败");
            }
            // 获取其他字段的值并处理
            foreach (DataRow row in accountTable.Rows)
            {
                MessageBox.Show($"Credit Card Number: {row["CREDIT_CARD_NUMBERS"]}\n" +
                    $" Identification Number: {row["IDENTIFICATION_NUMBER"]}");
            }
        }

        // 银行卡查询的步骤
        private static DataTable BankCardInquiry(string bankCardID)
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
                    string selectQuery = "SELECT * FROM ACCOUNT WHERE CREDIT_CARD_NUMBERS = :bankCardID";
                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                        OracleParameter param = new OracleParameter(":bankCardID", OracleDbType.Varchar2);
                        param.Value = bankCardID; // 替换成实际的银行卡号
                        command.Parameters.Add(param);

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

        // 冻结、解冻、销户
        public static bool BankCardOperate(string bankCardID, OperateNumber operate)
        {
            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();
                    string operateQuery = "";
                    string state = "";
                    switch (operate)
                    {
                        case OperateNumber.Freeze:
                            operateQuery = @"UPDATE ACCOUNT SET STATE = :state 
                                            WHERE CREDIT_CARD_NUMBERS = :bankCardID";
                            state = "冻结";
                            break;
                        case OperateNumber.Unfreeze:
                            operateQuery = @"UPDATE ACCOUNT SET STATE = :state 
                                            WHERE CREDIT_CARD_NUMBERS = :bankCardID";
                            state = "正常";
                            break;
                        case OperateNumber.accountClosure:
                            operateQuery = @"DELETE FROM ACCOUNT
                                            WHERE CREDIT_CARD_NUMBERS = :bankCardID";
                            break;
                    }

                    // 构建更新语句
                    using (OracleCommand command = new OracleCommand(operateQuery, connection))
                    {
                        // 添加参数
                        if (state != "")
                        {
                            command.Parameters.Add(":state", OracleDbType.Varchar2).Value = state;
                        }
                        command.Parameters.Add(":bankCardID", OracleDbType.Varchar2).Value = bankCardID;

                        // 执行更新操作
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

        // 显示用户查询的结果
        public static void CustomerInquiryResult(string ID)
        {
            DataTable dataTable = CustomerInquiry(ID);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("查询失败");
            }
            // 获取字段的值并处理
            foreach (DataRow row in dataTable.Rows)
            {
                MessageBox.Show($" ID: {row["IDENTIFICATION_NUMBER"]}\n" +
                    $" Name: {row["CUSTOMER_NAME"]}\n" +
                    $" Address: {row["CUSTOMER_ADDRESS"]}\n" +
                    $" Phone Number: {row["CUSTOMER_PHONENUMBER"]}");
            }
        }

        // 用户查询的步骤
        private static DataTable CustomerInquiry(string ID)
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
                    string selectQuery = "SELECT * FROM CUSTOMER WHERE IDENTIFICATION_NUMBER = :ID";
                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                        OracleParameter param = new OracleParameter(":ID", OracleDbType.Varchar2);
                        param.Value = ID; // 替换成实际的身份证号
                        command.Parameters.Add(param);

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

        // 用户插入
        public static bool CustomerInsert(string ID, string name, string address, string phoneNumber)
        {
            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();

                    // 数据库操作
                    string insertQuery = "INSERT INTO CUSTOMER (IDENTIFICATION_NUMBER, CUSTOMER_NAME, CUSTOMER_ADDRESS, CUSTOMER_PHONENUMBER) " +
                             "VALUES (:ID, :name, :address, :phoneNumber)";
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 添加参数
                        command.Parameters.Add(":ID", OracleDbType.Varchar2).Value = ID;
                        command.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                        command.Parameters.Add(":address", OracleDbType.Varchar2).Value = address;
                        command.Parameters.Add(":phoneNumber", OracleDbType.Varchar2).Value = phoneNumber;

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

        // 根据身份证号ID更新用户信息
        public static bool CustomerUpdate(string IDtoUpdate, string newName, string newAddress, string newPhoneNumber)
        {
            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();

                    // 构建更新语句
                    string updateQuery = @"UPDATE CUSTOMER SET CUSTOMER_NAME = :newName, 
                        CUSTOMER_ADDRESS = :newAddress, 
                        CUSTOMER_PHONENUMBER = :newPhoneNumber
                        WHERE IDENTIFICATION_NUMBER = :IDtoUpdate";
                    using (OracleCommand command = new OracleCommand(updateQuery, connection))
                    {
                        // 添加参数
                        command.Parameters.Add(":newName", OracleDbType.Varchar2).Value = newName;
                        command.Parameters.Add(":newAddress", OracleDbType.Varchar2).Value = newAddress;
                        command.Parameters.Add(":newPhoneNumber", OracleDbType.Varchar2).Value = newPhoneNumber;
                        command.Parameters.Add(":IDtoUpdate", OracleDbType.Varchar2).Value = IDtoUpdate;

                        // 执行更新操作
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
}
