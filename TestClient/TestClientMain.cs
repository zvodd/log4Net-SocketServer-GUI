// See https://aka.ms/new-console-template for more information
using log4net;
using log4net.Config;
using System.Reflection;

string resourceName = "TestClient.log4net.config.xml";

ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
{
    if (stream == null)
    {
        Console.WriteLine("Resource not found: " + resourceName);
        return;
    }

    XmlConfigurator.Configure(stream);
}

while (true)
{
    Log("Hello, World!");
    Thread.Sleep(1000);
}

void Log(string message) => log.Info(message);