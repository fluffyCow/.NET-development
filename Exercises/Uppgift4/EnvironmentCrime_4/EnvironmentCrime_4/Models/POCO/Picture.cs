using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        public String PictureName { get; set; }
        public int ErrandId { get; set; }
    }
}
