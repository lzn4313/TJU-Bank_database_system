//class Test_PasswordHandler
//{
//    static void Main()
//    {
//        // 测试密码加密
//        string originalPassword = "password123";
//        string hashedPassword = PasswordHandler.HashPassword(originalPassword);
//        Console.WriteLine("原始密码: " + originalPassword);
//        Console.WriteLine("加密后的密码: " + hashedPassword);

//        // 测试密码验证
//        bool isPasswordCorrect = PasswordHandler.VerifyPassword("password123", hashedPassword);
//        Console.WriteLine("密码验证结果: " + (isPasswordCorrect ? "正确" : "错误"));

//        bool isPasswordIncorrect = PasswordHandler.VerifyPassword("wrongpassword", hashedPassword);
//        Console.WriteLine("错误密码验证结果: " + (isPasswordIncorrect ? "正确" : "错误"));
//    }
//}