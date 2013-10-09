using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Concrete
{
    public class EFBodyPhotoRepository : IBodyPhotoRepository
    {
        private EFDBContext context = new EFDBContext();

        private static EFBodyPhotoRepository repo = new EFBodyPhotoRepository();
        public static IBodyPhotoRepository getRepository()
        {
            return repo;
        }

        public IQueryable<BodyPhoto> Photos
        {
            get { return context.Photos; }
        }

        public void SaveBodyPhoto(BodyPhoto photo)
        {
            if (photo.PhotoID == 0)
            {
                context.Photos.Add(photo);
            }
            else
            {
                BodyPhoto dbEntry = context.Photos.Find(photo.PhotoID);
                if (dbEntry != null)
                {
                    dbEntry.UserID = photo.UserID;
                    dbEntry.User = photo.User;
                    dbEntry.MuscleGroup = photo.MuscleGroup;
                    dbEntry.Date = photo.Date;
                    dbEntry.PhotoSource = photo.PhotoSource;
                }
            }
            context.SaveChanges();
        }
    }
}
