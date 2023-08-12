using System;
namespace Sample_Server.Src.Models
{
    public class Orders
    {
        public required Guid Customer_Id { get; set; }

        public required string First_Name { get; set; }

        public required string Last_Name { get; set; }

        public required string Address { get; set; }

        public required Guid Order_Id { get; set; }

        public required string Item_Name { get; set; }

        public required int Cost { get; set; }
    }
}

