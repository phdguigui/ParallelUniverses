class Program
{
    static async Task Main()
    {
        Console.WriteLine($"Main está executando na thread ID: {Environment.CurrentManagedThreadId}");
        Console.WriteLine("Início do método Main");

        await ChamadaApiAsync();

        Console.WriteLine($"Main está agora executando na thread ID: {Environment.CurrentManagedThreadId}");
        Console.WriteLine("Fim do método Main");
    }

    static async Task ChamadaApiAsync()
    {
        Console.WriteLine($"ChamadaApiAsync está executando na thread ID: {Environment.CurrentManagedThreadId}");

        using HttpClient client = new();
        try
        {
            Console.WriteLine("Iniciando a chamada da API...");

            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Chamada da API concluída com sucesso!");
                Console.WriteLine("Dados recebidos: ");
                Console.WriteLine(responseData);
                Console.WriteLine($"ChamadaApiAsync está agora executando na thread ID: {Environment.CurrentManagedThreadId}");
            }
            else
            {
                Console.WriteLine($"Erro na chamada da API. Código de status: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao tentar fazer a chamada da API: {ex.Message}");
        }
    }
}
