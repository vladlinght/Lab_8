using System;
using System.Collections.Generic;

abstract class Chart
{
    public abstract void Draw();
}

class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
    }
}

class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
    }
}

class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
    }
}

abstract class GraphFactory
{
    public abstract Chart CreateChart();
}

class LineChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new LineChart();
    }
}

class BarChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new BarChart();
    }
}

class PieChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of chart (Line/Bar/Pie):");
        string chartType = Console.ReadLine().ToLower();

        GraphFactory graphFactory = GetGraphFactory(chartType);

        if (graphFactory != null)
        {
            Chart chart = graphFactory.CreateChart();
            chart.Draw();
        }
        else
        {
            Console.WriteLine("Invalid chart type.");
        }
    }

    static GraphFactory GetGraphFactory(string chartType)
    {
        switch (chartType)
        {
            case "line":
                return new LineChartFactory();
            case "bar":
                return new BarChartFactory();
            case "pie":
                return new PieChartFactory();
            default:
                return null;
        }
    }
}