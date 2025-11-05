public class Transaction
{
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public decimal Amount { get; set; }

    public Transaction(string from, string to, decimal amount)
    {
        FromAddress = from;
        ToAddress = to;
        Amount = amount;
    }
}
