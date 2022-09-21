namespace EventProcessor.Types;

public class Account
{
    public int Id { get; set; }
    public List<Holding> Holdings { get; set; } = new List<Holding>();
    public decimal CashOverdraftLimit { get; set; }
    public decimal MaxCashHolding { get; set; } = 80000;
}


