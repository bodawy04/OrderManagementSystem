using Domain.Models.Invoices;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Orders
{
    public class Order : BaseEntity<int>
    {
        public int CustomerId { get; set; } = default!;
        public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; } = default!;
        public PaymentMethods PaymentMethod { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        public Invoice Invoice { get; set; } = default!;
    }
}
