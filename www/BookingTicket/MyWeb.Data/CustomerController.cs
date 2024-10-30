using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class CustomerDAL : SqlDataProvider
	{
		#region[Customer_GetbyAll]
		public DataTable Customer_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Customer_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
		#region[Customer_GetbyId]
		public DataTable Customer_GetById(string CusId)
		{
			using (var cmd = new SqlCommand("sp_Customer_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CusId", CusId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Customer_GetbyTop]
		public DataTable Customer_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Customer_GetByTop", GetConnection()))
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
		#region[Customer_Insert]
		public void Customer_Insert(CustomerInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Customer_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@Username", Data.Username));
				cmd.Parameters.Add(new SqlParameter("@Password", Data.Password));
				cmd.Parameters.Add(new SqlParameter("@CreditCard", Data.CreditCard));
				cmd.Parameters.Add(new SqlParameter("@FullName", Data.FullName));
				cmd.Parameters.Add(new SqlParameter("@Bod", Data.Bod));
				cmd.Parameters.Add(new SqlParameter("@Address", Data.Address));
				cmd.Parameters.Add(new SqlParameter("@Phone", Data.Phone));
				cmd.Parameters.Add(new SqlParameter("@Email", Data.Email));
                cmd.Parameters.Add(new SqlParameter("@Avata", Data.Avata));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Customer_Update]
		public void Customer_Update(CustomerInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Customer_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CusId", Data.CusId));
				cmd.Parameters.Add(new SqlParameter("@Username", Data.Username));
				cmd.Parameters.Add(new SqlParameter("@CreditCard", Data.CreditCard));
				cmd.Parameters.Add(new SqlParameter("@FullName", Data.FullName));
				cmd.Parameters.Add(new SqlParameter("@Bod", Data.Bod));
				cmd.Parameters.Add(new SqlParameter("@Address", Data.Address));
				cmd.Parameters.Add(new SqlParameter("@Phone", Data.Phone));
				cmd.Parameters.Add(new SqlParameter("@Email", Data.Email));
                cmd.Parameters.Add(new SqlParameter("@Avata", Data.Avata));
				cmd.Parameters.Add(new SqlParameter("@Status", Data.Status));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Customer_Delete]
		public void Customer_Delete(string CusId)
		{
			using (var cmd = new SqlCommand("sp_Customer_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CusId",CusId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
        #region[Customer_Update_Status]
        public void Customer_Update_Status(string CusId, string Status)
        {
            using (var cmd = new SqlCommand("sp_Customer_Update_Status", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CusId", CusId));
                cmd.Parameters.Add(new SqlParameter("@Status", Status));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
        #region[Customer_CheckLogin]
        public bool Customer_CheckLogin(string Username, string Password)
        {
            using (var cmd = new SqlCommand("sp_Customer_CheckLogin", GetConnection()))
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
        #region[Customer_ChangePassword]
        public void Customer_ChangePassword(string Username, string Password)
        {
            using (var cmd = new SqlCommand("sp_Customer_ChangePass", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", Username));
                cmd.Parameters.Add(new SqlParameter("@Pass", Password));
                ExeCuteNonquery(cmd);
            }
        }
        #endregion
	}
}