using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class FilmDAL : SqlDataProvider
	{
		#region[Film_GetbyAll]
		public DataTable Film_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Film_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Film_GetbyId]
		public DataTable Film_GetById(string FilId)
		{
			using (var cmd = new SqlCommand("sp_Film_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", FilId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Film_GetbyTop]
		public DataTable Film_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Film_GetByTop", GetConnection()))
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
		#region[Film_GetbyCouId]
		public DataTable Film_GetByCouId(string CouId)
		{
			using (var cmd = new SqlCommand("sp_Film_GetByCouId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CouId", CouId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[Film_GetbyTypId]
		public DataTable Film_GetByTypId(string TypId)
		{
			using (var cmd = new SqlCommand("sp_Film_GetByTypId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TypId", TypId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[Film_Insert]
		public void Film_Insert(FilmInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Film_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TypId", Data.TypId));
				cmd.Parameters.Add(new SqlParameter("@CouId", Data.CouId));
                cmd.Parameters.Add(new SqlParameter("@NameF", Data.NameF));
				cmd.Parameters.Add(new SqlParameter("@Director", Data.Director));
				cmd.Parameters.Add(new SqlParameter("@Actor", Data.Actor));
				cmd.Parameters.Add(new SqlParameter("@Duration", Data.Duration));
				cmd.Parameters.Add(new SqlParameter("@Description", Data.Description));
                cmd.Parameters.Add(new SqlParameter("@Detail", Data.Detail));
				cmd.Parameters.Add(new SqlParameter("@Picture", Data.Picture));
                cmd.Parameters.Add(new SqlParameter("@PictureBig", Data.PictureBig));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Film_Update]
		public void Film_Update(FilmInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Film_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
				cmd.Parameters.Add(new SqlParameter("@TypId", Data.TypId));
				cmd.Parameters.Add(new SqlParameter("@CouId", Data.CouId));
                cmd.Parameters.Add(new SqlParameter("@NameF", Data.NameF));
				cmd.Parameters.Add(new SqlParameter("@Director", Data.Director));
				cmd.Parameters.Add(new SqlParameter("@Actor", Data.Actor));
				cmd.Parameters.Add(new SqlParameter("@Duration", Data.Duration));
				cmd.Parameters.Add(new SqlParameter("@Description", Data.Description));
                cmd.Parameters.Add(new SqlParameter("@Detail", Data.Detail));
				cmd.Parameters.Add(new SqlParameter("@Picture", Data.Picture));
                cmd.Parameters.Add(new SqlParameter("@PictureBig", Data.PictureBig));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Film_Delete]
		public void Film_Delete(string FilId)
		{
			using (var cmd = new SqlCommand("sp_Film_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId",FilId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[Film_Update_Status]
        public void Film_Update_Status(string FilId, string Status)
        {
            using (var cmd = new SqlCommand("sp_Film_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FilId", FilId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}