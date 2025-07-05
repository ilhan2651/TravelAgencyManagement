using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Email;
using Tam.Application.Dtos.EmailDtos;
using Tam.Domain.Entities;

namespace Tam.Application.Factories
{
    public static class TransferReservationEmailMessageFactory
    {
        public static TransferReservationEmailMessage Create(TransferReservation reservation)
        {
            return new TransferReservationEmailMessage
            {
                CustomerEmail = reservation.Customer.Email,
                TransferName = reservation.Transfer.Name,
                CustomerName = reservation.Customer.FullName,
                ReservationDate = reservation.ReservationDate,
                NumberOfPeople = reservation.NumberOfPeople,
                PickUpPoint = reservation.PickUpPoint
            };
        }
    }
}
