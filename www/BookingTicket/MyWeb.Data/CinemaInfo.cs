namespace MyWeb.Data 
{
	public class CinemaInfo : SqlDataProvider
	{
		public string CinId { get; set; }
		public string NameCi { get; set; }
		public string Address { get; set; }
		public string Seats { get; set; }
		public string Phone { get; set; }
        public string Image { get; set; }
		public string Status { get; set; }

	}
}