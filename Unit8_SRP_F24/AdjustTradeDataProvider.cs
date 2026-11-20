using System.Runtime.CompilerServices;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;
public class AdjustTradeDataProvider : ITradeDataProvider
{
    private readonly ILogger logger;
    private readonly ITradeDataProvider tradeDataProvider;

    public AdjustTradeDataProvider(ITradeDataProvider tradeDataProvider, ILogger Logger)
    {
        this.tradeDataProvider = tradeDataProvider;
        this.logger = Logger;
    }
    public async Task<IEnumerable<string>> ReadTradeDataAsync()
    {
        logger.LogMessage("Adjusting trade data");
        var tradeData = await tradeDataProvider.ReadTradeDataAsync();
        return tradeData.Select(td => td.Replace("GBP", "EUR"));
    }
}