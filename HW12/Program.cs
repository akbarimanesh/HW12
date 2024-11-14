using HW12.Entity;
using ConsoleTables;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using HW12.Service;
using System.Data;
using HW12;
using HW12.Dto;
using System.Threading.Tasks;
TaskService taskService = new TaskService();
UserService userService = new UserService();
TaskUser taskUser = new TaskUser();
User user = new User();
//
int option;
int option1;
while(true)
{
    try
    {
        do
        {

            Console.Clear();
            ColoredConsole.WriteLine($"{White("1:Login ")}");
            ColoredConsole.WriteLine($"{White("2:Register ")}");
            ColoredConsole.Write($"{Blue("please Enter your option : ")}");
            option1 = int.Parse(Console.ReadLine());
            switch (option1)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                default:
                    break;
            }


        } while (option1 < 3);
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an option.")}");

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
        var task1 = taskService.SearchT(MemoryDb.CurrentUser.Id,title);
        if (task1 != null)
        {

            ConsoleTable.From<GetTaskDto>(task1.OrderBy(t => t.Priority))
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Minimal);
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
    var task = taskService.GetAllT(MemoryDb.CurrentUser);
    ConsoleTable.From<GetTaskDto>(task.OrderBy(t => t.Priority))
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
void Login()
{
    try
    {
        Console.Clear();
        ColoredConsole.Write($"{Blue("Please Enter UserName:")}");
        string userName = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Password :")}");
        string password = Console.ReadLine();
        user.UserName = userName;
        user.Password = password;
        var result = userService.LoginU(user);

        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();
          
                Console.Clear();
                var task = taskService.GetAllT(MemoryDb.CurrentUser);
                ConsoleTable.From<GetTaskDto>(task.OrderBy(t => t.Priority))
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
                        ColoredConsole.WriteLine($"{White("7:Exit")}");
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
                            case 7:
                                logout();
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
                //Console.ReadKey();

            }

        
        else
        {

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
        taskUser.UserId = MemoryDb.CurrentUser.Id;
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
void Register()
{
    try
    {
        Console.Clear();
        ColoredConsole.Write($"{Blue("Please Enter UserName:")}");
        string userName = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Password :")}");
        string password = Console.ReadLine();

        user.UserName = userName;
        user.Password = password;
        var result =userService.RegisterU(user);
        
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");
            Console.ReadKey();
            Login();
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
void logout()

{
    MemoryDb.CurrentUser = null;
    ColoredConsole.WriteLine($"{Red("Logout.")}");

  
}