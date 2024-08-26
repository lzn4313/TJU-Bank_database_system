using Bank_database_system.业务部;

namespace Bank_database_system
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();          
            bool Restart=false;
            do
            {
                登录界面 login = new 登录界面();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.Cancel)
                    Restart = false;
                信息首页 homepage1 = new 信息首页();
                人事首页 homepage2 = new 人事首页();
                财务首页 homepage3 = new 财务首页();
                业务首页 homepage4 = new 业务首页();

                if (login.DialogResult == DialogResult.OK)
                {
                    Application.Run(homepage1);
                    if (homepage1.DialogResult == DialogResult.Cancel)
                        Restart = true;
                }
                else if (login.DialogResult == DialogResult.Yes)
                {
                    Application.Run(homepage2);
                    if (homepage2.DialogResult == DialogResult.Cancel)
                        Restart = true;
                }
                else if (login.DialogResult == DialogResult.No)
                {
                    Application.Run(homepage3);
                    if (homepage3.DialogResult == DialogResult.Cancel)
                        Restart = true;
                }
                else if (login.DialogResult == DialogResult.Continue)
                {
                    Application.Run(homepage4);
                    if (homepage4.DialogResult == DialogResult.Cancel)
                        Restart = true;
                }
                
                             
            } while (Restart == true);

        }
    }
}