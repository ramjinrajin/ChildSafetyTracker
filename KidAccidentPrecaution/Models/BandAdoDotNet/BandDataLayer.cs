using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using KidAccidentPrecaution.Models.Entities.Device;
using KidAccidentPrecaution.Infrastructure;

namespace KidAccidentPrecaution.Models.BandAdoDotNet
{
    public class BandDataLayer
    {
        public BandResponse InsertBand(Band objBand)
        {
            BandResponse objBandResponse = new BandResponse();
            using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SpAddBand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BandNo",objBand.BandNo);
                    cmd.Parameters.AddWithValue("@BandSLNO", objBand.BandSLNO);
                    cmd.Parameters.AddWithValue("@NotificationType", objBand.NotificationType);
                    string Result = (string)cmd.ExecuteScalar();
                    if (Result == "Band added successfully")
                    {
                        objBandResponse.Message = Result;
                        objBandResponse.Status = BandStatus.Success;
                    }
                    else
                    {
                        objBandResponse.Message = Result;
                        objBandResponse.Status = BandStatus.Warning;
                    }


                    return objBandResponse;
                }
                catch (Exception ex)
                {
                    objBandResponse.Message = ex.Message;
                    objBandResponse.Status = BandStatus.Error;
                    return objBandResponse;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}