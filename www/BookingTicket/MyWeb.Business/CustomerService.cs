using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class CustomerService
	{
		private static readonly CustomerDAL db = new CustomerDAL();
		#region[Customer_GetById]
		public static DataTable Customer_GetById(string Id)
		{
			return db.Customer_GetById(Id);
		}
		#endregion
		#region[Customer_GetByAll]
		public static DataTable Customer_GetByAll()
		{
			return db.Customer_GetByAll();
		}
		#endregion
		#region[Customer_GetByTop]
		public static DataTable Customer_GetByTop(string Top, string Where, string Order)
		{
			return db.Customer_GetByTop(Top, Where, Order);}
		#endregion
		#region[Customer_Insert]
		public static void Customer_Insert(CustomerInfo Data)
		{
			 db.Customer_Insert(Data);
		}
		#endregion
		#region[Customer_Update]
		public static void Customer_Update(CustomerInfo Data)
		{
			 db.Customer_Update(Data);
		}
		#endregion
		#region[Customer_Delete]
		public static void Customer_Delete(string Id)
		{
			 db.Customer_Delete(Id);
		}
		#endregion
        #region[Customer_Update_Status]
        public static void Customer_Update_Status(string CusId, string Status)
        {
            db.Customer_Update_Status(CusId, Status);
        }
        #endregion
        #region[Customer_CheckLogin]
        public static bool Customer_CheckLogin(string Username, string Password)
        {
            return db.Customer_CheckLogin(Username, Password);
        }
        #endregion
        #region[Customer_ChangePassword]
        public static void Customer_ChangePassword(string Username, string Password)
        {
            db.Customer_ChangePassword(Username, Password);
        }
        #endregion
	}
}