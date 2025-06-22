using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class HotelFacilityFactory
    {
        public static HotelFacility Create(int hotelId, int facilityId)
        {
            return new HotelFacility
            {
                HotelId = hotelId,
                FacilityId = facilityId
            };
        }
    }

}
