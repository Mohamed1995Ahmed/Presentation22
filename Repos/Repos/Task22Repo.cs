using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Data;
using Models.Models;
using Repos.Services;

namespace Repos.Repos
{
    public class Task22Repo : Base<Task1>, ITask1
    {
        public Task22Repo(Apppdbcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<Task1>> GetTasksAsync(Task1Status? status=null, string? searchTitle=null, int page=1, int pageSize=10)
        {
            var tasks = await GetAll();
            if (status.HasValue)
            {
                tasks = tasks.Where(x => x.Status == status.Value);

            }
            if (!string.IsNullOrWhiteSpace(searchTitle))
            {
                tasks = tasks.Where(s => s.Title != null &&
                                         s.Title.ToLower().Contains(searchTitle.ToLower()));
            }
            tasks = tasks.Skip((page - 1) * pageSize).Take(pageSize);
            return tasks;
        }

       // Optional: get total task count with filters(for pagination UI)
        public async Task<int> GetTotalTaskCountAsync(Task1Status? status = null, string? searchTitle = null)
        {
            var query = await GetAll();

            if (status.HasValue)
                query = query.Where(a=>a.Status==status.Value);

            if (!string.IsNullOrEmpty(searchTitle))
                query = query.Where(t => t.Title.Contains(searchTitle.ToLower()));

            return  query.Count();
        }

    }
}
