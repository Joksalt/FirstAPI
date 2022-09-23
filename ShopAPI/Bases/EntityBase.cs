using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Bases
{
    public abstract class EntityBase
    {
        [Required]
        public int Id { get; set; }
    }
}
