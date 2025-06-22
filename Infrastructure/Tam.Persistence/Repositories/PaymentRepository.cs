using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class PaymentRepository(TamDbContext context) : GenericRepository<Payment>(context), IPaymentRepository
    {
       

        public async Task<List<Payment>> GetAllWithMethodAsync()
        {
            return await context.Payments.Include(p => p.PaymentMethod)
                .OrderByDescending(p=>p.CreatedAt).ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await context.Payments
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(p => p.Id == id);
                
        }
    }
}
