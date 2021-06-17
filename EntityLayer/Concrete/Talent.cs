using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }

        [StringLength(25)]
        public string TalentName { get; set; }

        public int TalentValue { get; set; }

        [DefaultValue(true)]
        public bool TalentStatus { get; set; }

        public int WriterID { get; set; }

        public virtual Writer Writer { get; set; }
    }
}