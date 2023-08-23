using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Onigashimaxxx.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace Onigashimaxxx.Controllers
{
    public class AccesoController : Controller
    {
        static string chain = @"Data source=MATIAS-PC\SQLEXPRESS;Initial Catalog=dB_ACCESO;Integrated Security=True";

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        // GET: Acceso
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario)
        {
            bool registrado;
            string mensaje;
            if (oUsuario.Contraseña == oUsuario.ConfirmarContraseña)
            {
                oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }
            using (SqlConnection con = new SqlConnection(chain))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario",con);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction= ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }
            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);

            using (SqlConnection con = new SqlConnection(chain))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (oUsuario.IdUsuario != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }



        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding e = Encoding.UTF8;
                byte[] result = hash.ComputeHash(e.GetBytes(texto));
                foreach (byte b in result)
                    Sb.Append(b.ToString("X2"));
            }
            return Sb.ToString();
        }
    }
}