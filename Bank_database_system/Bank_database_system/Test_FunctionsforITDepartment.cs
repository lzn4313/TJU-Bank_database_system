//using System;
//using System.Data;
//using Oracle.ManagedDataAccess.Client;

//class Test_FunctionsforITDepartment
//{
//    static void Main()
//    {
//        // 测试添加支行信息
//        string newBranchId = "B001";
//        string newBranchName = "测试支行";
//        string newBranchAddress = "测试地址";
//        string newBranchPhoneNumber = "123456789";

//        bool success = FunctionsforITDepartment.AddBranch(newBranchId, newBranchName, newBranchAddress, newBranchPhoneNumber);
//        Console.WriteLine(success ? "支行信息添加成功。" : "支行信息添加失败。");



//        // 测试获取员工信息
//        DataTable employees = FunctionsforITDepartment.GetStaff(null, null, null, null, 1, 10);

//        if (employees.Rows.Count == 0)
//        {
//            Console.WriteLine("没有更多的记录了。");
//        }
//        else
//        {
//            foreach (DataRow row in employees.Rows)
//            {
//                Console.WriteLine("员工工号: " + row["STAFF_ID"]);
//                Console.WriteLine("工作支行ID: " + row["BRANCH_ID"]);
//                Console.WriteLine("姓名: " + row["NAME"]);
//                Console.WriteLine("住址: " + row["ADDRESS"]);
//                Console.WriteLine("电话: " + row["PHONENUMBER"]);
//                Console.WriteLine("工资: " + row["SALARY"]);
//                Console.WriteLine("系统密码: " + row["SYSTEM_KEY"]);
//                Console.WriteLine("部门: " + row["DEPARTMENT"]);
//                Console.WriteLine();
//            }
//        }



//        // 测试修改支行信息
//        string updateBranchId = "B001";
//        string updateBranchName = "测试支行";
//        string updateBranchAddress = "测试地址";
//        string updateBranchPhoneNumber = "111111111";

//        bool updateSuccess = FunctionsforITDepartment.UpdateBranch(updateBranchId, updateBranchName, updateBranchAddress, updateBranchPhoneNumber);
//        Console.WriteLine(updateSuccess ? "支行信息更新成功。" : "支行信息更新失败。");



//        // 测试获取支行信息
//        string branchId = null;
//        string branchName = null;
//        string branchAddress = null;
//        string branchPhoneNumber = null;

//        int pageSize = 10;
//        int pageNumber = 1;

//        DataTable branches = FunctionsforITDepartment.GetBranch(branchId, branchName, branchAddress, branchPhoneNumber, pageNumber, pageSize);

//        if (branches.Rows.Count == 0)
//        {
//            Console.WriteLine("没有更多支行记录。");
//        }
//        else
//        { }
//        foreach (DataRow row in branches.Rows)
//        {
//            Console.WriteLine("支行ID: " + row["BRANCH_ID"]);
//            Console.WriteLine("支行名称: " + row["BRANCH_NAME"]);
//            Console.WriteLine("支行地址: " + row["BRANCH_ADDRESS"]);
//            Console.WriteLine("支行电话号码: " + row["BRANCH_PHONENUMBER"]);
//            Console.WriteLine();
//        }



//        // 测试重置密码
//        string staffIdToReset = "500"; // 替换为要重置密码的员工工号
//        bool resetSuccess = FunctionsforITDepartment.ResetPassword(staffIdToReset);
//        Console.WriteLine(resetSuccess ? "密码重置成功。" : "密码重置失败。");

//        // 验证密码是否正确
//        DataTable staffTable = FunctionsforITDepartment.GetStaff(staffIdToReset, null, null, null, 1, 1);
//        if (staffTable.Rows.Count > 0)
//        {
//            string storedHashedPassword = staffTable.Rows[0]["SYSTEM_KEY"].ToString();
//            bool isPasswordCorrect = PasswordHandler.VerifyPassword("123456", storedHashedPassword);
//            Console.WriteLine("验证重置后的密码: " + (isPasswordCorrect ? "正确" : "错误"));
//        }
//        else
//        {
//            Console.WriteLine("未找到对应员工记录。");
//        }



//        // 测试查询操作记录
//        string staffId = "500";
//        string operateKind = "1";
//        DateTime? startTime = new DateTime(2024, 1, 1); // 起始时间
//        DateTime? endTime = new DateTime(2024, 12, 31); // 结束时间


//        DataTable operateRecords = FunctionsforITDepartment.GetOperateRecords(staffId, operateKind, startTime, endTime, pageNumber, pageSize);

//        if (operateRecords.Rows.Count > 0)
//        {
//            foreach (DataRow row in operateRecords.Rows)
//            {
//                Console.WriteLine("操作ID: " + row["OPERATE_ID"]);
//                Console.WriteLine("员工ID: " + row["STAFF_ID"]);
//                Console.WriteLine("操作类型: " + row["OPERATE_KIND"]);
//                Console.WriteLine("操作内容: " + row["OPERATE_CONTENT"]);
//                Console.WriteLine("操作时间: " + row["OPERATE_TIME"]);
//                Console.WriteLine("操作IP: " + row["OPERATE_IP"]);
//                Console.WriteLine("贷款ID: " + row["LOAN_ID"]);
//                Console.WriteLine("存款ID: " + row["DEPOSIT_ID"]);
//                Console.WriteLine("保险箱租用ID: " + row["HIRE_ID"]);
//                Console.WriteLine("交易ID: " + row["TRANSACTION_ID"]);
//                Console.WriteLine();
//            }
//        }
//        else
//        {
//            Console.WriteLine("没有更多记录。");
//        }







//    }
//}
