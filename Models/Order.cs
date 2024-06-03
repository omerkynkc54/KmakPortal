using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KmakPortal.Models
{
    public class Order
    {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public int UnitOfMeasureId { get; set; }
            public UnitOfMeasure UnitOfMeasure { get; set; }
            public int Quantity { get; set; }
            public string ImagePath { get; set; }
            public int DepartmentId { get; set; }
            public Department Department { get; set; }
            public string RequesterId { get; set; }
            public ApplicationUser Requester { get; set; }
            public string Notes { get; set; }
            public DateTime OrderDate { get; set; }
            public int StatusId { get; set; }
            public OrderStatus Status { get; set; }
        

    }
}
