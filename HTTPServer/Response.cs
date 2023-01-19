using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{

    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        NotFound = 404,
        BadRequest = 400,
        Redirect = 301
    }

    class Response
    {
        string responseString;
        public string ResponseString
        {
            get
            {
                return responseString;
            }
        }
        StatusCode code;
        List<string> headerLines = new List<string>();
        public Response(StatusCode code, string contentType, string content, string redirectoinPath)
        {

           // throw new NotImplementedException();

            headerLines.Add("text/html");
            // TODO: Add headlines (Content-Type, Content-Length,Date, [location if there is redirection])


            // TODO: Create the request string
            
        }

        private string GetStatusLine(StatusCode code)
        {
            /*// TODO: Create the response status line and return it*/

            HTTPVersion hTTPVersion = new HTTPVersion();
            string statusLine = string.Empty;
            if (code == StatusCode.OK)
            {
                switch (hTTPVersion)
                {
                    case HTTPVersion.HTTP10: { statusLine = "HTTP/1.0 200 ok"; break; }
                    case HTTPVersion.HTTP11: { statusLine = "HTTP/1.1 200 ok"; break; }
                    case HTTPVersion.HTTP09: { statusLine = "HTTP/0.9 200 ok"; break; }
                    default: { statusLine = string.Empty; break; }
                }
            }
            else if (code == StatusCode.InternalServerError)
            {
                switch (hTTPVersion)
                {
                    case HTTPVersion.HTTP10: { statusLine = "HTTP/1.0 500 InternalServerError"; break; }
                    case HTTPVersion.HTTP11: { statusLine = "HTTP/1.1 500 InternalServerError"; break; }
                    case HTTPVersion.HTTP09: { statusLine = "HTTP/0.9 500 InternalServerError"; break; }
                    default: { statusLine = string.Empty; break; }
                }
            }
            else if (code == StatusCode.NotFound)
            {
                switch (hTTPVersion)
                {
                    case HTTPVersion.HTTP10: { statusLine = "HTTP/1.0 404 NotFound"; break; }
                    case HTTPVersion.HTTP11: { statusLine = "HTTP/1.1 404 NotFound"; break; }
                    case HTTPVersion.HTTP09: { statusLine = "HTTP/0.9 404 NotFound"; break; }
                    default: { statusLine = string.Empty; break; }
                }
            }
            else if (code == StatusCode.InternalServerError)
            {
                switch (hTTPVersion)
                {
                    case HTTPVersion.HTTP10: { statusLine = "HTTP/1.0 400 BadRequest"; break; }
                    case HTTPVersion.HTTP11: { statusLine = "HTTP/1.1 400 BadRequest"; break; }
                    case HTTPVersion.HTTP09: { statusLine = "HTTP/0.9 400 BadRequest"; break; }
                    default: { statusLine = string.Empty; break; }
                }
            }
            else if(code == StatusCode.Redirect)
            {
                switch (hTTPVersion)
                {
                    case HTTPVersion.HTTP10: { statusLine = "HTTP/1.0 301 Redirect"; break; }
                    case HTTPVersion.HTTP11: { statusLine = "HTTP/1.1 301 Redirect"; break; }
                    case HTTPVersion.HTTP09: { statusLine = "HTTP/0.9 301 Redirect"; break; }
                    default: { statusLine = string.Empty; break; }
                }
            }
            return statusLine;
        }
    }
}
