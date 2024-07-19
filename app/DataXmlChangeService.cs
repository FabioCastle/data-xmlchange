using Data_XML_Change_Core;

namespace Data_XML_Change_App;

public class DataXmlChangeService(IDataXmlChange DataXmlChange, IConfiguration Configuration, ILogger<DataXmlChangeService> Logger) : BackgroundService
{
    private readonly int POLLING_PERIOD = Configuration.GetValue<int>("Service:PollingPeriodInMilliseconds");

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DataXmlChange.ExecuteConversionAsync(stoppingToken);
            }
            catch (Exception e)
            {
                Logger.LogError("Error while converting XML data: {Message}\n{StackTrace}", e.Message, e.StackTrace);
            }

            await Task.Delay(POLLING_PERIOD, stoppingToken);
        }
    }
}