using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace HTTPServer
{
    class Server
    {
        Socket serverSocket;

        public Server(int portNumber, string redirectionMatrixPath)
        {
            this.LoadRedirectionRules(redirectionMatrixPath);
            this.serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            /*
            //TODO: call this.LoadRedirectionRules passing redirectionMatrixPath to it
            //TODO: initialize this.serverSocket
            */
        }

        public void StartServer()
        {
            /*
                // TODO: Listen to connections, with large backlog.
                // TODO: Accept connections in while loop and start a thread for each connection on function "Handle Connection"
            */

            serverSocket.Listen(100);

            while (true)
            {
                /* 
                        //TODO: accept connections and start thread for each accepted connection.
                       //Accept a client Socket (will block until a client connects)
                      //RemoteEndPoint Gets the IP address and Port number of the client
                     //Create a thread that works on ClientConnection.HandleConnection 	method
                */
                Socket clientSocket = this.serverSocket.Accept();
                Console.WriteLine("New client accepted: {0}", clientSocket.RemoteEndPoint);
                ThreadPool.QueueUserWorkItem(HandleConnection, clientSocket);
            }

        }

        public void HandleConnection(object obj)
        {
            // TODO: Create client socket 
            Socket clientSock = (Socket)obj;
            // set client socket ReceiveTimeout = 0 to indicate an infinite time-out period
            clientSock.ReceiveTimeout = 0;
            // TODO: receive requests in while true until remote client closes the socket.
            while (true)
            {
                try
                {
                    clientSock.SendTimeout = 0;
                    /*
                        // TODO: Receive request

                        // TODO: break the while loop if receivedLen==0

                        // TODO: Create a Request object using received request string

                        // TODO: Call HandleRequest Method that returns the response

                        // TODO: Send Response back to client
                    */
                    string welcome = "Welcome to my test server";
                    byte[] data = Encoding.ASCII.GetBytes(welcome);
                    clientSock.Send(data);
                    int receivedLength;

                    data = new byte[1024];
                    receivedLength = clientSock.Receive(data);

                    if (receivedLength == 0)
                    {
                        Console.WriteLine("Client: {0} ended the connection", clientSock.RemoteEndPoint);
                        break;
                    }
                    Console.WriteLine("Received: {0} from Client: {1}" ,Encoding.ASCII.GetString(data, 0, receivedLength), clientSock.RemoteEndPoint);
                    clientSock.Send(data, 0, receivedLength, SocketFlags.None);


                }
                catch (Exception ex)
                {
                    Logger Log = new Logger();
                   // Log.LogException();
                    // TODO: log exception using Logger class
                }

            }

            clientSock.Close();
            /*
            // TODO: close client socket
            */
        }

        Response HandleRequest(Request request)
        {
            throw new NotImplementedException();
            string content;
            try
            {
             
                //TODO: check for bad request 

                //TODO: map the relativeURI in request to get the physical path of the resource.

                //TODO: check for redirect

                //TODO: check file exists

                //TODO: read the physical file

                // Create OK response
            }
            catch (Exception ex)
            {
                // TODO: log exception using Logger class
                // TODO: in case of exception, return Internal Server Error. 
            }
        }

        private string GetRedirectionPagePathIFExist(string relativePath)
        {
            // using Configuration.RedirectionRules return the redirected page path if exists else returns empty
            
            return string.Empty;
        }

        private string LoadDefaultPage(string defaultPageName)
        {
            string filePath = Path.Combine(Configuration.RootPath, defaultPageName);
            // TODO: check if filepath not exist log exception using Logger class and return empty string
            
            // else read file and return its content
            return string.Empty;
        }

        private void LoadRedirectionRules(string filePath)
        {
            try
            {
                // TODO: using the filepath paramter read the redirection rules from file 
                // then fill Configuration.RedirectionRules dictionary 
            }
            catch (Exception ex)
            {
                // TODO: log exception using Logger class
                Environment.Exit(1);
            }
        }
    }
}
