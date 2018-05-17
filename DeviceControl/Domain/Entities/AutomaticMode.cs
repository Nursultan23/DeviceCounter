using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AutomaticMode
    {
        public virtual int Id { get; set; }
        public virtual bool Status { get; set; }
        public virtual DateTime Time { get; set; }
    }
}
