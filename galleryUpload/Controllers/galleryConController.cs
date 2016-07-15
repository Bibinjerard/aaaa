using galleryUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace galleryUpload.Controllers
{
    public class galleryConController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel model)
        {
            var validImageTypes = new string[]
            {
        "image/gif",
        "image/jpeg",
        "image/pjpeg",
        "image/png"
            }

    if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.
            }

            if (ModelState.IsValid)
            {
                var image = new Gallery
                {
                    Title = model.Title,
                    AltText = model.AltText,
                    Caption = model.Caption
                }
        
        if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/uploads"
            var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    image.ImageUrl = imageUrl;
                }

                db.Create(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        // GET: galleryCon
        public ActionResult Index()
        {
            return View();
        }
    }
}