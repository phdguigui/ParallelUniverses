class Program
{
    static async Task Main()
    {
        // Task.Run
        Console.WriteLine("Usando Task.Run:");
        var tarefa1 = Task.Run(() => Task.Delay(2000).ContinueWith(t => "Resultado 1"));
        var tarefa2 = Task.Run(() => Task.Delay(1500).ContinueWith(t => "Resultado 2"));
        Console.WriteLine(await tarefa1);
        Console.WriteLine(await tarefa2);

        // Task.WhenAll (com threads já executadas)
        Console.WriteLine("\nUsando Task.WhenAll:");
        // Cria a thread
        var todasTarefas = Task.WhenAll(tarefa1, tarefa2);
        Console.WriteLine("Depois de executar WhenAll");
        // Aguarda a thread terminar de ser executada
        await todasTarefas;
        Console.WriteLine("Todas as tarefas foram concluídas.");

        // Task.WhenAll (com threads novas)
        Console.WriteLine("\nUsando Task.WhenAll:");
        var todasTarefas2 = 
            Task.WhenAll(
                Task.Run(() => Task.Delay(1500).ContinueWith(t => "Resultado 1")), 
                Task.Run(() => Task.Delay(2000).ContinueWith(t => "Resultado 2")),
                Task.Run(() => Task.Delay(2500).ContinueWith(t => "Resultado 3"))
            );
        Console.WriteLine("Depois de executar WhenAll");
        await todasTarefas2;
        Console.WriteLine("Todas as tarefas foram concluídas.");

        // Task.WhenAny
        Console.WriteLine("\nUsando Task.WhenAny:");
        var primeiraFinalizada = await Task.WhenAny(
            Task.Run(() => Task.Delay(5000).ContinueWith(t => "Resultado 1")),
            Task.Run(() => Task.Delay(2000).ContinueWith(t => "Resultado 2")),
            Task.Run(() => Task.Delay(2500).ContinueWith(t => "Resultado 3")));
        Console.WriteLine($"Primeira tarefa finalizada: {primeiraFinalizada.Result}");
    }
}
