using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Repos.Services
{
    public interface ITask1:IBase<Task1>
    {
        public  Task<List<Task1>> GetTasksAsync(
     Task1Status? s,
     string searchTitle,
     int page ,
     int pageSize);
    }
}
