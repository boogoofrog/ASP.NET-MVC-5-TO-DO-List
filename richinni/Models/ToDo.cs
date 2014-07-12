using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace richinni.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Display(Name = "事項")]
        public string Description { get; set; }
        [Display(Name = "完成？")]
        public bool IsDone { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
