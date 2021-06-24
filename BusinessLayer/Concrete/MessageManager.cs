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

        public List<Message> MesajListeGetirGelen(string yazarmail)
        {
            return _messageDal.Listele(x => x.MessageStatusReceiver == false && x.MessageReciever == yazarmail);
        }

        public List<Message> MesajListeGetirGiden(string yazarmail)
        {
            return _messageDal.Listele(x => x.MessageStatusSender == false && x.MessageSender == yazarmail && x.MessageStatusDraft == false);
        }

        public List<Message> MesajListeGetirSilinen(string yazarmail)
        {
            return _messageDal.Listele(x => (x.MessageStatusSender == true && x.MessageSender == yazarmail) || (x.MessageStatusReceiver == true && x.MessageReciever == yazarmail));
        }

        public List<Message> MesajListeGetirTaslak(string yazarmail)
        {
            return _messageDal.Listele(x => x.MessageStatusDraft == true && x.MessageSender == yazarmail);
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
