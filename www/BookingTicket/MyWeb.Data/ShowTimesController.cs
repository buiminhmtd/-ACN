using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class ShowTimesDAL : SqlDataProvider
	{

		#region[ShowTimes_GetbyAll]
		public DataTable ShowTimes_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[ShowTimes_GetbyId]
		public DataTable ShowTimes_GetById(string ShoId)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@ShoId", ShoId));return GetTable(cmd);
			}
		}
		#endregion
		#region[ShowTimes_GetbyTop]
		public DataTable ShowTimes_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_GetByTop", GetConnection()))
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
        #region[ShowTimes_GetbyTop1]
        public DataTable ShowTimes_GetByTop1(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_ShowTimes_GetByTop1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@Top", Top));
                cmd.Parameters.Add(new SqlParameter("@Where", Where));
                cmd.Parameters.Add(new SqlParameter("@Order", Order));
                return GetTable(cmd);
            }
        }
        #endregion
        #region[ShowTimes_GetbyTop2]
        public DataTable ShowTimes_GetbyTop2(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_ShowTimes_GetByTop2", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@Top", Top));
                cmd.Parameters.Add(new SqlParameter("@Where", Where));
                cmd.Parameters.Add(new SqlParameter("@Order", Order));
                return GetTable(cmd);
            }
        }
        #endregion
		#region[ShowTimes_GetbyCinId]
		public DataTable ShowTimes_GetByCinId(string CinId)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_GetByCinId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CinId", CinId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[ShowTimes_GetbyFilId]
		public DataTable ShowTimes_GetByFilId(string FilId)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_GetByFilId", GetConnection()))
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
		#region[ShowTimes_Insert]
		public void ShowTimes_Insert(ShowTimesInfo Data)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
				cmd.Parameters.Add(new SqlParameter("@CinId", Data.CinId));
				cmd.Parameters.Add(new SqlParameter("@ShowTime", Data.ShowTime));
                cmd.Parameters.Add(new SqlParameter("@Time", Data.Time));
				cmd.Parameters.Add(new SqlParameter("@Price", Data.Price));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[ShowTimes_Update]
		public void ShowTimes_Update(ShowTimesInfo Data)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@ShoId", Data.ShoId));
				cmd.Parameters.Add(new SqlParameter("@FilId", Data.FilId));
				cmd.Parameters.Add(new SqlParameter("@CinId", Data.CinId));
				cmd.Parameters.Add(new SqlParameter("@ShowTime", Data.ShowTime));
                cmd.Parameters.Add(new SqlParameter("@Time", Data.Time));
				cmd.Parameters.Add(new SqlParameter("@Price", Data.Price));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[ShowTimes_Delete]
		public void ShowTimes_Delete(string ShoId)
		{
			using (var cmd = new SqlCommand("sp_ShowTimes_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@ShoId",ShoId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[ShowTimes_Update_Status]
        public void ShowTimes_Update_Status(string ShoId, string Status)
        {
            using (var cmd = new SqlCommand("sp_ShowTimes_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ShoId", ShoId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
        #region[ShowTimes_Update_Price]
        public void ShowTimes_Update_Price(string ShoId, string Price)
        {
            using (var cmd = new SqlCommand("sp_ShowTimes_Update_Price", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ShoId", ShoId));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
        #region[ShowTimes_Update_View]
        public void ShowTimes_Update_View(string FilId)
        {
            using (var cmd = new SqlCommand("sp_ShowTimes_Update_View", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FilId", FilId));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}