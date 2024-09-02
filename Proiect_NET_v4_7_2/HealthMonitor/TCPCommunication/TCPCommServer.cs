using CommonReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;


namespace TCPCommunication
{
    public delegate void NewSignalReceived(SensorValue sensorValue);
    public class TCPCommServer
    {
        private Int16 _port = 1020;
        private string _thisServerIP = "0.0.0.0";

        protected TcpListener server;
        protected List<Thread> ServerThreadList = new List<Thread>();
        //protected List<Thread> myThreadList = new List<Thread>();

        private bool _isRunning = false;
        public event NewSignalReceived newSignalReceivedEvent;

        #region properties

        public bool IsRunning
        { 
            get { return _isRunning; } 
        }

        #endregion

        #region construcotrs
        public TCPCommServer()
        {
            try
            {
                StartTCPServer();
                _isRunning = true;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error when trying to open the TCP server", ex);
            }

        }

        #endregion

        /***********************_Start_TCP_Server_************************/
        private void StartTCPServer()
        {
            if (_isRunning) 
            {
                return;
            }

            /***_Create_new_thread_***/
            Thread newThread = new Thread(StartInNewThread);
            ServerThreadList.Add(newThread);
            newThread.Start();
        }

        /***********************_Start_new_thread_************************/
        /// <summary>
        /// Start the server. If a new connection request arrives, start a new thread for the server
        /// </summary>
        private void StartInNewThread()
        {
            server = new TcpListener(IPAddress.Parse(_thisServerIP), _port);
            server.Start();

            while(_isRunning)
            {
                if (server.Pending())
                {
                    RemoveClosedThreadsFromList();

                    TcpClient tempClient = server.AcceptTcpClient();

                    Thread newThread = new Thread(new ParameterizedThreadStart(ClientThread));
                    ServerThreadList.Add(newThread);

                    newThread.Start(tempClient);
                }
                Thread.Sleep(1000);
            }
            server.Stop();
        }

        /**********************_Remove_Closed_Threads_********************/
        private void RemoveClosedThreadsFromList()
        {
            try
            {
                List<Thread> myAliveThreadList = new List<Thread>();
                foreach (Thread thread in ServerThreadList)
                {
                    if (thread.IsAlive)
                    {
                        myAliveThreadList.Add(thread);
                    }
                    else
                    {
                        thread.Abort();
                    }

                }
                ServerThreadList = myAliveThreadList;

            }
            catch (Exception ex)
            {
                throw new Exception(" TCP client error when trying to close the unused threads ! -->" + ex.Message);
            }

        }

        /***********************_Close_TCP_Server_************************/
        public void CloseTCPServer()
        {
            if (server != null)
            {
                server.Stop();
            }
            foreach (Thread thread in ServerThreadList)
            {
                thread.Abort();
            }
            server = null;

        }


        /*###############################################################*/
        /*|____________________RECEIVE_CLIENT_DATA______________________|*/
        /*###############################################################*/

        /***********************_Client_Thread_***************************/
        public void ClientThread(object clientData)
        {
            TcpClient client = (TcpClient)clientData;
            NetworkStream stream = client.GetStream();
            stream.ReadTimeout = 60 *1000;

            List<byte> signalValueInBytes = new List<byte>();
            int bufData = 0;

            try
            {
                while (client.Connected && stream.DataAvailable)
                {
                    bufData = stream.ReadByte();
                    //if (bufData < 0) break;
                    if(bufData == -1)
                    {
                        break;
                    }
                    signalValueInBytes.Add((byte)bufData);
                }

                ASCIIEncoding enc = new ASCIIEncoding();
                string receivedText = enc.GetString(signalValueInBytes.ToArray());

                UnpackSignalAndRaiseTheEvent(receivedText);
            }
            catch (Exception ex) 
            {
                throw new Exception("Error when reading values sent by TCP client", ex);
            }
        }

        /********************_Unpack_received_data_***********************/
        private void UnpackSignalAndRaiseTheEvent(string packedSignalValues)
        {
            string strTimeStamp = string.Empty;
            string strSignalValue = string.Empty;
            string strPatientCode = string.Empty;
            string signalName = string.Empty;

            string[] ValuesList = packedSignalValues.Split('#');

            foreach (string packedSignalValue in ValuesList)
            {
                if (packedSignalValue.Length > 0)
                {
                    string[] valueFields  = packedSignalValue.Split(',');   
                    signalName = valueFields[0];
                    SensorType sensorType = (SensorType)Enum.Parse(typeof(SensorType), signalName);
                    strTimeStamp = valueFields[1];
                    DateTime timeStamp;
                    DateTime.TryParse(strTimeStamp, out timeStamp);
                    strPatientCode = valueFields[2];
                    strSignalValue = valueFields[3];

                    string[] dataValuesList = valueFields[3].Split(':');
                    List<double> dataValueList = new List<double>();    
                    try
                    {
                        foreach (string currDataValue in dataValuesList)
                        {
                            string strDataValue = (currDataValue.TrimStart('[')).TrimEnd(']');
                            double doubleValue;
                            Double.TryParse(strDataValue, out doubleValue);
                            dataValueList.Add(doubleValue);
                        }

                        SendNewDataReceivedEvent(new SensorValue(strPatientCode, sensorType, dataValueList[0], timeStamp));
                    }
                    catch (Exception ex) 
                    { 
                        throw new Exception("Error when unpacking the text received from TCP client", ex);
                    }

                }
            }
        }

        protected void SendNewDataReceivedEvent(SensorValue e)
        {
            if(this.newSignalReceivedEvent != null)
                this.SendNewDataReceivedEvent(e);
        }

        /*************************_DISPOSE_Function_********************/
        public void Dispose()
        {
            try
            {
                foreach (Thread thread in ServerThreadList)
                {
                    thread.Abort();
                }
                ServerThreadList.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception("Error on closing TCP client connection ->" + ex.Message);
            }
        }

        /*################################################################*/

    }
}
