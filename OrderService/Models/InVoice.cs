using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class InVoice
    {
        public int Id { get; set;}
        public int TotalCost { get; set;}
        public DateTime Date { get; set;}
    }
}