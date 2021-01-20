using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Data.Entities
{
  public class Participants
    {
        public Guid id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TicketName { get; set; }

        public Ticket Ticket { get; set; }
        public AppUser User { get; set; }

    }
}
