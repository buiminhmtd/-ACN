using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class CountryDAL : SqlDataProvider
	{

		#region[Country_GetbyAll]
		public DataTable Country_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Country_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Country_GetbyId]
		public DataTable Country_GetById(string CouId)
		{
			using (var cmd = new SqlCommand("sp_Country_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CouId", CouId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Country_GetbyTop]
		public DataTable Country_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Country_GetByTop", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				var da = new SqlDataAdapter(cmd);
				cmd.Parameters.Add(new SqlParameter("@Top",Top));
				cmd.Parameters.Add(new SqlParameter("@Where",Where));
				cmd.Parameters.Add(new SqlParameter("@Order",Order));
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Country_Insert]
		public void Country_Insert(CountryInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Country_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NameCo", Data.NameCo));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Country_Update]
		public void Country_Update(CountryInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Country_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CouId", Data.CouId));
                cmd.Parameters.Add(new SqlParameter("@NameCo", Data.NameCo));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Country_Delete]
		public void Country_Delete(string CouId)
		{
			using (var cmd = new SqlCommand("sp_Country_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CouId",CouId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[Country_Update_Status]
        public void Country_Update_Status(string CouId, string Status)
        {
            using (var cmd = new SqlCommand("sp_Country_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CouId", CouId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}