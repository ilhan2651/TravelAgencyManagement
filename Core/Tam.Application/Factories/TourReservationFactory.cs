using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.TourReservationDtos;
using Tam.Domain.Entities;

namespace Tam.Application.Factories
{
    public static class TourReservationFactory
    {
        public static void Update(TourReservation entity, UpdateTourReservationDto dto)
        {
            // Ana alanları güncelle
            entity.TourId = dto.TourId;
            entity.ReservationDate = dto.ReservationDate;
            entity.CustomerId = dto.CustomerId;
            entity.NumberOfPeople = dto.NumberOfPeople;
            entity.TotalPrice = dto.TotalPrice;
            entity.Status = dto.Status;
            entity.Note = dto.Note;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.InvoiceId = dto.InvoiceId;
            entity.DiscountId = dto.DiscountId;
            entity.PaymentId = dto.PaymentId;


            // Misafirleri güncelleme mantığı
            if (dto.Guests != null)
            {
                // Eski misafirlerden DTO'da olmayanları sil
                var toRemove = entity.Guests
                    .Where(g => !dto.Guests.Any(dg => dg.Id == g.Id))
                    .ToList();
                foreach (var old in toRemove)
                    entity.Guests.Remove(old);

                // Mevcut misafirleri DTO ile güncelle
                var toUpdate = from dg in dto.Guests
                               where dg.Id.HasValue
                               join eg in entity.Guests on dg.Id.Value equals eg.Id
                               select (dg, eg);
                foreach (var (dg, eg) in toUpdate)
                {
                    eg.FullName = dg.FullName;
                    eg.Age = dg.Age;
                    eg.IdentityNumber = dg.IdentityNumber;
                    eg.Note = dg.Note;
                }

                // DTO'da Id'si olmayanları yeni misafir olarak ekle
                var toAdd = dto.Guests.Where(dg => !dg.Id.HasValue);
                foreach (var dg in toAdd)
                {
                    entity.Guests.Add(new TourReservationGuest
                    {
                        TourReservationId = entity.Id,
                        FullName = dg.FullName,
                        Age = dg.Age,
                        IdentityNumber = dg.IdentityNumber,
                        Note = dg.Note
                    });
                }
            }
        }
    }
}
