using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9._2.Entities.Common;

namespace Week9._2.Entities{
    
      public class Publisher : BaseEntity
      {
        public string Name { get; set; }
          

        public void PrintPublihser()
        {
           Console.WriteLine($"{Name}");
        }
      }    
}
