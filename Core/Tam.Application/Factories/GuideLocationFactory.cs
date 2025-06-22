using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class GuideLocationFactory
    {
        public static GuideLocation Create(int guideId, int locationId)
        {
            return new GuideLocation
            {
                GuideId = guideId,
                LocationId = locationId
            };
        }
    }

}
