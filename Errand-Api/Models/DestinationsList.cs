using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Errand_Api.Models
{
    public class DestinationsList
    {
        public int Id { get; set; }
        public String Origin { get; set; }
        public String [] Destinations {get; set;}
    }
}