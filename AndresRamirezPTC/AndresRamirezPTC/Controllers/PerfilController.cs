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

namespace AndresRamirezPTC.Controllers
{
    public class PerfilController : ApiController
    {
        private PerfilUsuarioContext db = new PerfilUsuarioContext();

        // GET api/Login
        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/Perfil/5
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Perfil/5
          [MethNotAllowExceptionFilterAttribute]
        public HttpResponseMessage PutUser(int id, User user)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        // POST api/Perfil
          [MethNotAllowExceptionFilterAttribute]
        public HttpResponseMessage PostUser(User user)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        // DELETE api/Perfil/5
          [MethNotAllowExceptionFilterAttribute]
        public HttpResponseMessage DeleteUser(int id)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}