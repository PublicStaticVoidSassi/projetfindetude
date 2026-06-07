using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Accounts
{
    public static class AccountConstraints
    {
        public static class Name
        {
            public static int MaxLength = 128;
            public static int MinLength = 2;
        }
        public static class Description
        {
            public static int MaxLength = 255;
            public static int MinLength = 0;
        }
    }
}
