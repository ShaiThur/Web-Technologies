using Application.Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class JobsRepository(ApplicationDbContext applicationDbContext)
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task CreateAsync(Job entity)
        {
            await _applicationDbContext.Jobs.AddAsync(entity);
        }

        public async Task<Job> GetByIdAsync(Guid id)
        {
            var job = await _applicationDbContext.Jobs.FindAsync(id) 
                ?? throw new NullEntityException($"{typeof(Job)} with id {id}");

            return job;
        }

        public async Task<List<Job>> GetEmployeeFinishedJobs(Guid employeeId)
        {
            var jobs = await _applicationDbContext.Jobs
                .AsNoTracking()
                .Where(j => j.Employee.Id == employeeId)
                .ToListAsync()
                    ?? throw new NullEntityException($"{typeof(List<Job>)}");

            return jobs;
        }

        public async Task UpdateAsync(Guid id, Job value)
        {
            await _applicationDbContext.Jobs
                .Where(j => j.Id == id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(j => j.Title, value.Title)
                .SetProperty(j => j.MainInfo, value.MainInfo)
                .SetProperty(j => j.Complexity, value.Complexity)
                .SetProperty(j => j.Deadline, value.Deadline)
                .SetProperty(j => j.DeliveryTime, value.DeliveryTime)
                );
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
