using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Inventory.Common.Types
{
    public class AmCartException : Exception
    {
        public AmCartException() : base() { }

        public AmCartException(string message) : base(message) { }

        public AmCartException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
