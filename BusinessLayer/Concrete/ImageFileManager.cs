using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imagefileDal;

        public ImageFileManager(IImageFileDal imagefileDal)
        {
            _imagefileDal = imagefileDal;
        }

        public void ResimEkle(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }

        public void ResimGuncelle(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }

        public ImageFile ResimIDGetir(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> ResimListeGetir()
        {
            return _imagefileDal.Listele();
        }

        public void ResimSil(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }
    }
}
