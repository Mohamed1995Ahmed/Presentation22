using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Models;
using Repos.Services;

namespace Repos.Repos
{
    public class Task1Repo : Base<Task1>, ITask1
    {
        public Task1Repo(Apppdbcontext context) : base(context)
        {
        }
        public async Task<List<Task1>> GetTasksAsync(
       Task1Status? status = null,
       string searchTitle = null,
       int page = 1,
       int pageSize = 10)
        {
            var query =await GetAll();

            // Filter by status if provided
            if (status.HasValue)
            {
                query = query.Where(t => t.Status==status.Value);
            }

            // Search by title if provided
            if (!string.IsNullOrEmpty(searchTitle))
            {
                query = query.Where(t => t.Title.Contains(searchTitle));
            }

            // Pagination
            query = query
                .OrderBy(t => t.DueDate) // Optional: order by due date
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return  query.ToList();
        }

        // Optional: get total task count with filters (for pagination UI)
        //public async Task<int> GetTotalTaskCountAsync(TaskStatus? status = null, string searchTitle = null)
        //{
        //    var query =await GetAll();

        //    if (status.HasValue)
        //        query = query.Where(t => t.Status==status.Value);

        //    if (!string.IsNullOrEmpty(searchTitle))
        //        query = query.Where(t => t.Title.Contains(searchTitle));

        //    return await query.CountAsync();
        //}
    }
}
