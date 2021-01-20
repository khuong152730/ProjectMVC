using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Data.Entities
{
   public class Ticket
    {
        public Guid id { get; set; }
        [DisplayName("Tên")]
        [Required]
        public string name { get; set; }
        [DisplayName("Hết mở bán")]
        [Required]

        public DateTime hetmoban { get; set; }
        [Required]

        [DisplayName("Giá")]
        public double gia { get; set; }
        [DisplayName("Tối đa")]
        public int toida { get; set; }
        [DisplayName("Giữ phần")]
        public int giuphan { get; set; }
        [DisplayName("Chưa xác nhận")]
        public int chuaxacnhan { get; set; }
        [Required]
        public Guid EventId { get; set; }
        [DisplayName("Tên")]
        public Event Event { get; set; }
        public ICollection<Participants> Participants { get; set; }
    }
}
