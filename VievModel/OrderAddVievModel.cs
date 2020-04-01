using Microsoft.AspNetCore.Mvc.Rendering;
using RelevantPizza.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.VievModel
{
    public class OrderAddVievModel
    {
        public int OrderID { get; set; }

        [Required]
        [Display(Name ="Customer")]
        public int CustomerID { get; set; }
        public OrderType OrderType { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}
