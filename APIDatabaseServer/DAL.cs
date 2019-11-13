using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using APIDatabaseServer.ObjectTypes;

namespace APIDatabaseServer
{
    public class DAL
    {
        private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SportsPortalen;" + "Integrated Security=true;");
        private SqlCommand cmd = new SqlCommand();

        public DAL()
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
        }
        public void ResetDAL()
        {
            con.Close();
            con = new SqlConnection("Data Source=.;Initial Catalog=SportsPortalen;" + "Integrated Security=true;");
            cmd = new SqlCommand { Connection = con, CommandType = CommandType.Text };
        }
        public void OpenConnection(SqlConnection con)
        {
            con.Open();
        }

        public static void AddParam(SqlCommand cmd, object value, string name, SqlDbType sqlDbType)
        {
            //Made by Eby
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@" + name;
            if (value != null)
            {
                parameter.Value = value;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            parameter.SqlDbType = sqlDbType;
            parameter.Size = 255;
            cmd.Parameters.Add(parameter);
        }
        private static string SqlNVCHARConverter(string stringToConvert)
        {
           string returnstring = "'" + stringToConvert + "'";
            return returnstring;
        }
        public bool CheckIfObjectExists(ServerBasedSportsObject activity)
        {
            OpenConnection(con);
            cmd.Parameters.Clear();
            string sql = "SELECT COUNT(*) FROM SportsActivity WHERE [locationId] = @locationId";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@locationId", activity.locationId);
            int numRecords = (int)cmd.ExecuteScalar();
            ResetDAL();
            if (numRecords == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public void InsertActivityToDb(ServerBasedSportsObject activity)
        {
            if (CheckIfObjectExists(activity) == false)
            {


                OpenConnection(con);
                cmd.Parameters.Clear();

                AddParam(cmd, activity.locationId, "LocationId", SqlDbType.Int);
                AddParam(cmd, activity.image, "ImageLink", SqlDbType.NVarChar);
                AddParam(cmd, activity.desc, "Description", SqlDbType.NVarChar);
                AddParam(cmd, activity.lat, "Latitude", SqlDbType.NVarChar);
                AddParam(cmd, activity.link, "Link", SqlDbType.NVarChar);
                AddParam(cmd, activity.lon, "Longitude", SqlDbType.NVarChar);
                AddParam(cmd, activity.tags, "Categories", SqlDbType.NVarChar);
                AddParam(cmd, activity.text, "Text", SqlDbType.NVarChar);
                AddParam(cmd, activity.title, "Title", SqlDbType.NVarChar);

                cmd.CommandText =
                        "SET IDENTITY_INSERT SportsActivity ON" + " " +
                        "insert into SportsActivity (title, textField, textDescription, link, imagelink, lat, lon, locationId, tags)" + " " +
                        " values (@Title, @Text, @Description, @Link, @ImageLink, @Latitude, @Longitude, @LocationId, @Categories)" + " " +
                        "SET IDENTITY_INSERT SportsActivity OFF";
                try
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Record added Successfully!");
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                    Console.ReadLine();
                }
            }
            ResetDAL();
        }

    }
}
