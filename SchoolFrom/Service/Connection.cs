namespace SchoolFrom.Service
{
    public class Connection
    {
        public string DataBase_Url { get; set; } = "mongodb+srv://dan_ostap:Frost310@cluster0.1ecvuza.mongodb.net/?retryWrites=true&w=majority";
        public string DataBase_Name { get; set; } = "School";
        public string DataBase_Collection { get; set; } = "Candidates";
    }
}
