using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class ShowTimesService
	{
		private static readonly ShowTimesDAL db = new ShowTimesDAL();
		#region[ShowTimes_GetById]
		public static DataTable ShowTimes_GetById(string Id)
		{
			return db.ShowTimes_GetById(Id);
		}
		#endregion
		#region[ShowTimes_GetByAll]
		public static DataTable ShowTimes_GetByAll()
		{
			return db.ShowTimes_GetByAll();
		}
		#endregion
		#region[ShowTimes_GetByTop]
		public static DataTable ShowTimes_GetByTop(string Top, string Where, string Order)
		{
			return db.ShowTimes_GetByTop(Top, Where, Order);}
		#endregion
        #region[ShowTimes_GetByTop1]
        public static DataTable ShowTimes_GetByTop1(string Top, string Where, string Order)
        {
            return db.ShowTimes_GetByTop1(Top, Where, Order);
        }
        #endregion
        #region[ShowTimes_GetByTop2]
        public static DataTable ShowTimes_GetByTop2(string Top, string Where, string Order)
        {
            return db.ShowTimes_GetbyTop2(Top, Where, Order);
        }
        #endregion
		#region[ShowTimes_Insert]
		public static void ShowTimes_Insert(ShowTimesInfo Data)
		{
			 db.ShowTimes_Insert(Data);
		}
		#endregion
		#region[ShowTimes_Update]
		public static void ShowTimes_Update(ShowTimesInfo Data)
		{
			 db.ShowTimes_Update(Data);
		}
		#endregion
		#region[ShowTimes_Delete]
		public static void ShowTimes_Delete(string Id)
		{
			 db.ShowTimes_Delete(Id);
		}
		#endregion
		#region[ShowTimes_GetByCinId]
		public static DataTable ShowTimes_GetByCinId(string CinId)
		{
			 return db.ShowTimes_GetByCinId(CinId);
		}
		#endregion
        #region[ShowTimes_GetbyFilId]
        public static DataTable ShowTimes_GetByFilId(string FilId)
        {
            return db.ShowTimes_GetByFilId(FilId);
        }
        #endregion
        #region[ShowTimes_Update_Status]
        public static void ShowTimes_Update_Status(string ShoId, string Status)
        {
            db.ShowTimes_Update_Status(ShoId, Status);
        }
        #endregion
        #region[ShowTimes_Update_Price]
        public static void ShowTimes_Update_Price(string ShoId, string Price)
        {
            db.ShowTimes_Update_Price(ShoId, Price);
        }
        #endregion
        #region[ShowTimes_Update_View]
        public static void ShowTimes_Update_View(string ShoId)
        {
            db.ShowTimes_Update_View(ShoId);
        }
        #endregion
	}
}