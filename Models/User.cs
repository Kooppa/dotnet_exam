using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam.Models
{
    public class User
    {
        public int Id { get; set;}

        public string Name { get; set; } = "Humberto";

        public int UserType { get; set;} = 1;

        public int Email { get; set;} = 123;

        public int Phone { get; set;} = 442852147;

        public int Directory { get; set;} = 42;

        public Inventory Class {get; set;} = Inventory.Admin;
    }
}