using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class TypeFilmDAL : SqlDataProvider
	{

		#region[TypeFilm_GetbyAll]
		public DataTable TypeFilm_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[TypeFilm_GetbyId]
		public DataTable TypeFilm_GetById(string TypId)
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TypId", TypId));return GetTable(cmd);
			}
		}
		#endregion
		#region[TypeFilm_GetbyTop]
		public DataTable TypeFilm_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_GetByTop", GetConnection()))
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
		#region[TypeFilm_Insert]
		public void TypeFilm_Insert(TypeFilmInfo Data)
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NameT", Data.NameT));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[TypeFilm_Update]
		public void TypeFilm_Update(TypeFilmInfo Data)
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TypId", Data.TypId));
                cmd.Parameters.Add(new SqlParameter("@NameT", Data.NameT));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[TypeFilm_Delete]
		public void TypeFilm_Delete(string TypId)
		{
			using (var cmd = new SqlCommand("sp_TypeFilm_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TypId",TypId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[TypeFilm_Update_Status]
        public void TypeFilm_Update_Status(string TypId, string Status)
        {
            using (var cmd = new SqlCommand("sp_TypeFilm_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TypId", TypId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}