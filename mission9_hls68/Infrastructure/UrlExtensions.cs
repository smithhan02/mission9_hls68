using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_hls68.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            //bundles up info about path
          request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
            
    }
}
