using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set;}

        public string Name { get; set; } = "Humberto";

        public int UserType { get; set;} = 100;

        public int Email { get; set;} = 10;

        public int Phone { get; set;} = 10;

        public int Directory { get; set;} = 10 ;

        public Inventory Class {get; set;} = Inventory.Admin;
    }
}