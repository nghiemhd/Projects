using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Client.Web.Framework.Extensions
{
    public static class ModelExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return errors;
        }
    }
}
