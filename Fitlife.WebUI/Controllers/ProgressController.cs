﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.WebUI.Filters;
using Fitlife.Domain.Abstract;
using Fitlife.WebUI.Models;
using Fitlife.Domain.Entities;
using System.Net;

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

        [HttpPost]
        public ActionResult SaveBodyPhoto(BodyPhoto photo)
        {
            photo.UserID = ((User)Session["user"]).UserID;
            photoRepository.SaveBodyPhoto(photo);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
