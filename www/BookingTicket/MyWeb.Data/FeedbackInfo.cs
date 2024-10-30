namespace MyWeb.Data 
{
	public class FeedbackInfo : SqlDataProvider
	{
		public string FeeId { get; set; }
		public string FilId { get; set; }
		public string FullName { get; set; }
		public string Comment { get; set; }
		public string Created { get; set; }
		public string Status { get; set; }
        public string Avata { get; set; }
	}
}