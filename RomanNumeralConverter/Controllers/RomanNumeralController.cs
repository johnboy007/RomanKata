using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RomanNumeralConverter.Controllers
{
    public class RomanNumeralController : ApiController
    {
        public IHttpActionResult GetRomanNumeral(int number)
        {
            var objRomanNumeral = new Services.RomanNumeral();
            var objRomanNumeralModel = new Models.RomanNumeral
            {
                number = number,
                numeral = objRomanNumeral.generate(number),
                errorMessage = objRomanNumeral.ErrorMessage
            };
            return Ok(objRomanNumeralModel);
        }
    }
}
