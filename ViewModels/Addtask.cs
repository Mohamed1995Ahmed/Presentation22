using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace ViewModels
{
    public class Addtask
    {
        [Required]
        [Display(Name = "name of Task")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Task1Status Status { get; set; }
        public PriorityLevel p {  get; set; }   

    }
}
