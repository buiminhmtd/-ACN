namespace MyWeb.Data 
{
	public class ShowTimesInfo : SqlDataProvider
	{
		public string ShoId { get; set; }
		public string FilId { get; set; }
		public string CinId { get; set; }
		public string ShowTime { get; set; }
        public string Time { get; set; }
		public string Price { get; set; }
		public string Status { get; set; }
        public string View { get; set; }
	}
}