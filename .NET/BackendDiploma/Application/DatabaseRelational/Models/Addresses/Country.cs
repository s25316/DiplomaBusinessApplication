﻿namespace Application.DatabaseRelational.Models.Addresses
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;


        //Dependencies
        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}