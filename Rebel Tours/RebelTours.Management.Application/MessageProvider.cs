using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application
{
    public static class MessageProvider
    {
        public static string CityCreateSuccessMessage = "Başarılı";
        public static string CityCreateErrorMessage = "Başarısız";

        public static string CreateSuccessMessage = "Kaydetme başarılı";
        public static string CreateErrorMessage = "Kaydetme başarısız";

        public static string GetCreateSuccessMessage<TEntity>()
        {
            return $"{typeof(TEntity).Name} kaydetme aşamasında bir hata meydana geldi";
        }
    }
}
