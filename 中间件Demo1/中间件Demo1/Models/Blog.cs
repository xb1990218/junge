using System;
using System.Collections.Generic;

namespace 中间件Demo1.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyMd { get; set; }
        public int? VisitNum { get; set; }
        public string CaBh { get; set; }
        public string CaName { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }
    }
}
