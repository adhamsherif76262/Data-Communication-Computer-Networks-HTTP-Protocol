using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTTPServer
{
    public enum RequestMethod
    {
        GET,
        POST,
        HEAD
    }

    public enum HTTPVersion
    {
        HTTP10,
        HTTP11,
        HTTP09
    }

    class Request
    {
        string[] requestLines;
        RequestMethod method;
        public string relativeURI;
        Dictionary<string, string> headerLines;

        public Dictionary<string, string> HeaderLines
        {
            get { return headerLines; }
        }

        HTTPVersion httpVersion;
        string requestString;
        string[] contentLines;

        public Request(string requestString)
        {
            this.requestString = requestString;
        }
        /// <summary>
        /// Parses the request string and loads the request line, header lines and content, returns false if there is a parsing error
        /// </summary>
        /// <returns>True if parsing succeeds, false otherwise.</returns>
        public bool ParseRequest()
        {   

            throw new NotImplementedException();

            /* //TODO: parse the receivedRequest using the \r\n delimeter */
            string[] stringSeparators = new string[] { "\r\n" };
            contentLines = requestString.Split(stringSeparators, StringSplitOptions.None);
            string type = contentLines[0];
            string url = contentLines[1];
            string host = contentLines[4];

            if (contentLines.Length >= 3) 
            {
                return true;
           
            }

            /*  //*********************************************************************************************
               // check that there is atleast 3 lines: Request line, Host Header, Blank line (usually 4 lines with the last empty line for empty content)
              // Parse Request line
             // Validate blank line exists
            // Load header lines into HeaderLines dictionary
            */

            ParseRequestLine();
            ValidateIsURI(relativeURI);
            LoadHeaderLines();
            ValidateBlankLine();
        }

        private bool ParseRequestLine()
        {
            string[] requestline_content = contentLines[0].Split('/');

            throw new NotImplementedException();
        }

        private bool ValidateIsURI(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute);
        }

        private bool LoadHeaderLines()
        {
            throw new NotImplementedException();
        }

        private bool ValidateBlankLine()
        {
            throw new NotImplementedException();
        }

    }
}
