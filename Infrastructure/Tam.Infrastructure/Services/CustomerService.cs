using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.CustomerDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper,IUnitOfWork unitOfWork) : ICustomerService
    {
        public async Task<ServiceResult> CreateCustomerAsync(CreateCustomerDto createDto)
        {
            var customer = mapper.Map<Customer>(createDto);
            customer.CreatedAt = DateTime.UtcNow;
            await customerRepository.AddAsync(customer);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Müşteri Başarı ile Oluşturuldu");
        }

        public async Task<ServiceResult<PagedResult<CustomerListDto>>> GetAllCustomersAsync(int page,int pageSize)
        {
            var query = customerRepository.GetActiveCustomers();
            if (query == null )
                return ServiceResult<PagedResult<CustomerListDto>>.Fail("Hiçbir Müşteri Bulunamadı");
            var pagedResult = await query.ProjectToPagedResultAsync<Customer,CustomerListDto>(
                mapper.ConfigurationProvider,page,pageSize);
            return ServiceResult<PagedResult<CustomerListDto>>.Ok(pagedResult);
        }

        public async Task<ServiceResult<CustomerListDto>> GetUserByIdAsync(int customerId)
        {
           var customer = await customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                return ServiceResult<CustomerListDto>.Fail("Müşteri bulunamadı");
            var result = mapper.Map<CustomerListDto>(customer);
            return ServiceResult<CustomerListDto>.Ok(result);
        }

        public async Task<ServiceResult<PagedResult<CustomerListDto>>> SearchCustomerAsync(string searchTerm, int page, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<PagedResult<CustomerListDto>>.Fail("Arama terimi boş olamaz.");
            string term=searchTerm.Trim().ToLower();
            var query = customerRepository
                .GetAll()
                .Where(c =>
                c.FullName.ToLower().Contains(term) ||
                c.Email.ToLower().Contains(term));
            var pagedResult = await query.ProjectToPagedResultAsync<Customer,CustomerListDto>(mapper.ConfigurationProvider,page,pageSize);
            return ServiceResult<PagedResult<CustomerListDto>>.Ok(pagedResult);
                
        }

        public async Task<ServiceResult> SoftDeleteCustomerAsync(int customerId)
        {
           var customer = await customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                return ServiceResult.Fail("Müşteri bulunamadı.");
            if (customer.DeletedAt != null)
                return ServiceResult.Fail("Müşteri zaten silinmiş.");
            customer.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Müşteri başarı ile silindi.");
                
        }

        public async Task<ServiceResult> UpdateCustomerAsync(int customerId, UpdateCustomerDto updateDto)
        {
            var customer = await customerRepository.GetByIdAsync(customerId);
            if(customer == null)
                return ServiceResult.Fail("Müşteri bulunamadı.");
            mapper.Map(updateDto, customer);
            customer.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Müşteri bilgileri başarı ile güncellendi");


        }
    }
}
