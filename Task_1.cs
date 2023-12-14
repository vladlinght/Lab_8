using System;

public sealed class ConfigurationManager
{
    private static ConfigurationManager instance;
    private static readonly object lockObject = new object();

    public string LogLevel { get; set; }
    public string DatabaseConnectionString { get; set; }

    private ConfigurationManager()
    {
        LogLevel = "Info";
        DatabaseConnectionString = "DefaultConnection";
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
            }
            return instance;
        }
    }

    public void PrintConfiguration()
    {
        Console.WriteLine($"Configuration Settings:");
        Console.WriteLine($"LogLevel: {LogLevel}");
        Console.WriteLine($"DatabaseConnectionString: {DatabaseConnectionString}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;
        configManager.PrintConfiguration();

        Console.WriteLine("Changing configuration...");
        configManager.LogLevel = "Debug";
        configManager.DatabaseConnectionString = "UpdatedConnection";
        configManager.PrintConfiguration();

        Console.WriteLine("Creating a new reference to ConfigurationManager...");
        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        anotherConfigManager.PrintConfiguration();

        Console.WriteLine("The configuration is the same for both references.");
    }
}