using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BIBLIOTECA.SuiteClases.clsTools
{
    public class clsTools
    {

        public enum enuBool : int
        {
            TRUE = 1,
            FALSE = 0,
        }

        public static string obtenerValorDefault(object lsValue, string lsDefault)
        {
            string lsReturn = (lsValue != null ? lsValue.ToString() : string.Empty);
            return ((new Regex("[^a-zA-Z0-9]")).IsMatch(lsReturn) == false && lsReturn.Length > 0) ? lsReturn : lsDefault;
        }
        public static DateTime obtenerValorDefault(object ldValue, DateTime ldDate)
        {
            if (IsDateTime(ldValue))
            {
                return Convert.ToDateTime(ldValue);
            }
            return (new DateTime(2000, 1, 1));
        }
        public static bool IsDateTime(object txtDate)
        {
            if (txtDate == null) txtDate = "3RR0R";
            DateTime tempDate;
            return DateTime.TryParse(txtDate.ToString(), out tempDate) ? true : false;
        }
        public static bool IsNumeric(object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        #region procedimiento & funciones AC
        public static int acserObtenerID(string tble, string tkey, AcEntities db)
        {
            var procResult = new SqlParameter
            {
                ParameterName = "@NroC",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            db.Database.ExecuteSqlCommand(
                "exec @NroC = acserObtenerID @Tble, @Tkey",
                new object[]  {  new SqlParameter
            {
                ParameterName = "@Tble",
                Value = tble,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input
            },
            new SqlParameter
            {
                ParameterName = "@Tkey",
                Value = tkey,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input
            },
            procResult
            });

            return (int)procResult.Value;
        }
    }
    #endregion
}