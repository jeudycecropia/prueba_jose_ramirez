using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AndresRamirezPTC.Models;
using AndresRamirezPTC.Filters;
using System.Web.Security;

namespace AndresRamirezPTC.Controllers
{
    public class LogOutController : ApiController
    {
        private PerfilUsuarioContext db = new PerfilUsuarioContext();

        
        // DELETE api/LogOut/5
        public HttpResponseMessage DeleteUser(int id)
        {
            FormsAuthentication.SignOut();

            User user = db.Users.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Users.Remove(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}