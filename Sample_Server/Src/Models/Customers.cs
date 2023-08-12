namespace Sample_Server.Src.Models
{
    public class Customers
    {
        public required Guid Customer_Id { get; set; }

        public required string First_Name { get; set; }

        public required string Last_Name { get; set; }

        public required string Address { get; set; }
    }
}


