using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Cities
{
    //Interface
    // -Implementation (kodlama ) yerine yalnızca yapılacak işlerin adını 
    // dönüş tipini ve parametresini içeren soyutlama yapılarıdır.
    // Interface: İşin nasıl yapıldığını değl hangi işin yapılacağını söylemektir
    // Bundan dolayıda Interfacelere CONTRACT(sözleşme) ismi de verilir.
    //-Peki işi (implementation) kim yapacak?
    // yazdığınız interfceyi hangi sınıf implement edyorsa işi kodlamayı o yapacak 
    // public class CityService : ICityService buna implement denir miras denmez
    // yukarıda yazan kodlamadaki sentaksa interface'ler özelinde miras almak DEĞİL
    // interface'i implement etmek (uyaralama/kodlama) denir.
     
  public  interface ICityService : IService<CityDTO>
    {

    }
}
