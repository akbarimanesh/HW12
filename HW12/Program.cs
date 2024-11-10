﻿using HW12.Entity;
using ConsoleTables;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using HW12.Service;
using System.Data;
TaskService taskService = new TaskService();
TaskUser taskUser = new TaskUser();
int option;
while (true)
{
    Console.Clear();
    var task = taskService.GetAllT();
    ConsoleTable.From<TaskUser>(task.OrderBy(t => t.Priority))
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    ColoredConsole.WriteLine($"{Yellow("***********************************************************************************************************")}");
   
    ColoredConsole.WriteLine($"{White("***********************************Press a key to perform a task operation.********************************")}");
    Console.ReadKey();
    try
    {

        do
        {


            Console.Clear();
            ColoredConsole.WriteLine($"{White("1:New Task ")}");
            ColoredConsole.WriteLine($"{White("2:Edit Task details ")}");
            ColoredConsole.WriteLine($"{White("3:Edit Task State")}");
            ColoredConsole.WriteLine($"{White("4:Search Task ")}");
            ColoredConsole.WriteLine($"{White("5:Deleted product ")}");
            ColoredConsole.WriteLine($"{White("6:Show Task list ")}");
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.Write($"{Blue("please Enter your option :")}");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    EditTask();
                    break;
                case 3:
                    EditState();
                    break;
                case 4:
                    Searchtask();
                    break;
                case 5:
                    Deleteproduct();
                    break;
                case 6:
                    ShowAllTask();
                    break;
                default:
                    break;
            }


        } while (option < 7);

    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an option.")}");

    }
    Console.ReadKey();

}
void CreateTask()
{
    try
    {
        Console.Clear();
        ColoredConsole.Write($"{Blue("Please Enter Title:")}");
        string title = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Description :")}");
        string description = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Priority :")}");
        int priority = int.Parse(Console.ReadLine());
        ColoredConsole.Write($"{Blue("Please Enter TimeToDone :")}");
        DateTime timeToDone = DateTime.Parse(Console.ReadLine());
        taskUser.Title = title;
        taskUser.Description = description;
        taskUser.Priority = priority;
        taskUser.TimeToDone = timeToDone;
        var result = taskService.CreateT(taskUser);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");


            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Please complete the form.")}");

        Console.ReadKey();



    }


    Console.ReadKey();
}



void EditTask()
{
    try
    {
        Console.Clear();
        ShowAllTask();
        ColoredConsole.WriteLine($"{Yellow("*********************************************")}");
        ColoredConsole.Write($"{Blue("Please Enter Id :")}");
        int id = int.Parse(Console.ReadLine());
        ColoredConsole.Write($"{Blue("Please Enter Title :")}");
        string title = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Description :")}");
        string description = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Priority :")}");
        int priority = int.Parse(Console.ReadLine());
        ColoredConsole.Write($"{Blue("Please Enter TimeToDone :")}");
        DateTime timeToDone = DateTime.Parse(Console.ReadLine());
        taskUser.Id = id;
        taskUser.Title = title;
        taskUser.Description = description;
        taskUser.Priority = priority;
        taskUser.TimeToDone = timeToDone;
        var result = taskService.UpdateT(taskUser);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");

            Console.ReadKey();
        }

    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an product.")}");

    }

    Console.ReadKey();
}

void EditState()
{

    try
    {
        Console.Clear();
        ShowAllTask();
        ColoredConsole.WriteLine($"{Yellow("*********************************************")}");
        ColoredConsole.Write($"{Blue("Please Enter Id :")}");
        int id = int.Parse(Console.ReadLine());
        ColoredConsole.Write($"{Blue("Please Enter State 1:Notdone 2:Inprogress 3:Done 4:Cancceled  :")}");
       State state =(State)Enum.Parse(typeof(State),Console.ReadLine());
       
        taskUser.Id = id;
        taskUser.State = state;
       
        var result = taskService.UpdateS(taskUser,id);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");

            Console.ReadKey();
        }

    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an product.")}");

    }

    Console.ReadKey();
}
void Searchtask()
{
    try
    {
        Console.Clear();

        ColoredConsole.Write($"{Blue("Please Enter Title :")}");
        string title = Console.ReadLine();
        ColoredConsole.WriteLine($"{Yellow("****************************************************")}");
        var task1 = taskService.SearchT(title);
        if (task1 != null)
        {

            Console.WriteLine($"Id= {task1.Id} / Title= {task1.Title} / Description={task1.Description} / Priority={task1.Priority} / TimeToDone={task1.TimeToDone} / State={task1.State}  ");
        }
        else
            ColoredConsole.WriteLine($"{Red("Task does not exist")}");

    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an product.")}");
    }
    Console.ReadKey();
}
void Deleteproduct()
{
    try
    {
        Console.Clear();
        ShowAllTask();
        ColoredConsole.WriteLine($"{Yellow("********************************************")}");
        Console.Write("Please Enter Id :");
        int id = int.Parse(Console.ReadLine());
        var result = taskService.DeleteT(id);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {

            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");

            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {

        ColoredConsole.WriteLine($"{Red("Select an product.")}");
    }

    Console.ReadKey();
}
void ShowAllTask()
{
    Console.Clear();
    var task = taskService.GetAllT();
    ConsoleTable.From<TaskUser>(task.OrderBy(t => t.Priority))
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    Console.ReadKey();
}
void GetByIdT()
{
    try
    {
        Console.Clear();
        ShowAllTask();
        ColoredConsole.WriteLine($"{Yellow("****************************************************")}");
        Console.Write("Please Enter Id :");
        int id = int.Parse(Console.ReadLine());
        var task1 = taskService.GetT(id);
        if (task1 != null)
        {

            Console.WriteLine($"Id= {task1.Id} / Title= {task1.Title} / Description={task1.Description} / Priority={task1.Priority} / TimeToDone={task1.TimeToDone} / State={task1.State}  ");
        }
        else
            ColoredConsole.WriteLine($"{Red("Task does not exist")}");

    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an product.")}");
    }
    Console.ReadKey();
}