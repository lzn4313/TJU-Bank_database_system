using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Drawing.Printing;

namespace Bank_database_system
{
    /*********************************************************
     * 
     *财务部门
     *
     *********************************************************/
    public static class Finance
    {
        private const string connectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));
                User Id=system;Password=Tongji123456;";

        /********************************************************************* 
         *通过支行ID查询支行信息
         *参数：
         *string branch_ID 支行ID
         *返回查询结果表
         **********************************************************************/
        public static DataTable Selcet_Branch_By_ID(string branch_ID)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query_string = @"SELECT * FROM BRANCH WHERE BRANCH_ID = :branch_ID";

                    using (OracleCommand command = new OracleCommand(query_string, connection))
                    {
                        command.Parameters.Add(new OracleParameter("branch_ID", string.IsNullOrEmpty(branch_ID) ? (object)DBNull.Value : branch_ID));

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
                Console.WriteLine("ErrorMessage: " + ex.Message);
                return new DataTable(); //出错返回空表
            }
        }

        /********************************************************************* 
         *以分页方式查询所有支行，便于显示
         *参数：
         *int PageNumber 当前页码
         *int PageSize   页大小
         *返回查询结果表
         **********************************************************************/
        public static DataTable Selcet_All_Branch(int PageNumber, int PageSize)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    int offset = (PageNumber - 1) * PageSize;//得到偏移量

                    string query_string = @"SELECT * FROM (
                                              SELECT a.*, ROWNUM rnum
                                              FROM (
                                                SELECT * FROM BRANCH
                                                ORDER BY BRANCH_ID
                                              ) a
                                              WHERE ROWNUM <= :MaxRow
                                            )
                                            WHERE rnum >= :MinRow";

                    using (OracleCommand command = new OracleCommand(query_string, connection))
                    {
                        command.Parameters.Add(new OracleParameter("MaxRow", offset + PageSize));
                        command.Parameters.Add(new OracleParameter("MinRow", offset));

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
                Console.WriteLine("ErrorMessage: " + ex.Message);
                return new DataTable(); //出错返回空表
            }
        }

        /********************************************************************* 
         *支行间资金调度（有疑问，待完成）
         *参数：
         *string my_branch_ID     本行支行ID
         *string target_branch_ID 目标银行支行ID
         *int amount              调度金额
         *返回查询结果表
         **********************************************************************/
        public static String Funds_Transport(string my_branch_ID, string targrt_branch_ID,int amount)
        {
            return "to_be_finished";
        }


    }
}
