﻿namespace LB_7B
{
    public class PhoneContact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} {Phone}";
        }
    }
}