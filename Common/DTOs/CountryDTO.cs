using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    public class CountryDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

    }
}
