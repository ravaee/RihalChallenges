using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{ 
    public class StudentDTO
    {
        public int ClassId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual Country Country { get; set; }
    }
}
