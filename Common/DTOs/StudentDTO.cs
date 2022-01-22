using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{ 
    public class StudentDTO: BaseDTO
    {
        private DateTime _birthdate = DateTime.Now;

        public int ClassId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get { return _birthdate; } set { _birthdate = value.Value; } }

        public virtual Class Class { get; set; }
        public virtual Country Country { get; set; }

    }
}
