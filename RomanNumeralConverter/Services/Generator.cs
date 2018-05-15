using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomanNumeralConverter.Services
{
    /// <summary>
    /// Create an interface for loosely-coupled applications
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Generate method that returns a string from an int param
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        string generate(int number);
    }
}