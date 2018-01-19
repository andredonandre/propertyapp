using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyApp.DAL;
using System.Web.Script.Serialization;
using PropertyApp.Models;
using System.Net.Http;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PropertyApp.Controllers
{
    public class PropertyController : Controller
    {
        public ActionResult PropertyList()
        {
            return View();
        }

        public ActionResult PropertyNew()
        {
            return View();
        }

        public ActionResult PropertyDetails()
        {
           return View();
        }

        public JsonResult Properties()
        {
            try
            {
                var db = DataContext.GetContext();
                var properties = db.Properties.ToList();

                foreach (var p in properties)
                {
                    p.ImagePaths = Directory.GetFiles(Server.MapPath("~/PropertyImages/" + p.id + "/"));
                }
                JsonResult result = new JsonResult
                {
                    Data = properties,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                return result;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public JsonResult Property(string id)
        {
            try
            {
                var db = DataContext.GetContext();
                var property = db.Properties.Where(p => p.id.ToString() == id).FirstOrDefault();

                property.ImagePaths = Directory.GetFiles(Server.MapPath("~/PropertyImages/" + property.id + "/"));

                JsonResult result = new JsonResult
                {
                    Data = property,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public void New(Property Prop)
        {
            try
            {
                var db = DataContext.GetContext();
                Prop.id = Guid.NewGuid();

                if (Prop.ImagePaths != null)
                {
                    foreach (var path in Prop.ImagePaths)
                    {
                        var filename = Path.GetFileName(path);
                        var imageDirectory = Server.MapPath("~/PropertyImages/");
                        Directory.CreateDirectory(imageDirectory + Prop.id + "/");
                        var destination = imageDirectory + "/" + Prop.id + "/" + filename;
                        System.IO.File.Copy(path, destination, true);
                    }
                }

                db.Properties.Add(Prop);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(string id)
        {
            try
            {
                var db = DataContext.GetContext();
                var property = db.Properties.Where(p => p.id.ToString() == id).FirstOrDefault();

                db.Properties.Remove(property);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}