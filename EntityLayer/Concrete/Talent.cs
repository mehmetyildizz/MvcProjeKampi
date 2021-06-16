using System;
using System.Collections.Generic;
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

        public byte TalentValue { get; set; }

        [StringLength(25)]
        public string AdminName { get; set; }

        [StringLength(250)]
        public string AdminPhoto { get; set; }

        [StringLength(250)]
        public string AdminTitle { get; set; }
    }
}
