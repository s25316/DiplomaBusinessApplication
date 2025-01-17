﻿namespace Application.DatabaseRelational.Models.Addresses
{
    public class Division
    {
        //Properties
        public int DivisionId { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; } = 0;
        public string? ParentsPath { get; set; } = null;

        //Dependencies
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public int DivisionTypeId { get; set; }
        public virtual DivisionType DivisionType { get; set; } = null!;
        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        //Recurrent Part
        public int? ParentDivisionId { get; set; } = null;
        public virtual Division? ParentDivision { get; set; } = null;
        public virtual ICollection<Division> ChildDivisions { get; set; } = new List<Division>();
    }
}
