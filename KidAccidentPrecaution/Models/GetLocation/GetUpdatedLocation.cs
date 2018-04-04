﻿using KidAccidentPrecaution.Infrastructure;
using KidAccidentPrecaution.Models.GetLocation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GoogleMapCoordinates
{
    
        public class Location
        {
            public string Address { get; set; }
            public string Longitude { get; set; }

            public string Latitude { get; set; }
        }
        public class GetAccidentLocation
        {
            public Location Get()
            {
                string localLoc = "NIL";
                int AccidentId = 0;
                string GetLongitude = "NIL";
                string GetLatitude = "NIL";
                using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionStringSomee))
                {

                    try
                    {
                        con.Open();
                        //currently we are taking top 1 but later we will take particular driver location accidents only
                        SqlCommand cmd = new SqlCommand("select TOP 1  Location,Accident,Longitude,Latitude from Accident    order by Accident desc", con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                localLoc = rdr["Location"].ToString();
                                AccidentId = Convert.ToInt32(rdr["Accident"]);
                                GetLongitude = rdr["Longitude"].ToString();
                                GetLatitude = rdr["Latitude"].ToString();
                            }
                        }
                        rdr.Close();
                        rdr.Dispose();
                       // DeleteAfterPLot(AccidentId, con);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }



                }


                Location objLocation = new Location
                {
                    Latitude = GetLatitude,
                    Longitude = GetLongitude,
                    Address = localLoc
                };

                return objLocation;
            }

            private static void DeleteAfterPLot(int AccidentId, SqlConnection con)
            {
                //Delete once we plot the location
                var cmdDelete = new SqlCommand("UPDATE Accident SET IsExpired=1 WHERE Accident=@Accident", con);
                cmdDelete.Parameters.AddWithValue("@Accident", AccidentId);
                cmdDelete.ExecuteNonQuery();
            }

            internal string ReportAccident(string AccLoc)
            {
                string Response = "Failed";


                using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionStringSomee))
                {

                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT Into Accident (Location,DriverName,DriverId,VehicleId,VehicleNO) Values (@Location,'Varun',1,1,'KL-0167')", con);
                        cmd.Parameters.AddWithValue("@Location", AccLoc);
                        cmd.ExecuteNonQuery();
                        Response = "Accident reported successfully";
                    }
                    catch (Exception ex)
                    {

                        Response = ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }



                }

                return Response;
            }

            internal string UpdateDriverLocation(string Drivername, string Longitude, string Latitude)
            {
                string Response = "Failed";


                using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionString))
                {

                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("Update AddDriver SET Longitude=@Longitude , Latitude=@Latitude Where  DriverName=@DriverName", con);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@DriverName", Drivername);
                        cmd.ExecuteNonQuery();
                        Response = "Driver location updated";
                    }
                    catch (Exception ex)
                    {

                        Response = ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }



                }

                return Response;
            }

            internal string ReportAccident(string Longitude, string Latitude)
            {
                string Response = "Failed";
                string AccLoc = "Thiruvanathapuram";//Default set to Trivandrum,We are not considering location here ,we use latitude and longtitude
                //So we basically not want to leave the location as blank

                using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionStringSomee))
                {

                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT Into Accident (Location,Latitude,Longitude,DriverName,DriverId,VehicleId,VehicleNO) Values (@Location,@Latitude,@Longitude,'Varun',1,1,'KL-0167')", con);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);
                        cmd.Parameters.AddWithValue("@Location", AccLoc);
                        cmd.ExecuteNonQuery();
                        Response = "Accident reported successfully";
                    }
                    catch (Exception ex)
                    {

                        Response = ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }



                }

                return Response;
            }

            internal List<DriversLocation> GetDriverLocation()
            {
                List<DriversLocation> ListDrivers = new List<DriversLocation>();
                using (SqlConnection con = new SqlConnection(ConnectSql.getConnectionStringSomee))
                {

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from AddDriver", con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DriversLocation driverLocation = new DriversLocation
                                {
                                    Lat = rdr["Longitude"].ToString(),
                                    Lon = rdr["Latitude"].ToString(),
                                    Name = rdr["DriverName"].ToString()
                                };

                                ListDrivers.Add(driverLocation);
                            }
                        }
                        rdr.Close();
                        rdr.Dispose();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }



                }

                return ListDrivers;

            }
        }
    
}