using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class GuideLanguageFactory
    {
        public static GuideLanguage Create(int guideId, int languageId)
        {
            return new GuideLanguage
            {
                GuideId = guideId,
                LanguageId = languageId
            };
        }
    }

}
