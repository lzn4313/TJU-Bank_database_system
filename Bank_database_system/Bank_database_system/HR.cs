using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml.Linq;
using System.Numerics;

namespace Bank_database_system
{
    public class HR
    {
        //数据库连接
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

        //显示员工信息
        public static DataTable HRtable(string Staff_ID, string Branch_Name, string Name, string Department)
        {
            DataTable HRtable = new DataTable();
            //建立连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //SQL语句
                    string query = @"SELECT STAFF_ID AS 员工ID,NAME AS 员工姓名,BRANCH_NAME AS 所在支行,DEPARTMENT AS 部门 ,PHONENUMBER AS 联系方式,WORKING_CONDITION AS 在职情况
                                    FROM STAFF NATURAL JOIN PERSONAL_INFORMATION NATURAL JOIN BRANCH 
                                    WHERE 1=1";
                    if (Staff_ID != string.Empty)
                    {
                        query += "AND STAFF_ID LIKE :staff_id || '%'";
                    }
                    if (Name != string.Empty)
                    {
                        query += "AND Name LIKE :name || '%'";
                    }
                    if (Branch_Name != string.Empty)
                    {
                        query += "AND Branch_Name LIKE :branch_name || '%'";
                    }
                    if (Department != string.Empty)
                    {
                        query += "AND Department = :department";
                    }
                    //进行操作
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {

                        if (Staff_ID != string.Empty)
                        {
                            command.Parameters.Add(new OracleParameter("staff_id", Staff_ID));
                        }
                        if (Name != string.Empty)
                        {
                            command.Parameters.Add(new OracleParameter("name", Name));
                        }
                        if (Branch_Name != string.Empty)
                        {
                            command.Parameters.Add(new OracleParameter("branch_name", Branch_Name));
                        }
                        if (Department != string.Empty)
                        {
                            command.Parameters.Add(new OracleParameter("department", Department));
                        }

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            HRtable.Load(reader);
                            return HRtable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);

                    return HRtable;
                }
            }
        }

        //新建员工信息
        public static void CreateHR(string Staff_ID, string Branch_ID, string ID_number, string Name, string Address, string Phone_Number, double Salary, string System_Key, string Department, string Salary_card_id)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //判断支行是否存在
                    string checkBranchQuery = "SELECT COUNT(*) FROM BRANCH WHERE BRANCH_ID = :branch_id";
                    using (OracleCommand checkBranchCommand = new OracleCommand(checkBranchQuery, connection))
                    {
                        checkBranchCommand.Parameters.Add(new OracleParameter("branch_id", Branch_ID));

                        int branchCount = Convert.ToInt32(checkBranchCommand.ExecuteScalar());

                        //若不存在该支行，则提示
                        if (branchCount <= 0)
                        {
                            //提示已存在工号
                            MessageBox.Show("不存在该支行，创建失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else//若存在该支行
                        {
                            //判断卡号是否正确
                            string checkCardQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE CREDIT_CARD_NUMBERS = :Salary_card_id";
                            using (OracleCommand checkCardCommand = new OracleCommand(checkCardQuery, connection))
                            {
                                checkCardCommand.Parameters.Add(new OracleParameter("Salary_card_id", Salary_card_id));

                                int CardCount = Convert.ToInt32(checkCardCommand.ExecuteScalar());

                                if (CardCount > 0)//若存在卡号，则加入
                                {
                                    //判断员工工号是否存在
                                    string checkStaffQuery = "SELECT COUNT(*) FROM STAFF WHERE STAFF_ID = :staff_id";
                                    using (OracleCommand checkStaffCommand = new OracleCommand(checkStaffQuery, connection))
                                    {
                                        checkStaffCommand.Parameters.Add(new OracleParameter("staff_id", Staff_ID));

                                        int staffCount = Convert.ToInt32(checkStaffCommand.ExecuteScalar());

                                        //若已存在该员工工号，则提示
                                        if (staffCount > 0)
                                        {
                                            //提示已存在工号
                                            MessageBox.Show("已存在该员工工号，创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else//若不存在员工工号，进行后续操作
                                        {
                                            //判断该人是否已是员工
                                            string checkisstaffQuery = "SELECT COUNT(*) FROM STAFF WHERE IDENTIFICATION_NUMBER = :ID_number";
                                            using (OracleCommand checkisstaffCommand = new OracleCommand(checkisstaffQuery, connection))
                                            {
                                                checkisstaffCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));

                                                int Count = Convert.ToInt32(checkisstaffCommand.ExecuteScalar());

                                                if (Count > 0)//若存在该人已是员工
                                                {
                                                    MessageBox.Show("该人已是员工，创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else { 
                                                    //判断员工登记的个人信息是否存在
                                                    string checkPersonQuery = "SELECT NAME, ADDRESS, PHONENUMBER FROM PERSONAL_INFORMATION WHERE IDENTIFICATION_NUMBER = :ID_number";
                                                    using (OracleCommand checkPersonCommand = new OracleCommand(checkPersonQuery, connection))
                                                    {
                                                        checkPersonCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));
                                                        using (OracleDataReader reader = checkPersonCommand.ExecuteReader())
                                                        {
                                                            //若已存在信息
                                                            if (reader.Read())
                                                            {

                                                                string existingName = reader["NAME"].ToString();
                                                                string existingAddress = reader["ADDRESS"].ToString();
                                                                string existingPhoneNumber = reader["PHONENUMBER"].ToString();

                                                                //若员工登记信息与个人信息不一致，询问是否修改
                                                                if (existingName != Name || existingAddress != Address || existingPhoneNumber != Phone_Number)
                                                                {
                                                                    DialogResult result = MessageBox.Show("员工登记信息与个人信息不一致，是否修改!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                                    //若选择修改，则更新个人信息
                                                                    if (result == DialogResult.Yes)
                                                                    {
                                                                        //更新个人信息
                                                                        string updatePersonQuery = "UPDATE PERSONAL_INFORMATION SET NAME = :Name, ADDRESS = :Address, PHONENUMBER = :Phone_Number WHERE IDENTIFICATION_NUMBER = :ID_number";
                                                                        using (OracleCommand updatePersonCommand = new OracleCommand(updatePersonQuery, connection))
                                                                        {
                                                                            updatePersonCommand.Parameters.Add(new OracleParameter("Name", Name));
                                                                            updatePersonCommand.Parameters.Add(new OracleParameter("Address", Address));
                                                                            updatePersonCommand.Parameters.Add(new OracleParameter("Phone_Number", Phone_Number));
                                                                            updatePersonCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));
                                                                            updatePersonCommand.ExecuteNonQuery();
                                                                        }
                                                                    }
                                                                    else//若选择不修改，直接返回
                                                                    {
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                            else//若不存在信息，则首先添加个人信息
                                                            {
                                                                string insertPersonQuery = @"INSERT INTO PERSONAL_INFORMATION (IDENTIFICATION_NUMBER, NAME, ADDRESS, PHONENUMBER)
                                                                VALUES (:ID_number, :Name, :Address, :Phone_Number)";
                                                                using (OracleCommand insertPersonCommand = new OracleCommand(insertPersonQuery, connection))
                                                                {
                                                                    insertPersonCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));
                                                                    insertPersonCommand.Parameters.Add(new OracleParameter("Name", Name));
                                                                    insertPersonCommand.Parameters.Add(new OracleParameter("Address", Address));
                                                                    insertPersonCommand.Parameters.Add(new OracleParameter("Phone_Number", Phone_Number));
                                                                    insertPersonCommand.ExecuteNonQuery();
                                                                }
                                                            }

                                                            string insertStaffQuery = @"INSERT INTO STAFF (STAFF_ID, BRANCH_ID, SALARY, SYSTEM_KEY, DEPARTMENT, IDENTIFICATION_NUMBER, WORKING_CONDITION,SALARY_CARD_ID)
                                                                VALUES (:Staff_ID, :Branch_ID, :Salary, :System_key, :Department, :ID_number, '在职', :Salary_card_id)";
                                                            using (OracleCommand insertStaffCommand = new OracleCommand(insertStaffQuery, connection))
                                                            {
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("Staff_ID", Staff_ID));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("Branch_ID", Branch_ID));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("Salary", Salary));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("System_Key", PasswordHandler.HashPassword(System_Key)));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("Department", Department));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));
                                                                insertStaffCommand.Parameters.Add(new OracleParameter("Salary_card_id", Salary_card_id));
                                                                insertStaffCommand.ExecuteNonQuery();
                                                            }
                                                            MessageBox.Show("员工创建完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else//若不存在卡号，提示并退出
                                {
                                    MessageBox.Show("不存在该卡号，创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        //修改员工信息
        public static void UpdateHR(string Staff_ID, string Branch_ID, string ID_number, string Name, string Address, string Phone_Number, double Salary, string Working_Condition, string Department, string Salary_card_id)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //判断员工ID是否存在
                    string checkStaffQuery = "SELECT COUNT(*) FROM STAFF WHERE STAFF_ID = :Staff_ID";

                    using (OracleCommand checkStaffCommand = new OracleCommand(checkStaffQuery, connection))
                    {
                        checkStaffCommand.Parameters.Add(new OracleParameter("Staff_ID", Staff_ID));

                        int staffCount = Convert.ToInt32(checkStaffCommand.ExecuteScalar());
                        //若不存在该员工，则提示
                        if (staffCount <= 0)
                        {
                            MessageBox.Show("不存在该员工，修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //判断支行ID是否存在
                            string checkBranchQuery = "SELECT COUNT(*) FROM BRANCH WHERE BRANCH_ID = :branch_id";

                            using (OracleCommand checkBranchCommand = new OracleCommand(checkBranchQuery, connection))
                            {
                                checkBranchCommand.Parameters.Add(new OracleParameter("branch_id", Branch_ID));

                                int branchCount = Convert.ToInt32(checkBranchCommand.ExecuteScalar());
                                //若不存在该支行，则提示
                                if (branchCount <= 0)
                                {
                                    //提示已存在工号
                                    MessageBox.Show("不存在该支行，修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else//若存在该支行
                                {
                                    //判断卡号是否正确
                                    string checkCardQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE CREDIT_CARD_NUMBERS = :Salary_card_id";
                                    using (OracleCommand checkCardCommand = new OracleCommand(checkCardQuery, connection))
                                    {
                                        checkCardCommand.Parameters.Add(new OracleParameter("Salary_card_id", Salary_card_id));

                                        int CardCount = Convert.ToInt32(checkCardCommand.ExecuteScalar());

                                        if (CardCount > 0)//若存在卡号，则加入
                                        {
                                            //更新个人信息
                                            string updatePersonQuery = "UPDATE PERSONAL_INFORMATION SET NAME = :Name, ADDRESS = :Address, PHONENUMBER = :Phone_Number WHERE IDENTIFICATION_NUMBER = :ID_number";
                                            using (OracleCommand updatePersonCommand = new OracleCommand(updatePersonQuery, connection))
                                            {
                                                updatePersonCommand.Parameters.Add(new OracleParameter("Name", Name));
                                                updatePersonCommand.Parameters.Add(new OracleParameter("Address", Address));
                                                updatePersonCommand.Parameters.Add(new OracleParameter("Phone_Number", Phone_Number));
                                                updatePersonCommand.Parameters.Add(new OracleParameter("ID_number", ID_number));
                                                updatePersonCommand.ExecuteNonQuery();
                                            }
                                            string updateStaffQuery = "UPDATE STAFF SET BRANCH_ID = :Branch_ID, SALARY = :Salary, DEPARTMENT = :Department, SALARY_CARD_ID = :Salary_card_id, WORKING_CONDITION = :Working_Condition WHERE STAFF_ID = :Staff_ID";
                                            using (OracleCommand updateStaffCommand = new OracleCommand(updateStaffQuery, connection))
                                            {
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Branch_ID", Branch_ID));
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Salary", Salary));
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Department", Department));
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Salary_card_id", Salary_card_id));
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Working_Condition", Working_Condition));
                                                updateStaffCommand.Parameters.Add(new OracleParameter("Staff_ID", Staff_ID));
                                                updateStaffCommand.ExecuteNonQuery();
                                            }
                                            MessageBox.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("不存在该卡号，修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        //获取员工信息
        public struct HRinfo{
            public string STAFF_ID;
            public string BRANCH_ID;
            public string NAME;
            public string ID;
            public string CARD;
            public string PHONE;
            public string ADDRESS;
            public string DEPARTMENT;
            public string SALARY;
            public string CONDITION;
        }
        public static HRinfo ReadHR(string Staff_ID)
        {
            HRinfo info;
            //建立连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //SQL语句
                    string query = @"SELECT*
                                    FROM STAFF NATURAL JOIN PERSONAL_INFORMATION NATURAL JOIN BRANCH 
                                    WHERE STAFF_ID = :staff_id";
                    //进行操作
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("staff_id", Staff_ID));
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.STAFF_ID = reader["STAFF_ID"].ToString();
                                info.NAME = reader["NAME"].ToString();
                                info.BRANCH_ID = reader["BRANCH_ID"].ToString();
                                info.ID = reader["IDENTIFICATION_NUMBER"].ToString();
                                info.ADDRESS = reader["ADDRESS"].ToString();
                                info.PHONE = reader["PHONENUMBER"].ToString();
                                info.CARD = reader["SALARY_CARD_ID"].ToString();
                                info.SALARY = reader["SALARY"].ToString();
                                info.DEPARTMENT = reader["DEPARTMENT"].ToString();
                                info.CONDITION = reader["WORKING_CONDITION"].ToString();
                                return info;
                            }
                            else
                            {
                                MessageBox.Show("查询失败，请检查ID正确与否", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                info.STAFF_ID = "";
                                info.NAME = "";
                                info.BRANCH_ID = "";
                                info.ID = "";
                                info.ADDRESS = "";
                                info.PHONE = "";
                                info.CARD = "";
                                info.SALARY = "";
                                info.DEPARTMENT = "";
                                info.CONDITION = "";
                                return info;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    info.STAFF_ID = "";
                    info.NAME = "";
                    info.BRANCH_ID = "";
                    info.ID = "";
                    info.ADDRESS = "";
                    info.PHONE = "";
                    info.CARD = "";
                    info.SALARY = "";
                    info.DEPARTMENT = "";
                    info.CONDITION = "";
                    return info;
                }
            }
        }
    }
}
