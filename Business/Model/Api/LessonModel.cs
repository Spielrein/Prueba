using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class LessonModel
    {
        public string estudios { get; set; }
        public string nombre { get; set; }
        public string apep { get; set; }
        public string apem { get; set; }
        public string salon { get; set; }
        public string materia { get; set; }
        public string dia { get; set; }
        public TimeSpan horain { get; set; }
        public TimeSpan horafin { get; set; }
        public int credito { get; set; }
        public string clavemat { get; set; }
        public string opcioncur { get; set; }
    }
}