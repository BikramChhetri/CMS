using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace CMSApp.ExceptionLogger
{
    public class LogWriter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var filePath = HttpContext.Current.Server.MapPath("~/ErrorLog/");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            var file = filePath + DateTime.Today.ToString("dd-MM-yy") + "_LOG.txt";
            using (StreamWriter sw = new StreamWriter(file,true))
            {
                var error = actionExecutedContext.Exception;
                sw.WriteLine($"{error.Message} Stacktrace: {error.StackTrace}");
            }
        }
    }
}