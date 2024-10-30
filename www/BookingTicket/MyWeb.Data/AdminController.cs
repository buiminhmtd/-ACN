using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class AdminDAL : SqlDataProvider
	{
		#region[Admin_GetbyAll]
		public DataTable Admin_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Admin_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Admin_GetbyId]
		public DataTable Admin_GetById(string AdmId)
		{
			using (var cmd = new SqlCommand("sp_Admin_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@AdmId", AdmId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Admin_Update]
		public void Admin_Update(AdminInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Admin_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@AdmId", Data.AdmId));
				cmd.Parameters.Add(new SqlParameter("@FullName", Data.FullName));
				cmd.Parameters.Add(new SqlParameter("@Bod", Data.Bod));
				cmd.Parameters.Add(new SqlParameter("@Address", Data.Address));
				cmd.Parameters.Add(new SqlParameter("@Phone", Data.Phone));
				cmd.Parameters.Add(new SqlParameter("@Email", Data.Email));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[Admin_ChangePassword]
        public void Admin_ChangePassword(string Username, string Password)
        {
            using (var cmd = new SqlCommand("sp_Admin_ChangePass", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", Username));
                cmd.Parameters.Add(new SqlParameter("@Pass", Password));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
        #region[Admin_CheckLogin]
        public bool Admin_CheckLogin(string Username, string Password)
        {
            using (var cmd = new SqlCommand("sp_Admin_CheckLogin", GetConnection()))
            {
                bool flag = false;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", Username));
                cmd.Parameters.Add(new SqlParameter("@Pass", Password));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion
	}
}