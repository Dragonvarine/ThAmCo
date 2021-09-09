using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class MenuFoodItem
    {
        public int MenuFoodItemId { get; set; }

        public int MenuId { get; set; }

        public int FoodItemId { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
