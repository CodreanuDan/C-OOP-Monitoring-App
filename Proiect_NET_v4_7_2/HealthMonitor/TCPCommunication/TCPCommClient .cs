using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonReferences;
using System.Globalization;
using System.Threading;
using System.Net.Sockets;
using System.Net;



namespace TCPCommunication
{
    public class TCPCommClient : IDisposable
    {

        private string _serverIP = String.Empty;
        protected bool _running = false;
        protected Int16 _port = 1020;
        protected List<Thread> myThreadList = new List<Thread>();

        /*************************_DISPOSE_Function_********************/
        public void Dispose()
        {
            try
            {
                foreach (Thread thread in myThreadList)
                {
                    thread.Abort();
                }
                myThreadList.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception("Error on closing TCP client connection ->" + ex.Message);
            }
        }

        #region constructors

        private TCPCommClient() { }
        
        public TCPCommClient(string serverIP)
        {
            _serverIP = serverIP;
        }

        #endregion

       
        /***************_Send_Signal_Data-Primeste_valori_de_la_senzori_*****************/
        public void SendSignalData( string patientCode, string key, DateTime timestamp, double signalValue ) 
        {
            try
            {
                string signalValuePackedToString =
                    BuildPacketStringSignalValue(patientCode, key, timestamp, signalValue);
                this.SendSignalText(signalValuePackedToString);
            }
            catch (Exception ex) 
            {
                throw new Exception(" TCP client error on sending signalValue to the server system -->" + ex.Message);
            }
        }

        private string BuildPacketStringSignalValue(string patientCode, string key, DateTime timestamp, double signalValue)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("#");
            builder.Append(key);
            builder.Append("," + timestamp.ToString("dd-MMM-yyyy HH:mm:ss"));
            builder.Append("," + patientCode);
            builder.Append("," + signalValue.ToString("0.00", CultureInfo.InvariantCulture));
            builder.Append("#" );

            return builder.ToString();  
        }

        /********************************************************************************/
        

        /****************************_Send_Msg_to_Server_Thread_*************************/

        private void SendSignalText(String signalText) 
        {
            try 
            {
                RemoveClosedThreadsFromList();
                Thread newThread = new Thread(new ParameterizedThreadStart(SendSignalTextNewThread));
                myThreadList.Add(newThread);
                newThread.Start(signalText);
            }
            catch (Exception ex)
            {
                throw new Exception(" TCP client error on sending signalValue to the server system -->" + ex.Message);
            }

        }

        private void RemoveClosedThreadsFromList()
        {
            try
            {
                List<Thread> myAliveThreadList = new List<Thread>();
                foreach(Thread thread in myThreadList)
                {
                    if ( thread.IsAlive )
                    {
                        myAliveThreadList.Add(thread);
                    }
                    else
                    {
                        thread.Abort();
                    }

                }
                myThreadList = myAliveThreadList;

            }
            catch (Exception ex) 
            {
                throw new Exception(" TCP client error when trying to close the unused threads ! -->" + ex.Message);
            }

        }

        /**************************_Send_Data_to_Server_*********************************/
        private void SendSignalTextNewThread(Object signalTextObject)
        {
            String signalText = signalTextObject as String;
            if (signalText == null) return;
            try
            {
                TcpClient myTCPClient = new TcpClient(_serverIP, _port);

                NetworkStream stream = myTCPClient.GetStream();

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] buffer = encoding.GetBytes(signalText);

                stream.Write(buffer, 0, buffer.Length);
                myTCPClient.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}
