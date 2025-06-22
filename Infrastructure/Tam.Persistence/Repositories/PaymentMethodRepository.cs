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
    public class PaymentMethodRepository(TamDbContext context) : GenericRepository<PaymentMethod>(context), IPaymentMethodRepository
    {
        public Task<List<PaymentMethod>> GetAllMethodsAsync()
        {
            return context.PaymentMethods
                .OrderByDescending(d=>d.DeletedAt==null)
                .ThenBy(d=>d.Method).ToListAsync();
        }
    }

}
