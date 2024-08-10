namespace Prova {
    public class ConTask {
        public static void CreateTask(string name, string date, string time, string info, Boolean status){
            status = false;
            new Task(name, date, time, info, status);
        }
        public static List<Task> ListTask(){
            return Task.ListTask();
        }
        public static void UpdateTask(int index, string name, string date, string time, string info, Boolean status){
            List<Task> items = ListTask();
            if (index >= 0 && index < items.Count){
                Task.UpdateTask(index, name, date, time, info, status);
                Console.WriteLine("Taks updated succesfully!");
            }else {
                Console.WriteLine("Invalid index");
            }
        }
        public static void DeleteTask(int index){
            List<Task> items = ListTask();
            if (index >=0 && index < items.Count){
                Task.DeleteTask(index);
                Console.WriteLine("Are you sure you want to delete this task?[Y]/[N]");
                string confirmation = Console.ReadLine()?.Trim().ToUpper();
            if (confirmation == "Y"){
                items.RemoveAt(index);
                Console.WriteLine("Task deleted successfully!");
            }else {
                Console.WriteLine("Task deletion canceled");
            }
            }else {
                Console.WriteLine("Invalid index");
            }
        }
        public static void Status(Boolean status){
                if (status == false){
                    Console.WriteLine("Pending.");
                }else {
                    Console.WriteLine("Done");
                }
            }
        }
    }

