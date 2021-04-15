using PTeleInf_.Controllers;
using PTeleInf_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTeleInf_.Filters
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizerUser : AuthorizeAttribute
    {
        private USUARIO oUsuario;
        private laboratorioDBEntities1 db = new laboratorioDBEntities1();
        private int idOperacion;
    }
}