using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== START ===");

        Console.WriteLine("Calling with await:");
        await ShowWithAwait();

        Console.WriteLine("\nCalling without await:");
        ShowWithoutAwait();

        Console.WriteLine("\nCalling and blocking with .Result:");
        ShowWithResult();

        Console.WriteLine("\n=== END ===");

        Console.ReadLine(); // Keeps console open
    }

    static async Task<string> GetNameAsync()
    {
        Console.WriteLine($"[{Time()}]  GetNameAsync() started");
        await Task.Delay(3000);
        Console.WriteLine($"[{Time()}]  GetNameAsync() finished");
        return "Anitha";
    }

    static async Task ShowWithAwait()
    {
        var name = await GetNameAsync();
        Console.WriteLine($"[{Time()}] Name received (await): {name}");
    }

    static void ShowWithoutAwait()
    {
        var task = GetNameAsync();
        Console.WriteLine($"[{Time()}] Not waiting for GetNameAsync()");
    }

    static void ShowWithResult()
    {
        var name = GetNameAsync().Result;
        Console.WriteLine($"[{Time()}]  Name received (.Result): {name}");
    }

    static string Time() => DateTime.Now.ToString("HH:mm:ss.fff");
}
