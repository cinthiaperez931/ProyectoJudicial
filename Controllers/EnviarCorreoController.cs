using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Trabajo2.Controllers
{
    public class EnviarCorreoController : Controller
    {
        // GET: EnviarCorreo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EnviarCorreo()
        {
            return View();

        }



        [HttpPost]
        public ActionResult EnviarCorreo(string para, string de, string asunto, string mensaje , string password
            , HttpPostedFileBase fichero)
        {
            try { 



                 MailMessage correo = new MailMessage();
                correo.From = new MailAddress(de);
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = mensaje;
               /// MailAddress ms = new MailAddress(copia);
               //// correo.CC.Add(oculta);

                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                String ruta = Server.MapPath("../Temporal");
                fichero.SaveAs(ruta + "\\" + fichero.FileName);

                Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
                correo.Attachments.Add(adjunto);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                ////smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential(de, password);

                smtp.EnableSsl = true;


                smtp.Send(correo);
                ViewBag.Mensaje = "Mensaje enviado correctamente";


                return RedirectToAction("Index");



            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();







        }


    }
}