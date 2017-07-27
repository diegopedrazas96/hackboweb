using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIBLIOTECA.SuiteClases.ClsAC
{
    public class clsAcapp
    {
        public static DataTable acappObtenerListaAsig(int liCepc, string lsCusr, AcEntities db )


        {
            

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(db.Database.Connection);
                using (var cmd = factory.CreateCommand())
                {
                    cmd.CommandText = "select * from dbo.acappObtenerListaAsig(@liCepc,@lsCusr) order by  acappCmod,acappTapp,acappNord";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = db.Database.Connection;
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@liCepc",
                        Value = liCepc,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@lsCusr",
                        Value = lsCusr,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    });
                    using (var adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        var tb = new DataTable();
                        adapter.Fill(tb);
                        return tb;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}