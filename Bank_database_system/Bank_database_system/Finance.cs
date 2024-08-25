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
                        command.Parameters.Add(new OracleParameter(":branch_ID", OracleDbType.Varchar2)).Value = branch_ID;

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
         *以分页方式查询所有支行信息，便于显示
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

        /********************************************************************* 
         *以分页方式查询本银行所有流水（存款与取款）
         *参数：
         *string branch_ID     本行支行ID
         *int PageNumber       当前页码
         *int PageSize         页大小
         *返回查询结果表
         **********************************************************************/
        public static DataTable Selcet_All_Transaction(string branch_ID, int PageNumber, int PageSize)
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
                                                SELECT * 
                                                FROM TRANSACTION_HISTORY
                                                WHERE (TRANSACTION_COMMENT = :TYPE_1 
                                                    OR TRANSACTION_COMMENT = :TYPE_2)
                                                AND CREDIT_CARD_NUMBERS IN 
                                                (SELECT CREDIT_CARD_NUMBERS 
                                                 FROM ACCOUNT
                                                 WHERE BRANCH_ID = :branch_ID)
                                              ) a
                                              WHERE ROWNUM <= :MaxRow
                                            )
                                            WHERE rnum >= :MinRow";

                    using (OracleCommand command = new OracleCommand(query_string, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":TYPE_1", OracleDbType.Varchar2)).Value = "存款";
                        command.Parameters.Add(new OracleParameter(":TYPE_2", OracleDbType.Varchar2)).Value = "取款";
                        command.Parameters.Add(new OracleParameter(":branch_ID", OracleDbType.Varchar2)).Value = branch_ID;
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
         *得到银行某段时间的总支出（取款）
         *参数：
         *string branch_ID     本行支行ID
         *DateTime BeginDate   起始日期
         *DateTime EndDate     终止日期
         *返回这段时间的总支出（RMB）
         **********************************************************************/
        public static decimal GetExpenses(string branch_ID, DateTime BeginDate, DateTime EndDate)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query_string = @"SELECT SUM(AMOUNT) 
                                            FROM TRANSACTION_HISTORY
                                            WHERE TRANSACTION_TIME >= :BeginDate
                                            AND TRANSACTION_TIME <= :EndDate
                                            AND TRANSACTION_COMMENT = :TYPE
                                            AND CREDIT_CARD_NUMBERS IN 
                                            (SELECT CREDIT_CARD_NUMBERS 
                                             FROM ACCOUNT
                                             WHERE BRANCH_ID = :branch_ID)";

                    using (OracleCommand command = new OracleCommand(query_string, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":BeginDate", OracleDbType.Date)).Value = BeginDate;
                        command.Parameters.Add(new OracleParameter(":EndDate", OracleDbType.Date)).Value = EndDate;
                        command.Parameters.Add(new OracleParameter(":TYPE", OracleDbType.Varchar2)).Value = "取款";
                        command.Parameters.Add(new OracleParameter(":branch_ID", OracleDbType.Varchar2)).Value = branch_ID;

                        decimal total = 0;
                        object result = command.ExecuteScalar();
                        if(result != DBNull.Value)
                        {
                            total = Convert.ToDecimal(result);
                        }
                        return total;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ErrorMessage: " + ex.Message);
                return -1; //出错返回-1
            }
        }

        /********************************************************************* 
         *得到银行某段时间的总收入（存款）
         *参数：
         *string branch_ID     本行支行ID
         *DateTime BeginDate   起始日期
         *DateTime EndDate     终止日期
         *返回这段时间的总收入（RMB）
         **********************************************************************/
        public static decimal GetIncome(string branch_ID, DateTime BeginDate, DateTime EndDate)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query_string = @"SELECT SUM(AMOUNT) 
                                            FROM TRANSACTION_HISTORY
                                            WHERE TRANSACTION_TIME >= :BeginDate
                                            AND TRANSACTION_TIME <= :EndDate
                                            AND TRANSACTION_COMMENT = :TYPE
                                            AND CREDIT_CARD_NUMBERS IN 
                                            (SELECT CREDIT_CARD_NUMBERS 
                                             FROM ACCOUNT
                                             WHERE BRANCH_ID = :branch_ID)";

                    using (OracleCommand command = new OracleCommand(query_string, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":BeginDate", OracleDbType.Date)).Value = BeginDate;
                        command.Parameters.Add(new OracleParameter(":EndDate", OracleDbType.Date)).Value = EndDate;
                        command.Parameters.Add(new OracleParameter(":TYPE", OracleDbType.Varchar2)).Value = "存款";
                        command.Parameters.Add(new OracleParameter(":branch_ID", OracleDbType.Varchar2)).Value = branch_ID;

                        decimal total = 0;
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            total = Convert.ToDecimal(result);
                        }
                        return total;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ErrorMessage: " + ex.Message);
                return -1; //出错返回-1
            }
        }
    }
}
