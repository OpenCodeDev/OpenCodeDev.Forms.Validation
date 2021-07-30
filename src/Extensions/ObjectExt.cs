using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.Forms.Validation.Extensions
{
    public static class ObjectExt
    {
        /// <summary>
        /// Quickly validate a form object (mostly on server side and will not provide error messages)
        /// </summary>
        public static bool ValidateContext(this object context)
        {
            try
            {
                var ctx = new ValidationContext(context);
                bool rez = Validator.TryValidateObject(context, ctx, null, true);
                return rez;
            }
            catch
            {

                return false;

            }

        }
    }
}
