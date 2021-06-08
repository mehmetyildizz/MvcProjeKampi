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
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> MesajListeGetirGelen()
        {
            return _messageDal.Listele(x=>x.MessageStatusReceiver== false && x.MessageReciever == "admin@yandex.com" && x.MessageStatusDraft == false);
        }

        public List<Message> MesajListeGetirGiden()
        {
            return _messageDal.Listele(x => x.MessageStatusSender == false && x.MessageSender == "admin@yandex.com" && x.MessageStatusDraft == false);
        }

        public void MesajEkle(Message message)
        {
            _messageDal.Ekle(message);
        }

        public void MesajGuncelle(Message message)
        {
            throw new NotImplementedException();
        }

        public Message MesajIDGetir(int id)
        {
            return _messageDal.AlGetir(x => x.MessageID == id);
        }

        public void MesajSil(Message message)
        {
            throw new NotImplementedException();
        }

    }
}
