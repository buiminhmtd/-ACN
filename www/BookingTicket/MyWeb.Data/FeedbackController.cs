using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class FeedbackDAL : SqlDataProvider
	{

		#region[Feedback_GetbyAll]
		public DataTable Feedback_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Feedback_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Feedback_GetbyId]
		public DataTable Feedback_GetById(string FeeId)
		{
			using (var cmd = new SqlCommand("sp_Feedback_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FeeId", FeeId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Feedback_GetbyTop]
		public DataTable Feedback_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Feedback_GetByTop", GetConnection()))
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
		#region[Feedback_GetbyFilId]
		public DataTable Feedback_GetByFilId(string FilId)
		{
			using (var cmd = new SqlCommand("sp_Feedback_GetByFilId", GetConnection()))
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
		#region[Feedback_Insert]
		public void Feedback_Insert(FeedbackInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Feedback_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
                cmd.Parameters.Add(new SqlParameter("@Avata", Data.Avata));
				cmd.Parameters.Add(new SqlParameter("@FullName", Data.FullName));
				cmd.Parameters.Add(new SqlParameter("@Comment", Data.Comment));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Feedback_Update]
		public void Feedback_Update(FeedbackInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Feedback_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FeeId", Data.FeeId));
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
                cmd.Parameters.Add(new SqlParameter("@Avata", Data.Avata));
				cmd.Parameters.Add(new SqlParameter("@FullName", Data.FullName));
				cmd.Parameters.Add(new SqlParameter("@Comment", Data.Comment));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Feedback_Delete]
		public void Feedback_Delete(string FeeId)
		{
			using (var cmd = new SqlCommand("sp_Feedback_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FeeId",FeeId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
	}
}