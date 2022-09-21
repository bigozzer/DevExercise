namespace EventProcessor.Types;

public class ProcessEventRequest
{
    public string AssetIdentifier { get; set; } = "";
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    public EventType Type { get; set; }
}


