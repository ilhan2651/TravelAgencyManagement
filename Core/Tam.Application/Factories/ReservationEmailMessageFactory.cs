using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Email;
using Tam.Domain.Entities;

namespace Tam.Application.Factories
{
    public static class ReservationEmailMessageFactory
    {
        public static ReservationEmailMessage Create(HotelReservation reservation)
        {
            return new ReservationEmailMessage
            {
                CustomerEmail = reservation.Customer.Email,
                CustomerName = reservation.Customer.FullName,
                HotelName = reservation.Hotel.Name,
                ReservationDate = reservation.ReservationDate,
                CheckIn = reservation.CheckIn,
                NumberOfPeople = reservation.NumberOfPeople
            };
        }
    }

}
