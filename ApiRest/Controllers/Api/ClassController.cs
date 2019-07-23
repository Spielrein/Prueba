using Business.Data.Api;
using Business.Model.Api;
using System.Web.Http;

namespace ApiRest.Controllers.Api
{
    [RoutePrefix("Api/Class")]
    public class ClassController : ApiController
    {
        /// <summary>
        /// Controlador que permite obtener el horario semanal de un estudiante 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario semanal
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonWeek")]
        public IHttpActionResult Week([FromBody]TokenModel token)
        {
            bool valido = false;

            valido = TokenData.ValidarToken(token.Token);

            if (valido == true)
            {
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Week(cad);
                return Ok(consulta);
            }
                return NotFound();

            }

        /// <summary>
        /// Controlador que permite obtener el horario del alumno segun un dia específico
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonDay")]
        public IHttpActionResult Days([FromBody]TokenModel token)
        {
            
            bool valido = false;
          
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Days(cad);
                return Ok(consulta);
            }
            
            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia lunes
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonMonday")]
        public IHttpActionResult Monday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Lunes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia martes
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonTuesday")]
        public IHttpActionResult Tuesday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Martes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia miercoles
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonWednesday")]
        public IHttpActionResult Wednesday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Miercoles";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia jueves
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonThursday")]
        public IHttpActionResult Thursday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Jueves";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia viernes
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonFriday")]
        public IHttpActionResult Friday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Viernes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        /// <summary>
        /// Controlador que permite obtener el horario de un estudiante para el dia sabado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// Lista de horario por dia
        /// Matricula, Nombre, Apellidos, Grado, Materia, Clave materia, Materia, Hora de impartición, Profesor, Aula
        /// </returns>
        [HttpPost]
        [Route("LessonSaturday")]
        public IHttpActionResult Saturday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Sabado";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad,dia);
                return Ok(consulta);
            }

            return NotFound();
        }
    }
}
