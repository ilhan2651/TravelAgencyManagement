using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<GuideLanguage>? GuideLanguages { get; set; }

    }
}
