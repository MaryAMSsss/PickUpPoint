using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? PickUpPointId { get; set; }

    public int? UserId { get; set; }

    public int? PickUpCode { get; set; }

    public string? Status { get; set; }

    public Order(DateTime? orderDate, DateTime? deliveryDate, int? pickUpPointId, int? userId, int? pickUpCode, string? status)
    {
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        PickUpPointId = pickUpPointId;
        UserId = userId;
        PickUpCode = pickUpCode;
        Status = status;
    }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual PickUpPoint? PickUpPoint { get; set; }

    public virtual User? User { get; set; }
}
