/**********************_FORM_CODE_****************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonReferences;
using TCPCommunication;
using System.Net.Sockets;

namespace DataPresentation_new
{
    public partial class Form1 : Form
    {
        /*****************_GRID_DISPLAY_DATA_*****************/
        PumpSensorValues sensorsValuesPump;
        List<SensorValue> sensorValuesList = new List<SensorValue>();
        Dictionary<PatientCodeEnum, PumpSensorValues> dictPatientPump = new Dictionary<PatientCodeEnum, PumpSensorValues>();

        /*******************_DB_DISPLAY_DATA_*****************/
        private bool displayTheReceivingData = true;
        List<SensorValue> sensorValueList = new List<SensorValue>();
        List<SensorValue> sensorValueListPast = new List<SensorValue>();

        /*******************_SERVER_VARS_DATA_****************/
        private bool sendAlsoTroughTCP = false;
        //private TCPCommunication.TCPCommClient tcpCommClient;
        //private TCPCommunication.TCPCommServer tcpCommServer;

        /***********************_WINDOW_APP_INIT_*************************/
        public Form1()
        {
            InitializeComponent();

            patientCodeDataGridViewTextBoxColumn.DataPropertyName = "PatientCode";

            sensorsValuesPump = new PumpSensorValues(3);
            /*sensorsValuesPump.StartPumping();
            sensorsValuesPump.newSensorValueEvent += new OnNewSensorValue(OnNewSensorValueHandler); */
            comboBox_patientCode.DataSource = Enum.GetValues(typeof(PatientCodeEnum));
            comboBox_selectMonitor.DataSource = Enum.GetValues(typeof(PatientCodeEnum));

            //tcpCommServer = new TCPCommServer();
            //tcpCommServer.newSignalReceivedEvent += new NewSignalReceived(tcpCommServer_newSignalaReceivedEvent);
        }

        void tcpCommServer_newSignalaReceivedEvent(SensorValue sensorValue)
        {
            OnNewSensorValueHandler(sensorValue);
        }

        public delegate void VoidFunctionDelegate();

        void OnNewSensorValueHandler(SensorValue sensorValueArg)
        {
            /***************_DB_INSERT_DATA_*****************/
            DataStore.DAL_PatientData.AddData(sensorValueArg);

            /***************_DATA_GRID_DISPLAY_**************/
            sensorValuesList.Insert(0, sensorValueArg);
            this.BeginInvoke(new VoidFunctionDelegate(BindDataGridToListOfValues));
            //MessageBox.Show("Type = " + sensorValueArg.Type.ToString() + " Time Stamp = " + sensorValueArg.TimeStampString + " Value = " + sensorValueArg.Value);
        }

        private void BindDataGridToListOfValues()
        {
            dataGridView_sensorData.DataSource = null;
            dataGridView_sensorData.DataSource = sensorValuesList;
        }

        /*******************_START_MONITORING_ROUTINE_*******************/
        private void button_start_Click(object sender, EventArgs e)
        {
            int timePeriodSeconds = 1;
            if (comboBox_patientCode.SelectedIndex != null && textBox_timePeriod.Text != null)
            {
                try
                {
                    timePeriodSeconds = Convert.ToInt32(textBox_timePeriod.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Error: the Time period text cannot be converted to int type ! ->" + ex.Message);
                }

                /**********************_CA_SA_PORNEASCA_DOAR_CU_TIMESTAMP_*********************/
                PatientCodeEnum currPatient = (PatientCodeEnum)comboBox_patientCode.SelectedItem;
                if (textBox_timePeriod.Text.Length != 0)
                {
                    startPumping(currPatient, timePeriodSeconds);
                }

            }
        }

        private void startPumping(PatientCodeEnum patCodeEnum, int periodSeconds)
        {
            if (dictPatientPump.ContainsKey(patCodeEnum))
            {
                MessageBox.Show("The selected patient has the pump already started");
                return;
            }


            PumpSensorValues sensorsValuesPump = new PumpSensorValues(patCodeEnum.ToString(), periodSeconds);
            sensorsValuesPump.StartPumping();
            MessageBox.Show($"Starting pumping for patient: {patCodeEnum.ToString()}");
            sensorsValuesPump.newSensorValueEvent += new OnNewSensorValue(OnNewSensorValueHandler);
            dictPatientPump.Add(patCodeEnum, sensorsValuesPump);
        }

        /********************_STOP_MONITORING_ROUTINE_*******************/

        private void button_stop_Click(object sender, EventArgs e)
        {
            PatientCodeEnum currPatientStop = (PatientCodeEnum)comboBox_patientCode.SelectedItem;

            if (dictPatientPump.ContainsKey((PatientCodeEnum)currPatientStop))
            {
                PumpSensorValues pumpToBeStopped = dictPatientPump[currPatientStop];
                pumpToBeStopped.StopPumping();
                MessageBox.Show($"Stopping pumping for patient: {currPatientStop.ToString()}");
                dictPatientPump.Remove(currPatientStop);
            }
            else
            {
                MessageBox.Show("The selected patient has no pump values started !");
            }

        }

        /*********************_SELECT_PATIENT_DATA_**********************/
        private void button_select_Click(object sender, EventArgs e)
        {
            displayTheReceivingData = false;
            PatientCodeEnum selectedPatient = (PatientCodeEnum)comboBox_selectMonitor.SelectedIndex;
            DateTime selectedDay = dayCalendar.SelectionStart;

            sensorValueListPast = DataStore.DAL_PatientData.GetData(selectedPatient, selectedDay);

            if (sensorValueListPast.Count > 0)
            {
                dataGridView_sensorData.DataSource = null;
                dataGridView_sensorData.DataSource = sensorValueListPast;
            }
            else
            {
                MessageBox.Show("No data available for the selected day.");
            }
        }

        /*******************_SELECT_RECV_PATIENT_DATA_*******************/
        private void buttom_received_Click(object sender, EventArgs e)
        {
            displayTheReceivingData = true;
            BindDataGridToListOfValues();
        }

        /***********************_Form_Closing_***************************/
        private void DataPresentation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (tcpCommServer != null) tcpCommClient.Dispose();
            //if (tcpCommClient != null) tcpCommClient.Dispose();

            Console.WriteLine("App will now exit !");
            Environment.Exit(0);
            Application.Exit();
        }

    }

}

