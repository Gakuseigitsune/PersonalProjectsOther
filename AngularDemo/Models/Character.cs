using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data;

namespace AngularDemo.Models
{
    [Table ("characters")]
    public class Character
    {

        [Key]
        public int cid { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public string char_class { get; set; }


        //public static List<Character> Characters = new List<Character>();
    }
}
