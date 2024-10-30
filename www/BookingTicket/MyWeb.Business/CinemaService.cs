using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class CinemaService
	{
		private static readonly CinemaDAL db = new CinemaDAL();
		#region[Cinema_GetById]
		public static DataTable Cinema_GetById(string Id)
		{
			return db.Cinema_GetById(Id);
		}
		#endregion
		#region[Cinema_GetByAll]
		public static DataTable Cinema_GetByAll()
		{
			return db.Cinema_GetByAll();
		}
		#endregion
		#region[Cinema_GetByTop]
		public static DataTable Cinema_GetByTop(string Top, string Where, string Order)
		{
			return db.Cinema_GetByTop(Top, Where, Order);}
		#endregion
		#region[Cinema_Insert]
		public static void Cinema_Insert(CinemaInfo Data)
		{
			 db.Cinema_Insert(Data);
		}
		#endregion
		#region[Cinema_Update]
		public static void Cinema_Update(CinemaInfo Data)
		{
			 db.Cinema_Update(Data);
		}
		#endregion
		#region[Cinema_Delete]
		public static void Cinema_Delete(string Id)
		{
			 db.Cinema_Delete(Id);
		}
		#endregion
        #region[Cinema_Update_Status]
        public static void Cinema_Update_Status(string CinId, string Status)
        {
            db.Cinema_Update_Status(CinId, Status);
        }
        #endregion
	}
}