namespace Prova {
    public class ViewTask {
        public static void CreateTask(){
            Console.WriteLine("Inform the task general info");
            Console.WriteLine("Type the name of the task you want to create");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Inform the date of the current task (MM/DD/YY)");
            string date = Console.ReadLine() ?? "";
            Console.WriteLine("Inform the time that the task need to be done(XX:YY)");
            string time = Console.ReadLine() ?? "";
            Console.WriteLine("Write a brief description of the task");
            string info = Console.ReadLine() ?? "";
            Boolean status = false;
            ConTask.CreateTask(name, date, time, info, status);
        }
        public static void ListTask(){
            Console.WriteLine("There are the following tasks registered on your list\n===Status===");
            List<Task> items = ConTask.ListTask();
            if (items.Count == 0){
                Console.WriteLine("There are no tasks registered");
            }else {
                foreach (Task item in items){
                    Console.WriteLine($"Name: {item.Name}\nDate: {item.Date}\nTime: {item.Time}\nInfo: {item.Info}\nStatus:{item.Status}");
                    ConTask.Status(item.Status);
                }
            }
        }
        public static void UpdateTask(){
            Console.WriteLine("Updating task");
            Console.WriteLine("Inform the index position you want to modify");
            int index = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine("Type the new name of this task");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Inform the new date of the current task (MM/DD/YY)");
            string date = Console.ReadLine() ?? "";
            Console.WriteLine("Inform the new time that the task need to be done(XX:YY)");
            string time = Console.ReadLine() ?? "";
            Console.WriteLine("Update the description of the task");
            string info = Console.ReadLine() ?? "";
            Console.WriteLine("Task concluded? [1]Yes [2]No");
            int answer = Convert.ToInt32(Console.ReadLine());
            Boolean status;
            if (answer == 1){
                status = true;
                Console.WriteLine("Updating concluded");
            }else {
                status = false;
                Console.WriteLine("Pending...");
            }            
            ConTask.UpdateTask(index, name, date, time, info, status);
        }
        public static void DeleteTask(){
            Console.WriteLine("Inform the index position:");
            int index = Convert.ToInt32(Console.ReadLine());
            ConTask.DeleteTask(index);
        }
        public static void PressAKey(){
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}