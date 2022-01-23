using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
