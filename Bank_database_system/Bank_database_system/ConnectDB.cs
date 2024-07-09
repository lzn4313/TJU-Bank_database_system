using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Bank_database_system
{
    internal class ConnectDB
    {
        OracleConnection oc; // 数据库连接对象

        // 连接数据库方法
        public OracleConnection Connect()
        {
            try
            {
                string str = "User Id=SYSTEM;Password=Tongji123456;Data Source=121.43.34.251:1521/orcl";
                oc = new OracleConnection(str);
                oc.Open(); // 打开数据库连接
                return oc;
            }
            catch (Exception ex)
            {
                // 显示自定义错误消息
                MessageBox.Show("连接失败，请检查网络后重新连接", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // 重新抛出异常以便调用者能够进一步处理
            }
        }

        // 执行一条SQL语句
        public OracleCommand Command(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, Connect());
            return cmd;
        }

        // 获取执行SQL语句后，数据库表中数据条数的更新数量
        public int Execute(string sql)
        {
            return Command(sql).ExecuteNonQuery();
        }

        // 读取数据库中的数据
        public OracleDataReader Read(string sql)
        {
            return Command(sql).ExecuteReader();
        }

        // 关闭数据库连接
        public void DBClose()
        {
            if (oc != null && oc.State == ConnectionState.Open)
            {
                oc.Close();
            }
        }
    }
}
