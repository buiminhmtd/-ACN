using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class CinemaDAL : SqlDataProvider
	{
		#region[Cinema_GetbyAll]
		public DataTable Cinema_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Cinema_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Cinema_GetbyId]
		public DataTable Cinema_GetById(string CinId)
		{
			using (var cmd = new SqlCommand("sp_Cinema_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CinId", CinId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Cinema_GetbyTop]
		public DataTable Cinema_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Cinema_GetByTop", GetConnection()))
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
		#region[Cinema_Insert]
		public void Cinema_Insert(CinemaInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Cinema_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NameCi", Data.NameCi));
				cmd.Parameters.Add(new SqlParameter("@Address", Data.Address));
				cmd.Parameters.Add(new SqlParameter("@Seats", Data.Seats));
				cmd.Parameters.Add(new SqlParameter("@Phone", Data.Phone));
                cmd.Parameters.Add(new SqlParameter("@Image", Data.Image));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Cinema_Update]
		public void Cinema_Update(CinemaInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Cinema_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CinId", Data.CinId));
                cmd.Parameters.Add(new SqlParameter("@NameCi", Data.NameCi));
				cmd.Parameters.Add(new SqlParameter("@Address", Data.Address));
				cmd.Parameters.Add(new SqlParameter("@Seats", Data.Seats));
				cmd.Parameters.Add(new SqlParameter("@Phone", Data.Phone));
                cmd.Parameters.Add(new SqlParameter("@Image", Data.Image));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Cinema_Delete]
		public void Cinema_Delete(string CinId)
		{
			using (var cmd = new SqlCommand("sp_Cinema_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CinId",CinId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[Cinema_Update_Status]
        public void Cinema_Update_Status(string CinId, string Status)
        {
            using (var cmd = new SqlCommand("sp_Cinema_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CinId", CinId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}