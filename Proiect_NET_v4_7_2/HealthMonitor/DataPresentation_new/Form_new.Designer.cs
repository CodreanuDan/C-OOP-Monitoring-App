namespace DataPresentation_new
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView_sensorData = new System.Windows.Forms.DataGridView();
            this.patientCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.comboBox_patientCode = new System.Windows.Forms.ComboBox();
            this.textBox_timePeriod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_selectMonitor = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_intranet = new System.Windows.Forms.RadioButton();
            this.button_tcpip = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttom_received = new System.Windows.Forms.Button();
            this.button_select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_selectMonitor = new System.Windows.Forms.ComboBox();
            this.sensorValueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dayCalendar = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sensorData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource)).BeginInit();
            this.groupBox_selectMonitor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_sensorData
            // 
            this.dataGridView_sensorData.AutoGenerateColumns = false;
            this.dataGridView_sensorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sensorData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientCodeDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.timeStampDataGridViewTextBoxColumn});
            this.dataGridView_sensorData.DataSource = this.sensorValueBindingSource;
            this.dataGridView_sensorData.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_sensorData.Name = "dataGridView_sensorData";
            this.dataGridView_sensorData.RowHeadersWidth = 51;
            this.dataGridView_sensorData.RowTemplate.Height = 24;
            this.dataGridView_sensorData.Size = new System.Drawing.Size(490, 633);
            this.dataGridView_sensorData.TabIndex = 0;
            // 
            // patientCodeDataGridViewTextBoxColumn
            // 
            this.patientCodeDataGridViewTextBoxColumn.DataPropertyName = "PatientCode";
            this.patientCodeDataGridViewTextBoxColumn.HeaderText = "PatientCode";
            this.patientCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientCodeDataGridViewTextBoxColumn.Name = "patientCodeDataGridViewTextBoxColumn";
            this.patientCodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 80;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 50;
            // 
            // timeStampDataGridViewTextBoxColumn
            // 
            this.timeStampDataGridViewTextBoxColumn.DataPropertyName = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.HeaderText = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeStampDataGridViewTextBoxColumn.Name = "timeStampDataGridViewTextBoxColumn";
            this.timeStampDataGridViewTextBoxColumn.Width = 125;
            // 
            // sensorValueBindingSource
            // 
            this.sensorValueBindingSource.DataSource = typeof(SensorValue);
            // 
            // button_start
            // 
            this.button_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_start.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_start.Location = new System.Drawing.Point(271, 52);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(224, 23);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start Measurement";
            this.button_start.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.UseWaitCursor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_stop.ForeColor = System.Drawing.Color.Red;
            this.button_stop.Location = new System.Drawing.Point(271, 81);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(224, 23);
            this.button_stop.TabIndex = 2;
            this.button_stop.Text = "Stop Measurement";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // comboBox_patientCode
            // 
            this.comboBox_patientCode.DataSource = this.sensorValueBindingSource;
            this.comboBox_patientCode.DisplayMember = "PatientCode";
            this.comboBox_patientCode.FormattingEnabled = true;
            this.comboBox_patientCode.Location = new System.Drawing.Point(9, 54);
            this.comboBox_patientCode.Name = "comboBox_patientCode";
            this.comboBox_patientCode.Size = new System.Drawing.Size(228, 24);
            this.comboBox_patientCode.TabIndex = 3;
            // 
            // textBox_timePeriod
            // 
            this.textBox_timePeriod.Location = new System.Drawing.Point(9, 110);
            this.textBox_timePeriod.Name = "textBox_timePeriod";
            this.textBox_timePeriod.Size = new System.Drawing.Size(228, 22);
            this.textBox_timePeriod.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(72, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time per. between samples (s)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_selectMonitor
            // 
            this.groupBox_selectMonitor.Controls.Add(this.groupBox2);
            this.groupBox_selectMonitor.Controls.Add(this.button_start);
            this.groupBox_selectMonitor.Controls.Add(this.comboBox_patientCode);
            this.groupBox_selectMonitor.Controls.Add(this.label1);
            this.groupBox_selectMonitor.Controls.Add(this.label2);
            this.groupBox_selectMonitor.Controls.Add(this.textBox_timePeriod);
            this.groupBox_selectMonitor.Controls.Add(this.button_stop);
            this.groupBox_selectMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_selectMonitor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox_selectMonitor.Location = new System.Drawing.Point(561, 359);
            this.groupBox_selectMonitor.Name = "groupBox_selectMonitor";
            this.groupBox_selectMonitor.Size = new System.Drawing.Size(547, 286);
            this.groupBox_selectMonitor.TabIndex = 7;
            this.groupBox_selectMonitor.TabStop = false;
            this.groupBox_selectMonitor.Text = "Patients to be monitored";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button_intranet);
            this.groupBox2.Controls.Add(this.button_tcpip);
            this.groupBox2.Location = new System.Drawing.Point(30, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 142);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication Channel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server IP";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(293, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 22);
            this.textBox1.TabIndex = 2;
            // 
            // button_intranet
            // 
            this.button_intranet.AutoSize = true;
            this.button_intranet.Location = new System.Drawing.Point(49, 85);
            this.button_intranet.Name = "button_intranet";
            this.button_intranet.Size = new System.Drawing.Size(176, 21);
            this.button_intranet.TabIndex = 1;
            this.button_intranet.TabStop = true;
            this.button_intranet.Text = "Send only to this PC";
            this.button_intranet.UseVisualStyleBackColor = true;
            // 
            // button_tcpip
            // 
            this.button_tcpip.AutoSize = true;
            this.button_tcpip.Location = new System.Drawing.Point(49, 47);
            this.button_tcpip.Name = "button_tcpip";
            this.button_tcpip.Size = new System.Drawing.Size(172, 21);
            this.button_tcpip.TabIndex = 0;
            this.button_tcpip.TabStop = true;
            this.button_tcpip.Text = "Send trough TCP/IP";
            this.button_tcpip.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dayCalendar);
            this.groupBox1.Controls.Add(this.buttom_received);
            this.groupBox1.Controls.Add(this.button_select);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_selectMonitor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(561, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 331);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Filter";
            // 
            // buttom_received
            // 
            this.buttom_received.ForeColor = System.Drawing.Color.Blue;
            this.buttom_received.Location = new System.Drawing.Point(360, 203);
            this.buttom_received.Name = "buttom_received";
            this.buttom_received.Size = new System.Drawing.Size(134, 64);
            this.buttom_received.TabIndex = 10;
            this.buttom_received.Text = "Display Received Data";
            this.buttom_received.UseVisualStyleBackColor = true;
            this.buttom_received.Click += new System.EventHandler(this.buttom_received_Click);
            // 
            // button_select
            // 
            this.button_select.ForeColor = System.Drawing.Color.Blue;
            this.button_select.Location = new System.Drawing.Point(361, 115);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(134, 68);
            this.button_select.TabIndex = 9;
            this.button_select.Text = "Display Selected Data";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(146, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Patient";
            // 
            // comboBox_selectMonitor
            // 
            this.comboBox_selectMonitor.DataSource = this.sensorValueBindingSource;
            this.comboBox_selectMonitor.DisplayMember = "PatientCode";
            this.comboBox_selectMonitor.FormattingEnabled = true;
            this.comboBox_selectMonitor.Location = new System.Drawing.Point(310, 43);
            this.comboBox_selectMonitor.Name = "comboBox_selectMonitor";
            this.comboBox_selectMonitor.Size = new System.Drawing.Size(166, 24);
            this.comboBox_selectMonitor.TabIndex = 3;
            // 
            // sensorValueBindingSource1
            // 
            this.sensorValueBindingSource1.DataSource = typeof(SensorValue);
            // 
            // dayCalendar
            // 
            this.dayCalendar.Location = new System.Drawing.Point(12, 115);
            this.dayCalendar.Name = "dayCalendar";
            this.dayCalendar.ShowWeekNumbers = true;
            this.dayCalendar.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 657);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_selectMonitor);
            this.Controls.Add(this.dataGridView_sensorData);
            this.Name = "Form1";
            this.Text = "Health Monitor - Data Presenation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sensorData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource)).EndInit();
            this.groupBox_selectMonitor.ResumeLayout(false);
            this.groupBox_selectMonitor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_sensorData;
        private System.Windows.Forms.BindingSource sensorValueBindingSource;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.ComboBox comboBox_patientCode;
        private System.Windows.Forms.TextBox textBox_timePeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox_selectMonitor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_selectMonitor;
        private System.Windows.Forms.BindingSource sensorValueBindingSource1;
        private System.Windows.Forms.Button buttom_received;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton button_intranet;
        private System.Windows.Forms.RadioButton button_tcpip;
        private System.Windows.Forms.MonthCalendar dayCalendar;
    }
}

