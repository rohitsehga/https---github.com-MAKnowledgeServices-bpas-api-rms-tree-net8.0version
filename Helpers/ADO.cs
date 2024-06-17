using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceRequestService.Helpers
{
    public class ADO
    {
        public Response CallStoreProcedure(string connection, string proceName, Dictionary<string, dynamic> parameters)
        {
            Response response = new();
            try
            {
                DataSet ds = new();
                SqlDataAdapter da = new();
                using SqlConnection cn = new(connection);
                cn.Open();
                using SqlCommand cmd = new(proceName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                foreach (var param in parameters)
                {
                    if (param.Value.ValueKind == JsonValueKind.Number)
                    {
                        int value = int.Parse(param.Value.ToString());
                        cmd.Parameters.Add("@" + param.Key, SqlDbType.Int).Value = value;
                    }
                    else if (param.Value.ValueKind == JsonValueKind.True || param.Value.ValueKind == JsonValueKind.False)
                    {
                        bool value = bool.Parse(param.Value.ToString());
                        cmd.Parameters.Add("@" + param.Key, SqlDbType.Bit).Value = value;
                    }
                    else if (param.Value.ValueKind == JsonValueKind.String)
                    {
                        string value = param.Value.ToString();
                        cmd.Parameters.Add("@" + param.Key, SqlDbType.VarChar).Value = value;
                    }
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                var json = JsonConvert.SerializeObject(ds);
                cmd.Dispose();
                cn.Dispose();
                response.Status = true;
                response.Data = json;
            }
            catch (SqlException sqlex)
            {
                response.Status = false;
                response.Message = sqlex.Message;
                response.Error = sqlex.ToString();
                response.Data = string.Empty;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                response.Data = string.Empty;
            }
            return response;
        }

        public Response CallStoreProcedureNew(string connection, string proceName, Dictionary<string, dynamic> parameters = null)
        {
            Response response = new();
            try
            {
                DataSet ds = new();
                SqlDataAdapter da = new();
                using SqlConnection cn = new(connection);
                cn.Open();
                using SqlCommand cmd = new(proceName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 900;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        if (param.Value.ValueKind == JsonValueKind.Number)
                        {
                            int value = int.Parse(param.Value.ToString());
                            cmd.Parameters.Add("@" + param.Key, SqlDbType.Int).Value = value;
                        }
                        else if (param.Value.ValueKind == JsonValueKind.True || param.Value.ValueKind == JsonValueKind.False)
                        {
                            bool value = bool.Parse(param.Value.ToString());
                            cmd.Parameters.Add("@" + param.Key, SqlDbType.Bit).Value = value;
                        }
                        else if (param.Value.ValueKind == JsonValueKind.String)
                        {
                            string value = param.Value.ToString();
                            cmd.Parameters.Add("@" + param.Key, SqlDbType.VarChar).Value = value;
                        }
                    }
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                var json = JsonConvert.SerializeObject(ds);
                cmd.Dispose();
                cn.Dispose();
                response.Status = true;
                response.Data = json;
            }
            catch (SqlException sqlex)
            {
                response.Status = false;
                response.Message = sqlex.Message;
                response.Error = sqlex.ToString();
                response.Data = string.Empty;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                response.Data = string.Empty;
            }
            return response;
        }

        public IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                        SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
    }
}
