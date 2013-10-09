using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.WebUI.Filters;
using Fitlife.Domain.Abstract;
using Fitlife.WebUI.Models;

namespace Fitlife.WebUI.Controllers
{
    [CustomAuth]
    public class ProgressController : Controller
    {
        private IBodyPhotoRepository photoRepository;


        public ProgressController(IBodyPhotoRepository repository)
        {
            photoRepository = repository;
        }

        //
        // GET: /Progress/

        public ActionResult Index()
        {
            BodyPhotoViewModel model = new BodyPhotoViewModel();
            model.PhotosByMuscleGroup = photoRepository.Photos.GroupBy(photo => photo.MuscleGroup);
            return View(model);
        }

    }
}
