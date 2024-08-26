using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml.Linq;

namespace Bank_database_system
{
    public class HR
    {
        //数据库连接
        public const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))
            (CONNECT_DATA=(SID=orcl)));User Id=system;Password=Tongji123456;";

        //显示员工信息
        public static DataTable HRtable(string Staff_ID, string Branch_ID, string Name, string Department)
        {
            DataTable HRtable = new DataTable();
            //建立连接
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //SQL语句
                    string query = @"SELECT NAME,STAFF_ID,BRANH_NAME,DEPARTMENT 
                                    FROM STAFF,BRANCH 
                                    WHERE (:staff_id IS NULL OR STAFF_ID LIKE :staff_id || '%')
                                      AND (:name IS NULL OR NAME LIKE :name || '%')
                                      AND (:branch_id IS NULL OR STAFF.BRANCH_ID = :branch_id)
                                      AND (:department IS NULL OR DEPARTMENT = :department)
                                      AND BRANCH.BRANCH_ID=STAFF.BRANCH_ID";
                    //进行操作
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":staff_id", string.IsNullOrEmpty(Staff_ID) ? (object)DBNull.Value : Staff_ID));
                        command.Parameters.Add(new OracleParameter(":name", string.IsNullOrEmpty(Name) ? (object)DBNull.Value : Name));
                        command.Parameters.Add(new OracleParameter(":branch_id", string.IsNullOrEmpty(Branch_ID) ? (object)DBNull.Value : Branch_ID));
                        command.Parameters.Add(new OracleParameter(":department", string.IsNullOrEmpty(Department) ? (object)DBNull.Value : Department));
                        
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
        public static void CreateHR(string Staff_ID, string Branch_ID, string Name, string Address,string Phone_Number, float Salary, string System_Key,string Department)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //SQL语句
                    string query = "SELECT * FROM STAFF WHERE STAFFID = :staff_id";
                    //进行操作
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && Convert.ToInt32(result) == 0)
                        {
                            string create_query = @"INSERT INTO STAFF
                                                  VALUES (STAFF_ID = :staff_id ,
                                                          BRANCH_ID = :branch_id ,
                                                          NAME = :name ,
                                                          ADDRESS = :address ,
                                                          PHONENUMBER = :phone_number ,
                                                          SALARY = :salary ,
                                                          SYSTEM_KEY = :system_key ,
                                                          DEPARTMENT = :department)";
                            using (OracleCommand create_command = new OracleCommand(create_query, connection))
                            {
                                //添加参数
                                create_command.Parameters.Add(new OracleParameter(":staff_id", Staff_ID));
                                create_command.Parameters.Add(new OracleParameter(":branch_id", Branch_ID));
                                create_command.Parameters.Add(new OracleParameter(":name", Name));
                                create_command.Parameters.Add(new OracleParameter(":address", Address));
                                create_command.Parameters.Add(new OracleParameter(":phone_number", Phone_Number));
                                create_command.Parameters.Add(new OracleParameter(":salary", Salary));
                                create_command.Parameters.Add(new OracleParameter(":system_key", PasswordHandler.HashPassword(System_Key)));
                                create_command.Parameters.Add(new OracleParameter(":department", Department));
                                //执行语句
                                create_command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("该员工已存在，请勿重复添加");
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
        public static void UpdateHR(string Staff_ID, string Branch_ID, string Name, string Address, string Phone_Number, float Salary, string Department)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //SQL语句
                    string query = "SELECT * FROM STAFF WHERE STAFFID = :staff_id";
                    //进行操作
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && Convert.ToInt32(result) == 0)
                        {
                            MessageBox.Show("该员工不存在，无法修改");
                        }
                        else
                        {
                            string create_query = @"UPDATE STAFF
                                                  SET (   BRANCH_ID = :branch_id ,
                                                          NAME = :name ,
                                                          ADDRESS = :address ,
                                                          PHONENUMBER = :phone_number ,
                                                          SALARY = :salary ,
                                                          DEPARTMENT = :department)
                                                  WHERE STAFF_ID = :staff_id";
                            using (OracleCommand create_command = new OracleCommand(create_query, connection))
                            {
                                //添加参数
                                create_command.Parameters.Add(new OracleParameter(":staff_id", Staff_ID));
                                create_command.Parameters.Add(new OracleParameter(":branch_id", Branch_ID));
                                create_command.Parameters.Add(new OracleParameter(":name", Name));
                                create_command.Parameters.Add(new OracleParameter(":address", Address));
                                create_command.Parameters.Add(new OracleParameter(":phone_number", Phone_Number));
                                create_command.Parameters.Add(new OracleParameter(":salary", Salary));
                                create_command.Parameters.Add(new OracleParameter(":department", Department));
                                //执行语句
                                create_command.ExecuteNonQuery();
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

        //删除员工信息
        public static void DeleteHR(string Staff_ID)
        {

        }
    }
}
