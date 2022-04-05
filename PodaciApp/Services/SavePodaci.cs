using PodaciApp.Dtos;
using PodaciApp.Services.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PodaciApp.Services
{
    public class SavePodaci : ISavePodaci
    {
        public string SaveData(string connectionString, IEnumerable<PodatakDto> data)
        {
            var result = "";
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (var podatak in data)
                    {
                        using (var cmd = new SqlCommand("Insert_Podaci", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Ime", SqlDbType.VarChar).Value = podatak.Ime;
                            cmd.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = podatak.Prezime;
                            cmd.Parameters.Add("@Postanski_broj", SqlDbType.Int).Value = podatak.PostanskiBroj;
                            cmd.Parameters.Add("@Grad", SqlDbType.VarChar).Value = podatak.Grad;
                            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = podatak.Telefon;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}