using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.DTO
{
    public class NewsDTO
    {
        public string Title { get; set; }
        public string NavigateUrl { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public string Created { get; set; }
        public string Category { get; set; }
    }
}
