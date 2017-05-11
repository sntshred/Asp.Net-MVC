using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace TokenAuthentication.Facebook
{
    public class FaceebookBackchannel : HttpClientHandler

    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.Contains("/outh"))
            {
                request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token","&access_token"));
            }

            return await base.SendAsync(request, cancellationToken);

        }
    }
      
}