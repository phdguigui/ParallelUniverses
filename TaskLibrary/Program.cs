class Program
{
    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("1. Task.Run()\n" +
                          "2. Task.WhenAll()\n" +
                          "3. Task.WhenAny()\n" +
                          "4. Sair\n");

            var option = Console.ReadKey()!;

            Console.Clear();

            switch (option.KeyChar)
            {
                case '1':
                    // Task.Run
                    Console.WriteLine("Usando Task.Run:");
                    var tarefa1 = Task.Run(() => Task.Delay(2000).ContinueWith(t => $"Resultado 1 - Thread: {Environment.CurrentManagedThreadId}"));
                    var tarefa2 = Task.Run(() => Task.Delay(1500).ContinueWith(t => $"Resultado 2 - Thread: {Environment.CurrentManagedThreadId}"));
                    Console.WriteLine(await tarefa1);
                    Console.WriteLine(await tarefa2);
                    break;
                case '2':
                    // Task.WhenAll
                    Console.WriteLine("Usando Task.WhenAll:");
                    var todasTarefas2 =
                        Task.WhenAll(
                            Task.Run(() => Task.Delay(1500).ContinueWith(t => "Resultado 1")),
                            Task.Run(() => Task.Delay(2000).ContinueWith(t => "Resultado 2")),
                            Task.Run(() => Task.Delay(2500).ContinueWith(t => "Resultado 3"))
                        );
                    Console.WriteLine("Depois de executar WhenAll");
                    await todasTarefas2;
                    Console.WriteLine("Todas as tarefas foram concluídas.");
                    break;
                case '3':
                    // Task.WhenAny
                    Console.WriteLine("Usando Task.WhenAny:");
                    var primeiraFinalizada = await Task.WhenAny(
                        Task.Run(() => Task.Delay(5000).ContinueWith(t => "Resultado 1")),
                        Task.Run(() => Task.Delay(2000).ContinueWith(t => "Resultado 2")),
                        Task.Run(() => Task.Delay(2500).ContinueWith(t => "Resultado 3")));
                    Console.WriteLine($"Primeira tarefa finalizada: {primeiraFinalizada.Result}");
                    break;
                case '4':
                default:
                    return;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
