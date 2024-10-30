using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class CountryService
	{
		private static readonly CountryDAL db = new CountryDAL();
		#region[Country_GetById]
		public static DataTable Country_GetById(string Id)
		{
			return db.Country_GetById(Id);
		}
		#endregion
		#region[Country_GetByAll]
		public static DataTable Country_GetByAll()
		{
			return db.Country_GetByAll();
		}
		#endregion
		#region[Country_GetByTop]
		public static DataTable Country_GetByTop(string Top, string Where, string Order)
		{
			return db.Country_GetByTop(Top, Where, Order);}
		#endregion
		#region[Country_Insert]
		public static void Country_Insert(CountryInfo Data)
		{
			 db.Country_Insert(Data);
		}
		#endregion
		#region[Country_Update]
		public static void Country_Update(CountryInfo Data)
		{
			 db.Country_Update(Data);
		}
		#endregion
		#region[Country_Delete]
		public static void Country_Delete(string Id)
		{
			 db.Country_Delete(Id);
		}
		#endregion
        #region[Country_Update_Status]
        public static void Country_Update_Status(string CouId, string Status)
        {
            db.Country_Update_Status(CouId, Status);
        }
        #endregion
	}
}