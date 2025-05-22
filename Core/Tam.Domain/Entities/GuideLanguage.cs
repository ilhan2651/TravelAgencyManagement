using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class GuideLanguage
    {
        public int GuideId { get; set; }
        public Guide Guide { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

    }
}
