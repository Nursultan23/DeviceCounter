using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Indicator
    {
        public virtual int Id { get; set; }
        public virtual string UnitName { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual double MeterValue { get; set; }
        public virtual string Unit { get; set; }

    }
}
