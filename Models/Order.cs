using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KmakPortal.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("OrderType")]
        public int? OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }

        [ForeignKey("UnitOfMeasure")]
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public float Quantity { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Requester")]
        public int? RequesterId { get; set; }
        public User Requester { get; set; }

        public string Notes { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("OrderStatus")]
        public int? OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
