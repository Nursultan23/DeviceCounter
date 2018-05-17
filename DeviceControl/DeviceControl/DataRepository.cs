using DeviceControl.Models;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeviceControl
{
    public class DataRepository
    {
        private EfDbContext context;
        public DataRepository()
        {
            context = new EfDbContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        
        public DeviceViewModel GetData()
        {
            DeviceViewModel model = new DeviceViewModel();
            try
            {
                model.devices = context.Devices;
                model.indicators = context.Indicators;
                if (context.Modes.Count() == 0)
                {
                    context.Modes.Add(new AutomaticMode { Status = false, Time = DateTime.Now });
                    context.SaveChanges();
                }
                model.mode = context.Modes.First<AutomaticMode>();
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        
        public void UpdateMode(AutomaticMode automaticMode)
        {
            context.Modes.Attach(automaticMode);
            var entry = context.Entry(automaticMode);
            entry.Property(x => x.Id).IsModified = false;
            entry.Property(x => x.Status).IsModified = true;
            entry.Property(x => x.Time).IsModified = true;
            context.SaveChanges();
        }

        #region Action for Devices 
        public Device GetDeviceById(int id)
        {
            return context.Devices.FirstOrDefault(x => x.Id == id);
        }
        
        public void UpdateDevice(Device device)
        {
            context.Devices.Attach(device);
            var entry = context.Entry(device);
            entry.Property(x => x.Id).IsModified = false;
            entry.Property(x => x.Status).IsModified = true;
            entry.Property(x => x.DeviceCode).IsModified = true;
            entry.Property(x => x.Description).IsModified = true;
            entry.Property(x => x.ChangingMoment).IsModified = true;
            context.SaveChanges();
        }

        public void DeleteDevice(int id)
        {
            Device device = context.Devices.FirstOrDefault(x => x.Id == id);
            context.Devices.Remove(device);
            context.SaveChanges();
        }

        public void CreateDevice(Device device)
        {
            context.Devices.Add(device);
            context.SaveChanges();
        }
        #endregion

        #region Actions for Indicators
        public Indicator GetIndicatorById(int id)
        {
            return context.Indicators.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateIndicator(Indicator indicator)
        {
            context.Indicators.Attach(indicator);
            var entry = context.Entry(indicator);
            entry.Property(x => x.Id).IsModified = false;
            entry.Property(x => x.MeterValue).IsModified = true;
            entry.Property(x => x.Time).IsModified = true;
            entry.Property(x => x.Unit).IsModified = true;
            entry.Property(x => x.UnitName).IsModified = true;
            context.SaveChanges();
        }

        public void DeleteIndicator(int id)
        {
            Indicator indicator = context.Indicators.FirstOrDefault(x => x.Id == id);
            context.Indicators.Remove(indicator);
            context.SaveChanges();
        }

        public void CreateIndicator(Indicator indicator)
        {
            context.Indicators.Add(indicator);
            context.SaveChanges();
        }
        #endregion
    }
}