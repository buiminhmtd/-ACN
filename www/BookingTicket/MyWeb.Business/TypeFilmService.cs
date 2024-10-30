using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class TypeFilmService
	{
		private static readonly TypeFilmDAL db = new TypeFilmDAL();
		#region[TypeFilm_GetById]
		public static DataTable TypeFilm_GetById(string Id)
		{
			return db.TypeFilm_GetById(Id);
		}
		#endregion
		#region[TypeFilm_GetByAll]
		public static DataTable TypeFilm_GetByAll()
		{
			return db.TypeFilm_GetByAll();
		}
		#endregion
		#region[TypeFilm_GetByTop]
		public static DataTable TypeFilm_GetByTop(string Top, string Where, string Order)
		{
			return db.TypeFilm_GetByTop(Top, Where, Order);}
		#endregion
		#region[TypeFilm_Insert]
		public static void TypeFilm_Insert(TypeFilmInfo Data)
		{
			 db.TypeFilm_Insert(Data);
		}
		#endregion
		#region[TypeFilm_Update]
		public static void TypeFilm_Update(TypeFilmInfo Data)
		{
			 db.TypeFilm_Update(Data);
		}
		#endregion
		#region[TypeFilm_Delete]
		public static void TypeFilm_Delete(string Id)
		{
			 db.TypeFilm_Delete(Id);
		}
		#endregion
        #region[TypeFilm_Update_Status]
        public static void TypeFilm_Update_Status(string TypId, string Status)
        {
            db.TypeFilm_Update_Status(TypId, Status);
        }
        #endregion
	}
}