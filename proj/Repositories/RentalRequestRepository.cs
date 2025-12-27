using Microsoft.EntityFrameworkCore;
using proj.Domain;
using proj.Models.Entities;

namespace proj.Repositories
{
    public class RentalRequestRepository
    {
        public void Add(RentalRequest request)
        {
            using var context = new MyDatabaseContext();
            context.RentalRequests.Add(request);
            context.SaveChanges();
        }
        public IEnumerable<RentalRequest> GetByUser(int userId)
        {
            using var context = new MyDatabaseContext();
            return context.RentalRequests
                .Include(r => r.Equipment)
                .Where(r => r.ClientId == userId)
                .ToList();
        }
        public IEnumerable<RentalRequest> GetAll()
        {
            using var context = new MyDatabaseContext();
            return context.RentalRequests
                .Include(r => r.Equipment)
                .Include(r => r.Client)
                .ToList();
        }


        public void Delete(int requestId)
        {
            using var context = new MyDatabaseContext();

            var rent = context.RentalRequests
                .FirstOrDefault(r => r.RequestId == requestId);

            if (rent == null) return;

            context.RentalRequests.Remove(rent);
            context.SaveChanges();
        }
    }
}
