﻿using System;

namespace Hermes
{
    public class VisitorModel
    {
        public ulong visitorID { get; set; }            // auto-generated by system
        public ulong visitID { get; set; }              // auto-generated by system
        public string visitorName { get; set; }
        public uint age { get; set; }
        public string ageGroup { get; set; }              // auto-generated by system
        public string phonenumber { get; set; }
        public DateTime vDate { get; set; }
        public DateTime arrivalTime { get; set; }
        public DateTime departureTime { get; set; }
        public float price { get; set; }
        public uint groupCount{ get; set; }
    }
}
