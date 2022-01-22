using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    [Table("students")]
    public class Student : BaseModel
    {
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual Country Country { get; set; }

    }
}
