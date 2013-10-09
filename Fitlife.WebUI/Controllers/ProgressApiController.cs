using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fitlife.Domain.Entities;
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Concrete;

namespace Fitlife.WebUI.Controllers
{
    public class ProgressApiController : ApiController
    {
        IBodyPhotoRepository repo = EFBodyPhotoRepository.getRepository();

        public ProgressApiController()
        {
        }

        public ProgressApiController(IBodyPhotoRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<BodyPhoto> GetAllBodyPhotos()
        {
            return repo.Photos;
        }


        public void PostBodyPhoto(BodyPhoto item)
        {
            repo.SaveBodyPhoto(item);
        }
    }
}
