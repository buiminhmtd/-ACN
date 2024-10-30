using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class FilmService
	{
		private static readonly FilmDAL db = new FilmDAL();
		#region[Film_GetById]
		public static DataTable Film_GetById(string Id)
		{
			return db.Film_GetById(Id);
		}
		#endregion
		#region[Film_GetByAll]
		public static DataTable Film_GetByAll()
		{
			return db.Film_GetByAll();
		}
		#endregion
		#region[Film_GetByTop]
		public static DataTable Film_GetByTop(string Top, string Where, string Order)
		{
			return db.Film_GetByTop(Top, Where, Order);}
		#endregion
		#region[Film_Insert]
		public static void Film_Insert(FilmInfo Data)
		{
			 db.Film_Insert(Data);
		}
		#endregion
		#region[Film_Update]
		public static void Film_Update(FilmInfo Data)
		{
			 db.Film_Update(Data);
		}
		#endregion
		#region[Film_Delete]
		public static void Film_Delete(string Id)
		{
			 db.Film_Delete(Id);
		}
		#endregion
		#region[Film_GetByCouId]
		public static DataTable Film_GetByCouId(string CouId)
		{
			 return db.Film_GetByCouId(CouId);
		}
		#endregion
        #region[Film_GetbyTypId]
        public static DataTable Film_GetByTypId(string TypId)
        {
            return db.Film_GetByTypId(TypId);
        }
        #endregion
        #region[Film_Update_Status]
        public static void Film_Update_Status(string FilId, string Status)
        {
            db.Film_Update_Status(FilId, Status);
        }
        #endregion
	}
}