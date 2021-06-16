using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string MessageSender { get; set; }

        [StringLength(50)]
        public string MessageReciever { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        public string MessageContent { get; set; }

        [DefaultValue("getdate()")]
        public DateTime MessageDate { get; set; }

        [DefaultValue(false)]
        public bool MessageStatusSender { get; set; }

        [DefaultValue(false)]
        public bool MessageStatusReceiver { get; set; }

        [DefaultValue(false)]
        public bool MessageStatusDraft{ get; set; }

        [DefaultValue(false)]
        public bool MessageStatusRead { get; set; }
    }
}
