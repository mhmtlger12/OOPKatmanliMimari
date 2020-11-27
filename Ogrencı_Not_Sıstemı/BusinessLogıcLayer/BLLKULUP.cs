using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BusinessLogıcLayer
{
    public class BLLKULUP
    {
        public static int Ekle(EntitKulup deger)
        {
            if(deger.KULUPAD!=null)
            {
                return FacadeKulup.Ekle(deger);
            }
            return -1;
        }
        public static bool Guncelle(EntitKulup deger)
        {
            if (deger.KULUPAD!=null && deger.KULUPID !=0)

            {
                return FacadeKulup.GUNCELLE(deger);
            }
            return false;
        }
        public static bool Sıl(int deger)
        {
            if (deger!=0)
            {
                return FacadeKulup.Sil(deger);
            }
            return false;
        }
        public static List<EntitKulup> Lıstele()
        {
            return FacadeKulup.KULUPLISTESI();
        }
    }
}
