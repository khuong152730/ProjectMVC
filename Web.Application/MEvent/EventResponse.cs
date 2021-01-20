using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Data.Entities;

namespace Web.Application.MEvent
{
  public  class EventResponse
    {
        public Guid id { get; set; }
        [Display(Name = "Sự Kiện")]
        [Required(ErrorMessage = "Thiếu Tên sự kiện")]
        public string sukien { get; set; }
        [Required(ErrorMessage = "Thiếu website")]
        [Display(Name = "Website")]

        public string website { get; set; }
        [Required(ErrorMessage = "Thiếu Nhà tổ chức")]
        [Display(Name = "Nhà tổ chức")]
        public string nhatochuc { get; set; }
        [Required(ErrorMessage = "Thiếu Loại chương trình")]
        [Display(Name = "Chương trình")]
        public string eventprogram { get; set; }

        public string surveryduration { get; set; }
        [Display(Name = "Địa điểm")]
        [Required(ErrorMessage = "Thiếu Địa điểm")]
        public string diadiem { get; set; }
        [Required(ErrorMessage = "Thiếu Công ty")]
        [Display(Name = "Công ty")]
        public string congty { get; set; }
        [Required(ErrorMessage = "Thiếu Người phụ Trách")]
        [Display(Name = "Người phụ trách")]
        public string nguoiphutrach { get; set; }
        [Required(ErrorMessage = "Thiếu ngày bắt đầu")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime ngaybatdau { get; set; }
        [Required(ErrorMessage = "Thiếu Ngày kết thúc")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime ngayketthuc { get; set; }
        [Required(ErrorMessage = "Thiếu Múi giờ")]
        [Display(Name = "Múi giờ")]
        public string muigio { get; set; }
        [Required(ErrorMessage = "Thiếu Chuyên mục")]
        [Display(Name = "Chuyên mục")]
        public string chuyenmuc { get; set; }
        [Required(ErrorMessage = "Thiếu TwitterHashtag")]
        [Display(Name = "Twitter Hasgtag")]
        public string twitterhashtag { get; set; }
        [Required(ErrorMessage = "Thiếu Người tham gia tối đa")]
        [Display(Name = "Người tham gia tối đa")]
        public int nguoitoida { get; set; }
        [Required(ErrorMessage = "Thiếu Người tham gia tối thiểu")]
        [Display(Name = "Người tham gia tối thiểu")]
        public int nguoitoithieu { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
