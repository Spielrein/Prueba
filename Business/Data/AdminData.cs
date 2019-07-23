using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Model;
using Data;


namespace Business.Data
{
    public class AdminData
    {
        /// <summary>
        /// Metodo que permite crear un nuevo admin
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="paterno"></param>
        /// <param name="materno"></param>
        /// <param name="user"></param>
        /// <param name="contra"></param>
        /// <param name="institutom"></param>
        /// <param name="imagen"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string nombre, string paterno, string materno, string user, string contra, int institutom, string imagen)
        {

            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;

      
            var g = new Admin
            {

                Name = nombre,
                LastNameP = paterno,
                LastNameM = materno,
                Users = user,
                Pass = contra,
                InstitutionID = institutom,
                Photo = imagen,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Admins.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;
            
            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar los adminitradores registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista de tipo admin</returns>
        public static List<AdminAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var po = user;
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from adm in Contexto.Admins
                                     join inst in Contexto.Institutions on adm.InstitutionID equals inst.InstitutionID
                                     where adm.Status == "1" 
                                     select new AdminAllModel
                                     {
                                         AdminsID = adm.AdminsID,
                                         Name = adm.Name,
                                         LastNameP = adm.LastNameP,
                                         LastNameM = adm.LastNameM,
                                         Users = adm.Users,
                                         Pass = adm.Pass,
                                         InstitutionName = inst.Name,
                                         Photo = adm.Photo

                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from adm in Contexto.Admins
                                     join inst in Contexto.Institutions on adm.InstitutionID equals inst.InstitutionID
                                     where adm.Status == "1" && adm.Users == user
                                     select new AdminAllModel
                                     {
                                         AdminsID = adm.AdminsID,
                                         Name = adm.Name,
                                         LastNameP = adm.LastNameP,
                                         LastNameM = adm.LastNameM,
                                         Users = adm.Users,
                                         Pass = adm.Pass,
                                         InstitutionName = inst.Name,
                                         Photo = adm.Photo

                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite mostrar los adminitradores registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista de tipo admin</returns>
        public static List<AdminAllModel> MostrarUser(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
           
                {
                    var Resultado = (from adm in Contexto.Admins
                                     join inst in Contexto.Institutions on adm.InstitutionID equals inst.InstitutionID
                                     where adm.Status == "1" && adm.Users == user
                                     select new AdminAllModel
                                     {
                                         AdminsID = adm.AdminsID,
                                         Name = adm.Name,
                                         LastNameP = adm.LastNameP,
                                         LastNameM = adm.LastNameM,
                                         Users = adm.Users,
                                         Pass = adm.Pass,
                                         InstitutionName = inst.Name,
                                         Photo = adm.Photo

                                     }).ToList();
                    return Resultado;
                }
                
            }
        }
        /// <summary>
        /// Metodo que permite mostrar datos de un adminitrador segun su id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo admin</returns>
        public static List<AdminAllModel> Mostrar2(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
               
                    var Resultado = (from adm in Contexto.Admins
                                     join inst in Contexto.Institutions on adm.InstitutionID equals inst.InstitutionID
                                     where adm.AdminsID.Equals(id)
                                     select new AdminAllModel
                                     {
                                         
                                         Name = adm.Name,
                                         LastNameP = adm.LastNameP,
                                         LastNameM = adm.LastNameM,
                                         Users = adm.Users,
                                         Pass = adm.Pass,
                                         InstitutionID=adm.InstitutionID,
                                         InstitutionName = inst.Name,
                                         Photo = adm.Photo

                                     }).ToList();
                    return Resultado;
                }
        }

        /// <summary>
        /// Metodo que permite eliminar un administrador segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int id)
        {
            Boolean existe = false;
            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Admins.First(d => d.AdminsID == id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// Metodo para mostrar datos de un administrador segun su id
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns>lista tipo admin</returns>
        public static List<AdminAllModel> UpdateShow(string user, string pass)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from Admin in Contexto.Admins
                                 where Admin.Users == user && Admin.Pass == pass
                                 select new AdminAllModel
                                 {
                                     AdminsID = Admin.AdminsID,
                                     Name = Admin.Name,
                                     LastNameP = Admin.LastNameP,
                                     LastNameM = Admin.LastNameM,
                                     Users = Admin.Users,
                                     Pass = Admin.Pass,
                                     InstitutionID = Admin.InstitutionID,
                                     Photo = Admin.Photo
                                 }).ToList();
                return Resultado;
            }
        }


        /// <summary>
        /// MEtodo que permite actualizar un admin segun su id
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="lastp"></param>
        /// <param name="lastm"></param>
        /// <param name="useradmin"></param>
        /// <param name="pass"></param>
        /// <param name="inst"></param>
        /// <param name="ph"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean UpdateRegister(int id, string nombre, string lastp, string lastm, string ph, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                Boolean existe = false;

                AppTecBDEntities data = new AppTecBDEntities();

                //var identificador = data.Admins.Select(z => z.AdminsID).Where(q)


                var consulta = data.Admins.First(a => a.AdminsID == id);

                if (consulta != null && ph != null)
                {

                    consulta.Name = nombre;
                    consulta.LastNameP = lastp;
                    consulta.LastNameM = lastm;
                    consulta.Photo = ph;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;

                }
                else if (consulta != null && ph == null)
                {
                    consulta.Name = nombre;
                    consulta.LastNameP = lastp;
                    consulta.LastNameM = lastm;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;
                }
                return existe;
            }
        }


        /// <summary>
        /// Metodo para mostrar las insituciones registradas
        /// </summary>
        /// <returns>Lista tipo instituciones</returns>
        public static List<AdminInstitutionModel> ObtenerInstitution()
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions
                                 select new AdminInstitutionModel
                                 {
                                     AdminsID = Institution.InstitutionID,
                                     Name = Institution.Name
                                 }).ToList();
                return Resultado;
            }
        }
    }
}