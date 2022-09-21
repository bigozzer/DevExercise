using EventProcessor.Services;
using Xunit;
using EventProcessor.Types;
using EventProcessor.Stores;

namespace EventProcessor.Test;

public class EventProcessorServiceTests
{
    [Fact]
    public void DepositOfTenGbpReturnsSuccess()
    {
        //Arrange
        var service = new EventProcessorService();

        var request = new ProcessEventRequest()
        {
            AccountId = 1,
            AssetIdentifier = "GBP",
            Amount = 10,            
            Type = EventType.CashAddition
        };

        //Act
        var result = service.ProcessEvent(request);

        //Assert
        Assert.Equal(true,result.Success);
        
    }
}