namespace EventProcessor.Types;

public class Holding
{
    public string AssetIdentifier { get; set; }
    public decimal Balance { get; set; }

    public Holding(string assetIdentifier)
    {
        AssetIdentifier = assetIdentifier;
        Balance = 0;
        
    }
}


