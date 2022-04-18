using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }


        public virtual Customer Customer { get; set; }
        // public virtual Billing Billing { get; set; }
    }
}
