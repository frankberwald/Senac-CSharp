namespace Prova {
    public class Task {
        public string Name {get; set;}
        public string Date {get; set;}
        public string Time {get; set;}
        public string Info {get; set;}

        public Boolean Status {get; set;}

        public Task(string name, string date, string time, string info, Boolean status){
            this.Name = name;
            this.Date = date;
            this.Time = time;
            this.Info = info;
            this.Status = status;
            RepoTask.items.Add(this);
        }
        public static List<Task> ListTask(){
            return RepoTask.items;
        }
        public static void UpdateTask (int index, string name, string date, string time, string info, Boolean status){

            Task items = RepoTask.items[index];
            items.Name = name;
            items.Date = date;
            items.Time = time;
            items.Info = info;
            items.Status = status;
        }
        public static void UpdateStatus(Boolean status, int answer){
            if (answer == 1){
                status = true;
            }else {
                status = false;
            }
            
        }
        public static void DeleteTask(int index){
            
            RepoTask.items.RemoveAt(index);
        }

    }
}