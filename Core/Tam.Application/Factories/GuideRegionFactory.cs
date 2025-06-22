using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class GuideRegionFactory
    {
        public static GuideRegion Create(int guideId, int RegionId)
        {
            return new GuideRegion
            {
                GuideId = guideId,
                RegionId = RegionId
            };
        }
    }
}
