using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.URLs
{
    public static class URLConstraints
    {
        // RFC 3986 does NOT define a strict max, but browsers/servers do.
        // 2048 is a widely accepted practical limit (IE + many systems).
        public const int MaxLength = 2048;

        // Very small but realistic minimum (e.g. https://a.io)
        public const int MinLength = 4;
    }
}
