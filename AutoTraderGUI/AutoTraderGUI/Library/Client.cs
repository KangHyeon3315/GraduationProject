using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AutoTraderGUI.Library
{
    class Client
    {
        public Role role;
        public Socket sock;

        public Queue ReceiveQueue;
        public Thread ReceiveTh;

        LogInterface logInterface = null;
        public Client(Socket sock, LogInterface logInterface, Role role = Role.None)
        {
            
            this.logInterface = logInterface;
            this.sock = sock;

            ReceiveQueue = new Queue();
            this.role = role;

            ReceiveTh = new Thread(new ThreadStart(Receive));
            ReceiveTh.Start();

            while (true)
            {
                if (this.role != Role.None)
                {
                    break;
                }
                Thread.Sleep(100);
            }

        }

        public void Send(string msg)
        {
            try
            {
                if (sock.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    // 데이터 길이를 클라이언트로 전송한다.
                    sock.Send(BitConverter.GetBytes(data.Length));
                    // 데이터를 전송한다.
                    sock.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "Send", "None", ex.Message);
            }
        }

        void Receive()
        {

            while (sock != null && sock.Connected)
            {
                string msg = ReceiveData();

                if (msg == "")
                {
                    continue;
                }

                string[] splitedMsg = msg.Split(';');
                
                //logInterface.WriteLog(splitedMsg[0], "Recv", "None", msg);
                if (splitedMsg[0] == "Role")
                {
                    string tmp = splitedMsg[1];
                    tmp.Remove(tmp.Length - 1);
                    tmp.Remove(tmp.Length - 1);

                    if (tmp == "APICollector")
                    {
                        role = Role.APICollector;
                        Send("Role;OK");
                    }
                    else if(tmp == "DartCollector")
                    {
                        role = Role.DartCollector;
                        Send("Role;OK");
                    }
                    else
                    {
                        logInterface.WriteLog("Log", "None", "None", "Unknown Role's process : " + tmp);
                    }

                }
                else
                {
                    ReceiveQueue.Add(msg);
                }

            }

        }

        private string ReceiveData()
        {
            string msg = "";
            try
            {
                if (!sock.Connected)
                {
                    return "";
                }

                byte[] data = new byte[4];

                sock.Receive(data, 4, SocketFlags.None);
                Array.Reverse(data);

                int length = BitConverter.ToInt32(data, 0);
                if (length == 0)
                {
                    return "";
                }

                data = new byte[length + 1];
                
                sock.Receive(data, data.Length, SocketFlags.None);
                //Array.Reverse(data);

                msg = Encoding.UTF8.GetString(data);

                return msg;
            }
            catch (ThreadAbortException)
            {
                return "";
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "ReceiveData", "None", ex.Message);
                return "";
            }
        }
    }
}
