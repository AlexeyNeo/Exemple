﻿using System;

namespace Exemple.BBL.ModelDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int PhoneId { get; set; }
        public DateTime? Date { get; set; }
    }
}