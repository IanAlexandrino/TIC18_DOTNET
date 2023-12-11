class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Sistema de Gerenciamento de Tarefas");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Tarefas Pendentes");
            Console.WriteLine("3. Listar Tarefas Concluídas");
            Console.WriteLine("4. Marcar Tarefa como Concluída");
            Console.WriteLine("5. Excluir Tarefa");
            Console.WriteLine("6. Pesquisar Tarefa");
            Console.WriteLine("7. Estatísticas");
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateTask();
                        break;
                    case 2:
                        ListPendingTasks();
                        break;
                    case 3:
                        ListCompletedTasks();
                        break;
                    case 4:
                        MarkTaskAsCompleted();
                        break;
                    case 5:
                        DeleteTask();
                        break;
                    case 6:
                        SearchTask();
                        break;
                    case 7:
                        DisplayStatistics();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine();
        }
    }

    static void CreateTask()
    {
        Console.WriteLine("Criar Tarefa");
        Console.Write("Título da Tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Descrição da Tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Data de Vencimento (dd/mm/yyyy): ");
        DateTime dueDate;
        if (DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            tasks.Add(new Task(title, description, dueDate));
            Console.WriteLine("Tarefa criada com sucesso.");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. A tarefa não foi criada.");
        }
    }

    static void ListPendingTasks()
    {
        Console.WriteLine("Tarefas Pendentes:");
        var pendingTasks = tasks.Where(t => !t.Completed);
        DisplayTasks(pendingTasks);
    }

    static void ListCompletedTasks()
    {
        Console.WriteLine("Tarefas Concluídas:");
        var completedTasks = tasks.Where(t => t.Completed);
        DisplayTasks(completedTasks);
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Digite o ID da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Completed = true;
                Console.WriteLine("Tarefa marcada como concluída com sucesso.");
            }
            else
            {
                Console.WriteLine("ID de tarefa inválido.");
            }
        }
        else
        {
            Console.WriteLine("ID de tarefa inválido.");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Digite o ID da tarefa a ser excluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Tarefa excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("ID de tarefa inválido.");
            }
        }
        else
        {
            Console.WriteLine("ID de tarefa inválido.");
        }
    }

    static void SearchTask()
    {
        Console.Write("Digite uma palavra-chave para a pesquisa: ");
        string keyword = Console.ReadLine().ToLower();

        var result = tasks.Where(t => t.Title.ToLower().Contains(keyword) || t.Description.ToLower().Contains(keyword));
        DisplayTasks(result);
    }

    static void DisplayStatistics()
    {
        Console.WriteLine($"Número total de tarefas: {tasks.Count}");
        Console.WriteLine($"Número de tarefas concluídas: {tasks.Count(t => t.Completed)}");
        Console.WriteLine($"Número de tarefas pendentes: {tasks.Count(t => !t.Completed)}");

        if (tasks.Any())
        {
            Console.WriteLine($"Tarefa mais antiga: {tasks.Min(t => t.CreatedDate)}");
            Console.WriteLine($"Tarefa mais recente: {tasks.Max(t => t.CreatedDate)}");
        }
    }

    static void DisplayTasks(IEnumerable<Task> taskList)
    {
        foreach (var task in taskList)
        {
            Console.WriteLine($"ID: {task.Id}, Título: {task.Title}, Descrição: {task.Description}, Data de Vencimento: {task.DueDate}, Concluída: {task.Completed}");
        }
    }
}

class Task
{
    private static int idCounter = 1;

    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public bool Completed { get; set; }
    public DateTime CreatedDate { get; }

    public Task(string title, string description, DateTime dueDate)
    {
        Id = idCounter++;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Completed = false;
        CreatedDate = DateTime.Now;
    }
}