using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceControl.Models
{
    public class DeviceViewModel
    {
        public IEnumerable<Device> devices;
        public IEnumerable<Indicator> indicators;
        public AutomaticMode mode;
    }
}