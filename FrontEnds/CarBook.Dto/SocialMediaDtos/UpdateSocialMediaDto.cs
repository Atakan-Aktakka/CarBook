using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Dto.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}