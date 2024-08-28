using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Bank_database_system
{
    /*
     * AccountOperations类中包含账户操作的函数，函数中的所有的MessageBox显示信息都是暂时调试用的
     */
    public static class AccountOperations
    {
        public enum OperateNumber
        {
            freeze, // 冻结
            unfreeze, // 解冻
            accountClosure // 销户
        };

        public const string connectionString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        // 银行卡查询
        public static DataTable BankCardInquiry(string bankCardID)
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
                        case OperateNumber.freeze:
                            operateQuery = @"UPDATE ACCOUNT SET STATE = :state 
                                            WHERE CREDIT_CARD_NUMBERS = :bankCardID";
                            state = "冻结";
                            break;
                        case OperateNumber.unfreeze:
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

        // 使用ID进行用户查询
        public static DataTable CustomerInquiryByID(string ID)
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
                    string selectQuery = "SELECT * FROM PERSONAL_INFORMATION WHERE IDENTIFICATION_NUMBER = :ID";
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

        // 使用其他属性筛选用户
        public static DataTable CustomerInquiry(string ID, string name, string address, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                return CustomerInquiryByID(ID);
            }

            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM PERSONAL_INFORMATION WHERE 1=1";

                if (!string.IsNullOrEmpty(name))
                {
                    selectQuery += " AND NAME = :name";
                }
                if (!string.IsNullOrEmpty(address))
                {
                    selectQuery += " AND ADDRESS = :address";
                }
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    selectQuery += " AND PHONENUMBER = :phoneNumber";
                }

                using (OracleCommand command = new OracleCommand(selectQuery, connection))
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        command.Parameters.Add(new OracleParameter("name", OracleDbType.Varchar2) { Value = name });
                    }
                    if (!string.IsNullOrEmpty(address))
                    {
                        command.Parameters.Add(new OracleParameter("address", OracleDbType.Varchar2) { Value = address });
                    }
                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        command.Parameters.Add(new OracleParameter("phoneNumber", OracleDbType.Varchar2) { Value = phoneNumber });
                    }

                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(command))
                    {
                        try
                        {
                            dataAdapter.Fill(dataTable);
                        }
                        catch (OracleException ex)
                        {
                            Console.WriteLine("Oracle error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("General error: " + ex.Message);
                        }
                    }
                }
            }

            return dataTable;
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

        // 银行卡办理
        public static bool BankCardProcessing(string branchID, string ID, string name, string address, string phoneNumber, string InitialPassword)
        {
            if (CustomerInquiryByID(ID).Rows.Count == 0)
            {
                if (!CustomerInsert(ID, name, address, phoneNumber))
                {
                    return false;
                }
            }

            string bankCardID = BankAccountGenerator.GenerateUniqueCardID();
            string hashPassword = PasswordHandler.HashPassword(InitialPassword);
            DateTime openDate = GetCurrentTime();

            try
            {
                using (OracleConnection connection = new(connectionString))
                {
                    // 打开数据库连接
                    connection.Open();

                    // 数据库操作
                    string insertQuery = @"INSERT INTO ACCOUNT (CREDIT_CARD_NUMBERS, IDENTIFICATION_NUMBER, BRANCH_ID, OPEN_DATE, STATE, BALANCE, PASSWORD, CREDIT_SCORE) 
                                           VALUES (:bankCardID, :ID, :branchID, :openDate, :state, :balance, :hashPassword, :creditScore)";
                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        // 添加参数
                        command.Parameters.Add(new OracleParameter("bankCardID", bankCardID));
                        command.Parameters.Add(new OracleParameter("ID", ID));
                        command.Parameters.Add(new OracleParameter("branchID", branchID));
                        command.Parameters.Add(new OracleParameter("openDate", openDate));
                        command.Parameters.Add(new OracleParameter("state", "正常"));
                        // 设置参数
                        OracleParameter param = new OracleParameter("balance", OracleDbType.Decimal);
                        param.Value = 0;
                        param.Size = 12;  // 总位数
                        param.Scale = 2;  // 小数点后位数

                        command.Parameters.Add(param);
                        command.Parameters.Add(new OracleParameter("hashPassword", hashPassword));
                        command.Parameters.Add(new OracleParameter("creditScore", 50));

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

        private static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    // 随机生成20位的银行卡号
    public static class BankAccountGenerator
    {
        private static Random random = new Random();

        public static string GenerateUniqueCardID()
        {
            string cardNumber;
            do
            {
                cardNumber = GenerateRandom20ID();
            } while (AccountOperations.BankCardInquiry(cardNumber).Rows.Count > 0);

            return cardNumber;
        }

        public static string GenerateRandom20ID()
        {
            // 生成20位随机数字串
            const int cardNumberLength = 20;
            const string digits = "0123456789";
            char[] cardNumberArray = new char[cardNumberLength];

            for (int i = 0; i < cardNumberLength; i++)
            {
                cardNumberArray[i] = digits[random.Next(digits.Length)];
            }

            return new string(cardNumberArray);
        }
    }
}
