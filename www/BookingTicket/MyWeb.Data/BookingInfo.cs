namespace MyWeb.Data 
{
	public class BookingInfo : SqlDataProvider
	{
		public string BooId { get; set; }
		public string CusId { get; set; }
		public string ShoId { get; set; }
		public string Quantity { get; set; }
		public string Status { get; set; }
        public string DateBooking { get; set; }
        public string Bilmoney { get; set; }
	}
}