using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> ResimListeGetir();

        void ResimEkle(ImageFile imagefile);

        ImageFile ResimIDGetir(int id);

        void ResimSil(ImageFile imagefile);

        void ResimGuncelle(ImageFile imagefile);
    }
}
