using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class SlideService
	{
		private static readonly SlideDAL db = new SlideDAL();
		#region[Slide_GetById]
		public static DataTable Slide_GetById(string Id)
		{
			return db.Slide_GetById(Id);
		}
		#endregion
		#region[Slide_GetByAll]
		public static DataTable Slide_GetByAll()
		{
			return db.Slide_GetByAll();
		}
		#endregion
		#region[Slide_GetByTop]
		public static DataTable Slide_GetByTop(string Top, string Where, string Order)
		{
			return db.Slide_GetByTop(Top, Where, Order);}
		#endregion
		#region[Slide_Insert]
		public static void Slide_Insert(SlideInfo Data)
		{
			 db.Slide_Insert(Data);
		}
		#endregion
		#region[Slide_Update]
		public static void Slide_Update(SlideInfo Data)
		{
			 db.Slide_Update(Data);
		}
		#endregion
		#region[Slide_Delete]
		public static void Slide_Delete(string Id)
		{
			 db.Slide_Delete(Id);
		}
		#endregion
		#region[Slide_GetByFilId]
		public static DataTable Slide_GetByFilId(string FilId)
		{
			 return db.Slide_GetByFilId(FilId);
		}
		#endregion
        #region[Silde_Update_Status]
        public static void Silde_Update_Status(string SliId, string Status)
        {
            db.Silde_Update_Status(SliId, Status);
        }
        #endregion
	}
}