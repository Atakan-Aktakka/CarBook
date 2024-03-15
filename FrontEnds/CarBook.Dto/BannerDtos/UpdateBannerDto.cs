using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Dto.BannerDtos
{
    public class UpdateBannerDto
    {
        public int bannerID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string videoDescription { get; set; }
        public string videoUrl { get; set; }
    }
}