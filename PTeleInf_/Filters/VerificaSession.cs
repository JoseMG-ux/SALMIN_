using PTeleInf_.Controllers;
using PTeleInf_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTeleInf_.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {

        private USUARIO oUsuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                oUsuario = (USUARIO)HttpContext.Current.Session["User"];
                if(oUsuario == null)
                {
                    if(filterContext.Controller is laboratorioDBController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/laboratorioDB/Login");
                    }
                }
            }
            catch(Exception)
            {

            }
            
        }

    }
}