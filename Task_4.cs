using System;
using System.Collections.Generic;

// Prototype
interface IDataTemplate
{
    IDataTemplate Clone();
}

// Concrete Prototypes
class CSVTemplate : IDataTemplate
{
    public string Header { get; set; }
    public string Data { get; set; }

    public IDataTemplate Clone()
    {
        return new CSVTemplate { Header = this.Header, Data = this.Data };
    }
}

class XMLTemplate : IDataTemplate
{
    public string RootElement { get; set; }
    public string Content { get; set; }

    public IDataTemplate Clone()
    {
        return new XMLTemplate { RootElement = this.RootElement, Content = this.Content };
    }
}

class JSONTemplate : IDataTemplate
{
    public string Fields { get; set; }
    public string Values { get; set; }

    public IDataTemplate Clone()
    {
        return new JSONTemplate { Fields = this.Fields, Values = this.Values };
    }
}

// Adapter
interface IDataConverter
{
    string ConvertData(IDataTemplate sourceTemplate, IDataTemplate targetTemplate);
}

// Concrete Adapters
class CSVToXMLAdapter : IDataConverter
{
    public string ConvertData(IDataTemplate sourceTemplate, IDataTemplate targetTemplate)
    {
        // Conversion logic from CSV to XML
        Console.WriteLine("Converting CSV to XML...");
        return $"Converted CSV to XML: {sourceTemplate.Header}, {sourceTemplate.Data} -> {targetTemplate.RootElement}, {targetTemplate.Content}";
    }
}

class JSONToXMLAdapter : IDataConverter
{
    public string ConvertData(IDataTemplate sourceTemplate, IDataTemplate targetTemplate)
    {
        // Conversion logic from JSON to XML
        Console.WriteLine("Converting JSON to XML...");
        return $"Converted JSON to XML: {sourceTemplate.Fields}, {sourceTemplate.Values} -> {targetTemplate.RootElement}, {targetTemplate.Content}";
    }
}

// Client Code
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the source data format (CSV/JSON):");
        string sourceFormat = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the target data format (XML/JSON):");
        string targetFormat = Console.ReadLine().ToLower();

        IDataTemplate sourceTemplate = GetTemplate(sourceFormat);
        IDataTemplate targetTemplate = GetTemplate(targetFormat);

        IDataConverter dataConverter = GetDataConverter(sourceFormat, targetFormat);

        if (sourceTemplate != null && targetTemplate != null && dataConverter != null)
        {
            string result = dataConverter.ConvertData(sourceTemplate, targetTemplate);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid data formats or conversion not supported.");
        }
    }

    static IDataTemplate GetTemplate(string format)
    {
        switch (format)
        {
            case "csv":
                return new CSVTemplate { Header = "Name,Age", Data = "John,25" };
            case "json":
                return new JSONTemplate { Fields = "Name,Age", Values = "John,25" };
            default:
                return null;
        }
    }

    static IDataConverter GetDataConverter(string sourceFormat, string targetFormat)
    {
        if (sourceFormat == "csv" && targetFormat == "xml")
        {
            return new CSVToXMLAdapter();
        }
        else if (sourceFormat == "json" && targetFormat == "xml")
        {
            return new JSONToXMLAdapter();
        }
        else
        {
            return null;
        }
    }
}