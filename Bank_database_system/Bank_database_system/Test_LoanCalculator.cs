//class Test_LoanCalculator
//{
//    static void Main()
//    {
//        LoanCalculator calculator = new LoanCalculator();

//        decimal principal = 110000; // 贷款总额
//        int years = 5; // 贷款年数
//        LoanCalculator.RepaymentType repaymentType = LoanCalculator.RepaymentType.EqualPrincipal;

//        // 计算每月还款金额
//        decimal[] monthlyRepayments = calculator.CalculateMonthlyRepayment(principal, years, repaymentType);

//        Console.WriteLine($"贷款总额: {principal}");
//        Console.WriteLine($"贷款年数: {years}");
//        Console.WriteLine($"还款方式: {repaymentType}");
//        Console.WriteLine("每月还款金额: ");
//        for (int i = 0; i < monthlyRepayments.Length; i++)
//        {
//            Console.WriteLine($"第{i + 1}个月: {monthlyRepayments[i]:F2}");
//        }
//    }
//}