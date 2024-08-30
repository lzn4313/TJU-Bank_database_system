using System;
using Oracle.ManagedDataAccess.Client;

namespace LoanCalculator
{
    public static class LoanCalculator
    {
        private const string connectionString =
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=47.96.39.153)(PORT=1521))(CONNECT_DATA=(SID=orcl)));" +
            "User Id=system;Password=Tongji123456;";

        public enum RepaymentType
        {
            EqualPrincipalAndInterest, // 等额本息
            EqualPrincipal // 等额本金
        }

        public static decimal[] CalculateMonthlyRepayment(decimal principal, int years, RepaymentType repaymentType)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // 获取贷款利率
                    string query = @"
                SELECT INTEREST_RATE 
                FROM LOAN_INTEREST_RATE 
                WHERE :principal BETWEEN LOAN_AMOUNT_MIN AND LOAN_AMOUNT_MAX
                  AND :years BETWEEN LOAN_YEARS_MIN AND LOAN_YEARS_MAX";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("principal", principal));
                        command.Parameters.Add(new OracleParameter("years", years));

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            decimal annualInterestRate = Convert.ToDecimal(result);
                            decimal monthlyInterestRate = annualInterestRate / 12 / 100;
                            int totalMonths = years * 12;

                            decimal[] monthlyRepayments = new decimal[totalMonths];

                            if (repaymentType == RepaymentType.EqualPrincipalAndInterest)
                            {
                                // 等额本息还款法
                                decimal monthlyRepayment = principal * monthlyInterestRate * (decimal)Math.Pow(1 + (double)monthlyInterestRate, totalMonths) /
                                                        ((decimal)Math.Pow(1 + (double)monthlyInterestRate, totalMonths) - 1);

                                for (int i = 0; i < totalMonths; i++)
                                {
                                    monthlyRepayments[i] = monthlyRepayment;
                                }
                            }
                            else if (repaymentType == RepaymentType.EqualPrincipal)
                            {
                                // 等额本金还款法
                                decimal principalRepayment = principal / totalMonths;

                                for (int i = 0; i < totalMonths; i++)
                                {
                                    monthlyRepayments[i] = principalRepayment + (principal - principalRepayment * i) * monthlyInterestRate;
                                }
                            }

                            return monthlyRepayments;
                        }
                        else
                        {
                            throw new Exception("未找到合适的利率");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return new decimal[0];
            }
        }
    }
}