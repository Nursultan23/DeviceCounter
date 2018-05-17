using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceControl.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private DataRepository repository = new DataRepository();
        public ActionResult Index()
        {
            var model = repository.GetData();
            return View(model);
        }
   
        public JsonResult UpdateModeStatus(int id, string status)
        {
            AutomaticMode mode = new AutomaticMode { Id = id, Status = status=="true", Time = DateTime.Now };
            repository.UpdateMode(mode);
            return Json("true");
        }

        #region device
        [HttpGet]
        public ActionResult AddDevice()
        {
            return View(new Device());
        }
        [HttpPost]
        public ActionResult AddDevice(Device model)
        {
            try
            {
                model.ChangingMoment = DateTime.Now;
                repository.CreateDevice(model);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
            
        }

        public ActionResult DeleteDevice(int id)
        {
            repository.DeleteDevice(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateDevice()
        {
            //repository.CreateDevice();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditDevice(int id)
        {
            var device = repository.GetDeviceById(id);
            return View(device);
        }

        [HttpPost]
        public ActionResult EditDevice(Device model)
        {
            try
            {
                model.ChangingMoment = DateTime.Now;
                repository.UpdateDevice(model);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ViewBag.DeviceIsEdit = false;
                return View(ViewBag);
            }
            
            
        }

        [HttpPost]
        public JsonResult UpdateDeviceStatus(int id)
        {
            var device = repository.GetDeviceById(id);
            device.Status = device.Status ? false : true;
            repository.UpdateDevice(device);
            return Json("true");
        }

        #endregion

        #region indicator
        [HttpGet]
        public ActionResult AddIndicator()
        {
            return View(new Indicator());
        }
        [HttpPost]
        public ActionResult AddIndicator(Indicator model)
        {
            try
            {
                model.Time = DateTime.Now;
                repository.CreateIndicator(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult CreateIndicator()
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteIndicator(int id)
        {
            repository.DeleteIndicator(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditIndicator(int id)
        {
            var indicator = repository.GetIndicatorById(id);
            return View(indicator);
        }

        [HttpPost]
        public ActionResult EditIndicator(Indicator model)
        {
            try
            {
                model.Time = DateTime.Now;
                repository.UpdateIndicator(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        #endregion
    }
}