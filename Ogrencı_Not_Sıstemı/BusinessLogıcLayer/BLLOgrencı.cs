using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BusinessLogıcLayer
{
    public class BLLOgrencı
    {
        public static int ekle(EntityOgrenci deger)
        {
            if (deger.AD!=null && deger.SOYAD!=null && deger.KULUPID>0 && deger.FOTOGRAF!=null && deger.KULUPID>0 && deger.FOTOGRAF.Length>1)

            {
                return FacadeOgrenci.Ekle(deger);

            }
            return -1;

        }
        public static bool Guncelle(EntityOgrenci deger)
        {
            if (deger.AD != null && deger.SOYAD != null && deger.KULUPID>0 && deger.FOTOGRAF != null && deger.KULUPID > 0 && deger.ID!=0)

            {
                return FacadeOgrenci.Guncelle(deger);

            }
            return false;
        }
        public static bool Sıl(int deger)
        {
            if (deger!=0 && deger>1)
            {
                return FacadeOgrenci.Sil(deger);
            }
            return false; //aksi durumda
        }
        public static List<EntityOgrenci> Lıstele()
        {
            return FacadeOgrenci.OGRENCILISTESI();
            ;
        }
    }
}
