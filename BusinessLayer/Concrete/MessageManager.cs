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
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messageDal;
        

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> MesajListeGetirGelen()
        {
            return _messageDal.Listele(x => x.MessageStatusReceiver == false && x.MessageReciever == "mehmet@gmail.com");
        }

        public List<Message> MesajListeGetirGiden()
        {
            return _messageDal.Listele(x => x.MessageStatusSender == false && x.MessageSender == "mehmet@gmail.com" && x.MessageStatusDraft == false);
        }

        public List<Message> MesajListeGetirSilinen()
        {
            return _messageDal.Listele(x => (x.MessageStatusSender == true && x.MessageSender == "mehmet@gmail.com") || (x.MessageStatusReceiver == true && x.MessageReciever == "mehmet@gmail.com"));
        }

        public List<Message> MesajListeGetirTaslak()
        {
            return _messageDal.Listele(x => x.MessageStatusDraft == true && x.MessageSender == "mehmet@gmail.com");
        }

        public void MesajEkle(Message message)
        {
            _messageDal.Ekle(message);
        }

        public void MesajGuncelle(Message message)
        {
            _messageDal.Guncelle(message);
        }

        public Message MesajIDGetir(int id)
        {
            return _messageDal.AlGetir(x => x.MessageID == id);
        }

        public void MesajSil(Message message)
        {
            _messageDal.Guncelle(message);
        }

        public void MesajKaliciSil(Message message)
        {
            _messageDal.Sil(message);
        }

    }
}
