using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Dto.ServiceDtos
{
    public class ResultServiceDto
    {
        public int ServiceID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }
    }
}