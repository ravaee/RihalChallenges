using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    [Table("countries")]
    public class Country : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }

    }
}
