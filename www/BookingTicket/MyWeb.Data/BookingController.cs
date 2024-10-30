using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Data
{
	public class BookingDAL : SqlDataProvider
	{

		#region[Booking_GetbyAll]
		public DataTable Booking_GetByAll()
		{
			using (var cmd = new SqlCommand("sp_Booking_GetByAll", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				return GetTable(cmd);
			}
		}
		#endregion
        #region[Booking_Sum]
        public DataTable Booking_Sum(string ShoId)
        {
            using (var cmd = new SqlCommand("sp_Booking_Sum", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ShoId", ShoId));
                return GetTable(cmd);
            }
        }
        #endregion
		#region[Booking_GetbyId]
		public DataTable Booking_GetById(string BooId)
		{
			using (var cmd = new SqlCommand("sp_Booking_GetById", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@BooId", BooId));return GetTable(cmd);
			}
		}
		#endregion
		#region[Booking_GetbyTop]
		public DataTable Booking_GetByTop(string Top, string Where, string Order)
		{
			using (var cmd = new SqlCommand("sp_Booking_GetByTop", GetConnection()))
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
		#region[Booking_GetbyCusId]
		public DataTable Booking_GetByCusId(string CusId)
		{
			using (var cmd = new SqlCommand("sp_Booking_GetByCusId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CusId", CusId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[Booking_GetbyShoId]
		public DataTable Booking_GetByShoId(string ShoId)
		{
			using (var cmd = new SqlCommand("sp_Booking_GetByShoId", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@ShoId", ShoId));
				var da = new SqlDataAdapter(cmd);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}
		#endregion
		#region[Booking_Insert]
		public void Booking_Insert(BookingInfo Data)
		{
			using (var cmd = new SqlCommand("sp_Booking_Insert", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@CusId", Data.CusId));
				cmd.Parameters.Add(new SqlParameter("@ShoId", Data.ShoId));
                cmd.Parameters.Add(new SqlParameter("@Bilmoney", Data.Bilmoney));
				cmd.Parameters.Add(new SqlParameter("@Quantity", Data.Quantity));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Booking_Update]
        public void Booking_Update(string BooId)
		{
			using (var cmd = new SqlCommand("sp_Booking_Update", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@BooId", BooId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion
		#region[Booking_Delete]
		public void Booking_Delete(string BooId)
		{
			using (var cmd = new SqlCommand("sp_Booking_Delete", GetConnection()))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@BooId",BooId));
				ExeCuteNonquery(cmd);
			}
		}
		#endregion

	}
}