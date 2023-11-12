namespace P08WebApp.Models
{
    public class DeleteViewModel
    {
        public bool data;
        public bool success;
        public string message;
        public DeleteViewModel() { }
        public DeleteViewModel(bool data, bool success,string message) {
            this.data = data;
            this.success = success;
            this.message = message;
        }
    }
}
