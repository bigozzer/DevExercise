using EventProcessor.Stores;
using EventProcessor.Types;

namespace EventProcessor.Services;
public partial class EventProcessorService
{

    public ProcessEventResult ProcessEvent(ProcessEventRequest request)
    {

        var store = new AccountDataStore();
        var account = store.GetAccount(request.AccountId);
        var result = new ProcessEventResult();

        if (account == null)
        {
            result.Success = false;
            result.Message = "Account Doesnt Exist";
            return result;
        }

        if (request.Type == EventType.CashWithdrawal)
        {
            if (!account.Holdings.Any(x => x.AssetIdentifier == request.AssetIdentifier))
            {
                result.Success = false;
                result.Message = "Currency Not Currently Held";
                return result;
            }
            var holding = account.Holdings.Single(x => x.AssetIdentifier == request.AssetIdentifier);
            if ((holding.Balance + account.CashOverdraftLimit) < request.Amount)
            {
                result.Success = false;
                result.Message = $"Balance Too Low, Current Balance : {holding.Balance} Requested Withdrawal {request.Amount} Overdraft Limit {account.CashOverdraftLimit}";
                return result;
            }

            holding.Balance -= request.Amount;
            store.UpdateAccount(account);
            result.Success = true;
            return result;
        }

        if (request.Type == EventType.CashAddition)
        {
            if (!account.Holdings.Any(x => x.AssetIdentifier == request.AssetIdentifier))
                account.Holdings.Add(new Holding(request.AssetIdentifier));
            var holding = account.Holdings.Single(x => x.AssetIdentifier == request.AssetIdentifier);

            if ((holding.Balance + request.Amount) > account.MaxCashHolding)
            {
                result.Success = false;
                result.Message = $"Cash Addition Takes You Over Maximum Balance Of {account.MaxCashHolding}";
                return result;
            }

            holding.Balance -= request.Amount;
            store.UpdateAccount(account);
            result.Success = true;
            return result;
        }


        if (request.Type == EventType.StockWithdrawal)
        {
            if (!account.Holdings.Any(x => x.AssetIdentifier == request.AssetIdentifier))
            {
                result.Success = false;
                result.Message = "Asset Not Currently Held";
                return result;
            }
            var holding = account.Holdings.Single(x => x.AssetIdentifier == request.AssetIdentifier);
            if ((holding.Balance) < request.Amount)
            {
                result.Success = false;
                result.Message = $"Balance Too Low, Current Balance : {holding.Balance} Requested Withdrawal {request.Amount}";
                return result;
            }

            holding.Balance -= request.Amount;
            store.UpdateAccount(account);
            result.Success = true;
            return result;
        }

        if (request.Type == EventType.StockAddition)
        {
            if (!account.Holdings.Any(x => x.AssetIdentifier == request.AssetIdentifier))
                account.Holdings.Add(new Holding(request.AssetIdentifier));
            var holding = account.Holdings.Single(x => x.AssetIdentifier == request.AssetIdentifier);
            holding.Balance -= request.Amount;
            store.UpdateAccount(account);
            result.Success = true;
            return result;
        }

        return result;

    }


}
