using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Device
    {
        public virtual int Id { get; set; }
        public virtual int DeviceCode { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Status { get; set; }
        public virtual DateTime ChangingMoment { get; set; }
    }
}
