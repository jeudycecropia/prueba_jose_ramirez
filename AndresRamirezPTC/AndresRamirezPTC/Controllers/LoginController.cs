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
using cecropiaRestFulAPI.Filters;
using System.Web.Caching;
using System.Net.Http.Headers;


namespace AndresRamirezPTC.Controllers
{
    
    public class LoginController : ApiController
    {
      
        private PerfilUsuarioContext db = new PerfilUsuarioContext();

       
        // GET api/Login/5

        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Login/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (ModelState.IsValid && id == user.Id)
            {
                db.Entry(user).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Login
        public HttpResponseMessage Post(User user)
        {
           
            var usuario = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);
            var userDB = usuario.SingleOrDefault();


            if (userDB == null)
            {
               
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {

                    Content = new JsonContent(new {   Success = false, Token = "Usuario no existe", Message = "Invalid login"  })
                };
            }
            else
            {
                Guid token;
                token = Guid.NewGuid();
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                var resp = new HttpResponseMessage(HttpStatusCode.Created);
            
                resp.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { Success = true, Token = token, Message = "Success" }));
                return resp;

            }

        }


        // DELETE api/Login/5
        public HttpResponseMessage DeleteUser(int id)
        {
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