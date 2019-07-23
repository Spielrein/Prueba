using ApiRest.Models;
using ApiRest.Providers;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("Api/Lesson")]
    public class LessonsController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        /// <summary>
        /// Controlador que permite crear un horario
        /// </summary>
        /// <param name="lessons"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]LessonModel lessons)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Crear(lessons.Dia, lessons.EmpleadosId, lessons.HoraIn, lessons.HoraFin, lessons.AulaId, lessons.MateriaId,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los horarios 
        /// </summary>
        /// <returns>Lista de horarios</returns>
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Mostrar(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar infromacion de un horari segun su id
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns>Lista de tipo horario</returns>
        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(LessonModel lesson)
        {
            var consulta = LessonData.MostrarActualizar(lesson.LessonId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite determinar el dia en el que se efectua el horario
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Day")]
        public IHttpActionResult Day(LessonModel lesson)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.GetDia(lesson.Dia,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlaor que permite actualizar un horario segun su id
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(LessonModel lesson)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Actualizar(lesson.LessonId, lesson.Dia, lesson.EmpleadosId, lesson.HoraIn, lesson.HoraFin, lesson.AulaId, lesson.MateriaId,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite eliminar un horario
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(LessonModel lesson)
        {
            var consulta = LessonData.Eliminar(lesson.LessonId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los profesores registrados
        /// </summary>
        /// <returns>Lista de profesores</returns>
        [HttpPost]
        [Route("ShowEmployer")]
        public IHttpActionResult GetEmployer()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerEmpleado(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Conrolador que permite mostrar las aulas registradas
        /// </summary>
        /// <returns>Lista de aulas</returns>
        [HttpPost]
        [Route("ShowClassroom")]
        public IHttpActionResult GetAula()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerAula(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar las materias registradas
        /// </summary>
        /// <returns>Lista de tipo materia</returns>
        [HttpPost]
        [Route("ShowSubject")]
        public IHttpActionResult GetMateria()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerMateria(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los grupos tegistrados
        /// </summary>
        /// <returns>Lista de grupos</returns>
        [HttpPost]
        [Route("ShowGroup")]
        public IHttpActionResult GetGrupo()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerGrupo(u);
            return Ok(consulta);
        }
        
    }
}
