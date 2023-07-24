List<string> TaskList = new List<string>();
int menuOption = 0;

do
{
    menuOption = ShowMainMenu();
    if ((Menu)menuOption == Menu.Add)
    {
        AddTask();
    }
    else if ((Menu)menuOption == Menu.Remove)
    {
        RemoveTask();
    }
    else if ((Menu)menuOption == Menu.List)
    {
        ShowTaskList();
    }
} while ((Menu)menuOption != Menu.Exit);

/// <summary>
/// Show the main menu
/// </summary>
/// <returns>Returns menuOption indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    // Read taskIndex
    string taskIndex = Console.ReadLine();
    return Convert.ToInt32(taskIndex);
}

void RemoveTask()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        // Show current taks
        ListTasks();

        string taskIndex = Console.ReadLine();
        // Remove one position
        int indexToRemove = Convert.ToInt32(taskIndex) - 1;

        if (indexToRemove <= TaskList.Count - 1 && indexToRemove >= 0)
        {
            if ((indexToRemove > -1) || (TaskList.Count > 0))
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
        else
        {
            Console.WriteLine("El número de tarea seleccionado no es válido.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea.");
    }
}

void AddTask()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToAdd = Console.ReadLine();

        if (!string.IsNullOrEmpty(taskToAdd))
        {
            TaskList.Add(taskToAdd);
            Console.WriteLine("Tarea registrada");
        }
        else
        {
            Console.WriteLine("La tarea no puede estar vacía.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar ingresar la tarea.");
    }
}

void ShowTaskList()
{
    if (TaskList?.Count > 0)
    {
        ListTasks();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void ListTasks()
{
    Console.WriteLine("----------------------------------------");

    var indexTask = 0;
    TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));

    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
