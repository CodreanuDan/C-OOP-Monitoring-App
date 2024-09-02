using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CommonReferences;



public class SensorValue
{
    private string patientCode;
    private SensorType type;
    private double value;
    private DateTime timeStamp;

    #region properties

    public string PatientCode
    {
        get { return patientCode; }
        set { patientCode = value; }
    }

    public SensorType Type
    {
        get { return type; }
        set { type = value; }
    }

    public double Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public DateTime TimeStamp
    {
        get { return this.timeStamp; }
        set { this.timeStamp = value; }
    }

    public string TimeStampString
    {
        get { return timeStamp.ToString("dd-MMM-yy HH:mm:ss"); }
        set { timeStamp = DateTime.ParseExact(value, "dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture); }
    }

    #endregion

    #region constructors

    public SensorValue(string patientCode, SensorType type, double value, DateTime timeStamp)
    {
        this.type = type;
        this.value = value;
        this.timeStamp = timeStamp;
        this.patientCode = patientCode;
    }

    public SensorValue()
    {
        type = SensorType.None;
    }

    public SensorValue(SensorType type, double value, DateTime timeStamp)
    {
        this.type = type;
        this.value = value;
        this.timeStamp = timeStamp;
    }

    public SensorValue(string patientCode, SensorType type, double value, string timeStamp)
    {
        this.type = type;
        this.value = value;
        this.TimeStampString = timeStamp;
        this.patientCode = patientCode;
    }

    #endregion
}

