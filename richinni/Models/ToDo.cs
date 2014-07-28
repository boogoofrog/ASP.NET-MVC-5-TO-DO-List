using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace richinni.Models
{
    //To-Do類別
    public class ToDo
    {
        //序號
        public int Id { get; set; }
        //事項
        [Display(Name = "事項")]
        public string Description { get; set; }
        [Display(Name = "完成？")]
        //是否完成
        public bool IsDone { get; set; }
        //使用者
        public virtual ApplicationUser User { get; set; }

    }
}
