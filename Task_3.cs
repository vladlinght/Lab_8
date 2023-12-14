using System;

// Abstract Products
abstract class Screen { }
abstract class Processor { }
abstract class Camera { }

// Concrete Products
class AMOLED : Screen { }
class LCD : Screen { }

class Snapdragon : Processor { }
class Exynos : Processor { }

class DualCamera : Camera { }
class TripleCamera : Camera { }

// Abstract Factories
abstract class DeviceFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Concrete Factories
class SmartphoneFactory : DeviceFactory
{
    public override Screen CreateScreen()
    {
        return new AMOLED();
    }

    public override Processor CreateProcessor()
    {
        return new Snapdragon();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class TabletFactory : DeviceFactory
{
    public override Screen CreateScreen()
    {
        return new LCD();
    }

    public override Processor CreateProcessor()
    {
        return new Exynos();
    }

    public override Camera CreateCamera()
    {
        return new TripleCamera();
    }
}

// Client Code
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of device (Smartphone/Tablet):");
        string deviceType = Console.ReadLine().ToLower();

        DeviceFactory deviceFactory = GetDeviceFactory(deviceType);

        if (deviceFactory != null)
        {
            Screen screen = deviceFactory.CreateScreen();
            Processor processor = deviceFactory.CreateProcessor();
            Camera camera = deviceFactory.CreateCamera();

            Console.WriteLine($"Created {deviceType} with {screen.GetType().Name}, {processor.GetType().Name}, and {camera.GetType().Name}");
        }
        else
        {
            Console.WriteLine("Invalid device type.");
        }
    }

    static DeviceFactory GetDeviceFactory(string deviceType)
    {
        switch (deviceType)
        {
            case "smartphone":
                return new SmartphoneFactory();
            case "tablet":
                return new TabletFactory();
            default:
                return null;
        }
    }
}