namespace Invoice.DataAccess
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Quote { get; set; }
        public string Logo { get; set; }
    }
}
