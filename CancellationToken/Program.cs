class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        Console.WriteLine($"Main está executando na thread ID: {Environment.CurrentManagedThreadId}");

        var tarefa = Task.Run(() => TarefaLonga(token), token);
        Console.WriteLine("Task executada");

        await Task.Delay(3000);
        cts.Cancel();

        try
        {
            await tarefa;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("A tarefa foi cancelada.");
        }
    }

    static async Task TarefaLonga(CancellationToken token)
    {
        Console.WriteLine($"TarefaLonga está executando na thread ID: {Environment.CurrentManagedThreadId}");

        for (int i = 1; i <= 10; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancelando a tarefa...");
                throw new OperationCanceledException();
            }

            Console.WriteLine($"Processando {i}...");
            await Task.Delay(1000, token);
        }
    }
}
