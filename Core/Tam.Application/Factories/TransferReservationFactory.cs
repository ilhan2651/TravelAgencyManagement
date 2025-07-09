using System;
using System.Collections.Generic;
using System.Linq;
using Tam.Application.Dtos.TransferReservationDtos;
using Tam.Domain.Entities;

namespace Tam.Application.Factories
{
    public static class TransferReservationFactory
    {
        public static void Update(TransferReservation entity, UpdateTransferReservationDto dto)
        {
            // 1) Ana alanları güncelle
            entity.TransferId = dto.TransferId;
            entity.PickUpPoint = dto.PickUpPoint;
            entity.DropOffPoint = dto.DropOffPoint;
            entity.InvoiceId = dto.InvoiceId;
            entity.DiscountId = dto.DiscountId;
            entity.PaymentId = dto.PaymentId;
            entity.CustomerId = dto.CustomerId;
            entity.NumberOfPeople = dto.NumberOfPeople;
            entity.TotalPrice = dto.TotalPrice;
            entity.Status = dto.Status;
            entity.Note = dto.Note;
            entity.UpdatedAt = DateTime.UtcNow;

            // Guests diff mantığı: yalnızca dto.Guests != null ise işle
            if (dto.Guests != null)
            {
                // 2) Eski misafirlerden, DTO'da olmayanları sil
                var toRemove = entity.Guests
                    .Where(g => !dto.Guests.Any(dg => dg.Id == g.Id))
                    .ToList();
                foreach (var old in toRemove)
                    entity.Guests.Remove(old);

                // 3) Mevcut misafirleri DTO ile güncelle
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

                // 4) DTO'da Id'si olmayanları yeni misafir olarak ekle
                var toAdd = dto.Guests.Where(dg => !dg.Id.HasValue);
                foreach (var dg in toAdd)
                {
                    entity.Guests.Add(new TransferReservationGuest
                    {
                        TransferReservationId = entity.Id,
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
