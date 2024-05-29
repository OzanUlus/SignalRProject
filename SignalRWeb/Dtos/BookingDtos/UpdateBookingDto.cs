using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWeb.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
