using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Entities;

namespace Module4HW3
{
    public class Requests
    {
        private readonly ApplicationDbContext _context;

        public Requests(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task FirstRequest()
        {
            var firstQuery = await _context.Employee
                .Include(i => i.Title)
                .Include(i => i.Office)
                .ToListAsync();
        }

        public async Task<List<int>> SecondRequest()
        {
            return await _context.Employee
                .Select(e => EF.Functions.DateDiffDay(e.HiredDate, DateTime.UtcNow))
                .ToListAsync();
        }

        public async Task ThirdRequest()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var first = await _context.Employee.FirstAsync();
                    first.FirstName = "Tilt";
                    await _context.SaveChangesAsync();
                    var second = await _context.Employee.Skip(1).FirstAsync();
                    second.FirstName = "Tiltoson";
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task FourthRequest()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Title.AddAsync(new Title { TitleId = 4, Name = "Tilt" });
                    await _context.Project.AddAsync(new Project { ProjectId = 6, Name = "Pffff", Budget = 100000, StartedDate = new DateTime(2000, 1, 1), ClientId = 1 });
                    await _context.SaveChangesAsync();
                    await _context.Employee.AddAsync(new Employee { EmployeeId = 6, FirstName = "Ya", SecondName = "VShoke", OfficeId = 1, TitleId = 4, HiredDate = new DateTime(2020, 1, 1), DateOfBirth = new DateTime(2000, 1, 1) });
                    await _context.SaveChangesAsync();
                    await _context.EmployeeProject.AddAsync(new EmployeeProject { EmployeeProjectId = 6, EmployeeId = 6, ProjectId = 6, Rate = 0, StartedDate = new DateTime(2020, 1, 1) });
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task FifthRequest()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var deleteEmployee = await _context.Employee.FirstAsync(e => e.EmployeeId == 4);
                    _context.Employee.Remove(deleteEmployee);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task SixthRequest()
        {
            await _context.Employee
                        .Include(t => t.Title)
                        .GroupBy(g => g.Title.Name)
                        .Select(s => s.Key)
                        .Where(w => EF.Functions.Like(w, "^a"))
                        .ToListAsync();
        }
    }
}
