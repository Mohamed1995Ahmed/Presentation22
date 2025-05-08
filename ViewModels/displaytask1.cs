using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace ViewModels
{
    public class displaytask1
    {
        public IEnumerable<Task1> data {  get; set; }
        public int page { get; set; }
        public int pagesize { get; set; }
        public int? count { get; set; }


    }
}
