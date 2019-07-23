using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class LessonDayModel
    {
        public string salon { get; set; }
        public string mat { get; set; }
        public TimeSpan horain { get; set; }
        public TimeSpan horafin { get; set; }
        public string estud { get; set; }
        public string nom { get; set; }
        public string ap { get; set; }
        public string am { get; set; }
    }
}