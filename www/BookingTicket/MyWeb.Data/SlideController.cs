using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class SlideDAL : SqlDataProvider
	{
        #region[Silde_Update_Status]
        public void Silde_Update_Status(string SliId, string Status)
        {
            using (var cmd = new SqlCommand("sp_Slide_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SliId", SliId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
		#region[Slide_GetbyAll]
		public DataTable Slide_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Slide_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Slide_GetbyId]
		public DataTable Slide_GetById(string SliId)
		{
			using (var cmd = new SqlCommand("sp_Slide_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@SliId", SliId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Slide_GetbyTop]
		public DataTable Slide_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Slide_GetByTop", GetConnection()))
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
		#region[Slide_GetbyFilId]
		public DataTable Slide_GetByFilId(string FilId)
		{
			using (var cmd = new SqlCommand("sp_Slide_GetByFilId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", FilId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[Slide_Insert]
		public void Slide_Insert(SlideInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Slide_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
				cmd.Parameters.Add(new SqlParameter("@Image", Data.Image));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Slide_Update]
		public void Slide_Update(SlideInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Slide_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@SliId", Data.SliId));
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
				cmd.Parameters.Add(new SqlParameter("@Image", Data.Image));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Slide_Delete]
		public void Slide_Delete(string SliId)
		{
			using (var cmd = new SqlCommand("sp_Slide_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@SliId",SliId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
	}
}