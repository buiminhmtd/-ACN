using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class BookingService
	{
		private static readonly BookingDAL db = new BookingDAL();
		#region[Booking_GetById]
		public static DataTable Booking_GetById(string Id)
		{
			return db.Booking_GetById(Id);
		}
		#endregion
		#region[Booking_GetByAll]
		public static DataTable Booking_GetByAll()
		{
			return db.Booking_GetByAll();
		}
		#endregion
		#region[Booking_GetByTop]
		public static DataTable Booking_GetByTop(string Top, string Where, string Order)
		{
			return db.Booking_GetByTop(Top, Where, Order);}
		#endregion
		#region[Booking_Insert]
		public static void Booking_Insert(BookingInfo Data)
		{
			 db.Booking_Insert(Data);
		}
		#endregion
        #region[Booking_Update_Status]
        public static void Booking_Update_Status(string CinId)
        {
           db.Booking_Update(CinId);
        }
        #endregion
		#region[Booking_Delete]
		public static void Booking_Delete(string Id)
		{
			 db.Booking_Delete(Id);
		}
		#endregion
		#region[Booking_GetByCusId]
		public static DataTable Booking_GetByCusId(string CusId)
		{
			 return db.Booking_GetByCusId(CusId);
		}
		#endregion
        #region[Booking_Sum]
        public static DataTable Booking_Sum(string ShoId)
        {
            return db.Booking_Sum(ShoId);
        }
        #endregion
	}
}