using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIBSAPIMarket.Client.Exceptions
{
    public class SIBSAPIException : Exception
    {
        public SIBSAPIException(params (string code, string details)[] errors)
            : base(string.Join("\r\n", errors.Select(error => $"{error.code} - {error.details}")))
        {
        }
    }
}
