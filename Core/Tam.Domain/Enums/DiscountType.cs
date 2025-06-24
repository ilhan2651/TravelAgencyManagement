using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Enums
{
    namespace Tam.Domain.Enums
    {
        public enum DiscountType
        {
            [Display(Name = "Yüzdelik İndirim")]
            Percentage = 0,

            [Display(Name = "Sabit Tutar İndirimi")]
            Fixed = 1
        }
    }

}
