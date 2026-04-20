using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Constraints
{
    public static class EmailAddress
    {
        public const int MinLength = 5;     // a@b.c (absolute minimal realistic)
        public const int MaxLength = 320;   // RFC 5321 recommended max
    }
}
