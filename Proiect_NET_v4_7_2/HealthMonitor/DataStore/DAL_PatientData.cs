using CommonReferences;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


namespace DataStore
{
    public class DAL_PatientData
    {

        /*********************_ADD_DATA_TO_SQLITE_DB**************************/
        public static void AddData(SensorValue sensorData)
        {
            SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.ConnStringSQLite);
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Patient_Data_Table (id, patient_code, sensor_type, time_stamp, value) " +
                "values(:id, :patient_code, :sensor_type, :time_stamp, :value)";

            cmd.Parameters.Add(":id", DbType.String).Value = Guid.NewGuid().ToString();
            cmd.Parameters.Add(":patient_code", DbType.String).Value = sensorData.PatientCode;
            cmd.Parameters.Add(":sensor_type", DbType.String).Value = sensorData.Type;
            cmd.Parameters.Add(":time_stamp", DbType.String).Value = sensorData.TimeStamp;
            cmd.Parameters.Add(":value", DbType.String).Value = sensorData.Value;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Error adding PatientData");
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        /***************_REQUEST_DATA_FROM_SQLITE_DB_************************/
        public static List<SensorValue> GetData(PatientCodeEnum patCode, DateTime currDay)
        {
            List<SensorValue> sensorValueList = new List<SensorValue>();

            SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.ConnStringSQLite);
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, patient_code, sensor_type, time_stamp, value from Patient_Data_Table " +
                  "where patient_code = :patient_code and time_stamp >= :minTime and time_stamp < :maxTime";

            cmd.Parameters.Add(new SQLiteParameter(":patient_code", DbType.String) { Value = patCode });
            cmd.Parameters.Add(new SQLiteParameter(":minTime", DbType.String) { Value = currDay });
            cmd.Parameters.Add(new SQLiteParameter(":maxTime", DbType.String) { Value = currDay.AddDays(1) });


            SQLiteDataReader reader = null;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SensorValue pItem = new SensorValue();
                    if (reader["patient_code"] != DBNull.Value) pItem.PatientCode = (String)reader["patient_code"];
                    if (reader["sensor_type"] != DBNull.Value)
                    {
                        string strType = (string)reader["sensor_type"];
                        pItem.Type = (SensorType)Enum.Parse(typeof(SensorType), strType);

                    }
                    if (reader["time_stamp"] != DBNull.Value) pItem.TimeStamp = DateTime.Parse(reader["time_stamp"].ToString());
                    if (reader["value"] != DBNull.Value) pItem.Value = Convert.ToDouble(reader["value"]);
                    sensorValueList.Add(pItem);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on reading from Patient Data DB !" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                cmd.Connection.Close();
            }
            return sensorValueList;

        }        
    
    }

}
