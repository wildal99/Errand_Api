using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Errand_Api.Models
{
    public class Leg
    {
        public int Id { get; set; }
        public string Origin {get; set;}
        public string Destination {get; set;}

        //Google direction API data
    }
}