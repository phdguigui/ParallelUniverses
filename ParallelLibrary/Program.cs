using System.Runtime.InteropServices;

partial class Program
{
    [LibraryImport("kernel32.dll")]
    public static partial uint GetCurrentProcessorNumber();

    static void Main()
    {
        Console.WriteLine($"Número de CPUs disponíveis: {Environment.ProcessorCount}");

        var itens = new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        Parallel.ForEach(itens, item =>
        {
            uint cpuId = GetCurrentProcessorNumber();
            Console.WriteLine($"Processando {item} na thread {Environment.CurrentManagedThreadId} (CPU {cpuId})");
            Task.Delay(1000).Wait();
        });
    }
}
