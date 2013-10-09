using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fitlife.Domain.Entities;

namespace Fitlife.WebUI.Models
{
    public class BodyPhotoViewModel
    {
        public IEnumerable<IGrouping<string, BodyPhoto>> PhotosByMuscleGroup { get; set; }
    }
}