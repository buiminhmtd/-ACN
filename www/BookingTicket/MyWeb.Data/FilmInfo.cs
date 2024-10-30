namespace MyWeb.Data 
{
	public class FilmInfo : SqlDataProvider
	{
		public string FilId { get; set; }
		public string TypId { get; set; }
		public string CouId { get; set; }
        public string NameF { get; set; }
		public string Director { get; set; }
		public string Actor { get; set; }
		public string Duration { get; set; }
		public string Description { get; set; }
        public string Detail { get; set; }
		public string Picture { get; set; }
        public string PictureBig { get; set; }
		public string Status { get; set; }

	}
}