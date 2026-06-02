namespace ZohoDeskIntegration.Models
{
    public class CustomerProfitability
    {
        public string CustomerName { get; set; }
        public int NumberOfCRs { get; set; }
        public double TotalCRValue { get; set; }
        public double CostIncurred { get; set; }
        public double ApprovedHours { get; set; }
        public double ActualHours { get; set; }
        public double Profit { get; set; }
        public double ProfitabilityPercentCost { get; set; }
        public double ProfitabilityPercentHours { get; set; }
    }
}
