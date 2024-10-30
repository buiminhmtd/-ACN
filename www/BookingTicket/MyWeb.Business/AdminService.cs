using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class AdminService
	{
		private static readonly AdminDAL db = new AdminDAL();
		#region[Admin_GetById]
		public static DataTable Admin_GetById(string Id)
		{
			return db.Admin_GetById(Id);
		}
		#endregion
		#region[Admin_GetByAll]
		public static DataTable Admin_GetByAll()
		{
			return db.Admin_GetByAll();
		}
		#endregion
		#region[Admin_Update]
		public static void Admin_Update(AdminInfo Data)
		{
			 db.Admin_Update(Data);
		}
		#endregion
        #region[Admin_ChangePassword]
        public static void Admin_ChangePassword(string Username, string Password)
        {
            db.Admin_ChangePassword(Username, Password);
        }
        #endregion
        #region[Admin_CheckLogin]
        public static bool Admin_CheckLogin(string Username, string Password)
        {
            return db.Admin_CheckLogin(Username, Password);
        }
        #endregion
	}
}