using Data_XML_Change_App;
using Data_XML_Change_Core;

var builder = Host.CreateApplicationBuilder(args);
// builder.
// builder.Host.UseWindowsService();

builder.Services.AddDataXmlChange(builder.Configuration);
builder.Services.AddHostedService<DataXmlChangeService>();

var logFile = builder.Configuration.GetValue<string>("Service:LogFile") ?? "Logs/data-xmlchange-{Date}.log";
builder.Logging.AddFile(logFile);

var host = builder.Build();
host.Run();