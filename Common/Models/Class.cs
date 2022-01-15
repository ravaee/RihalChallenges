using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    [Table("classes")]
    public class Class : BaseModel
    {
        [Column("class_name")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
