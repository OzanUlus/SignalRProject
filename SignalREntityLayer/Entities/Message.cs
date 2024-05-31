﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}