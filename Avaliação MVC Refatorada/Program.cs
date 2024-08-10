namespace Prova {
    public class Program {
        public static List<Task> items = new List<Task>();
        static void Main (){
            int op = 0;
            do{
                Console.WriteLine("[1]To register a task");
                Console.WriteLine("[2]To display the tasks registered");
                Console.WriteLine("[3]To modify a task");
                Console.WriteLine("[4]To delete a task");
                Console.WriteLine("[5]To exit the program");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op){
                    case 1:
                        ViewTask.CreateTask(); 
                        break;
                    case 2:
                        Console.Clear();
                        ViewTask.ListTask();
                        ViewTask.PressAKey();
                        break;
                    case 3:
                        ViewTask.UpdateTask();
                        break;
                    case 4:
                        ViewTask.DeleteTask();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid command, try again using a valid one");
                        break;
                }
            }while (op !=5);
        }
    }
}
