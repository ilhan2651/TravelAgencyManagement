using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Tam.Infrastructure.Extensions
{

    public static class PgExtensions
    {
        [DbFunction]                
        public static string Unaccent(string input)
            => throw new NotSupportedException();
    }
}
