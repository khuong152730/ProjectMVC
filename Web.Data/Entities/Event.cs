using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Data.Entities
{
   public class Event 
    {
      

        public Guid id { get; set; }
        [Display(Name = "Sự Kiện")]
        [Required(ErrorMessage = "Nhập trường này")]
        public string sukien { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Website")]
       
        public string website { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Nhà tổ chức")]
        public string nhatochuc { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Chương trình")]
        public string eventprogram { get; set; }

        public string surveryduration { get; set; }
        [Display(Name = "Địa điểm")]
        [Required(ErrorMessage = "Nhập trường này")]
        public string diadiem { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Công ty")]
        public string congty { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Người phụ trách")]
        public string nguoiphutrach { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime ngaybatdau { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime ngayketthuc { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Múi giờ")]
        public string muigio { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Chuyên mục")]
        public string chuyenmuc { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Twitter Hasgtag")]
        public string twitterhashtag { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Người tham gia tối đa")]
        public int nguoitoida { get; set; }
        [Required(ErrorMessage = "Nhập trường này")]
        [Display(Name = "Người tham gia tối thiểu")]
        public int nguoitoithieu { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        
       
    }
}
