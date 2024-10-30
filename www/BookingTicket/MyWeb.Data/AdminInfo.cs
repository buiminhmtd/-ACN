namespace MyWeb.Data 
{
	public class AdminInfo : SqlDataProvider
	{
		public string AdmId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string Bod { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

	}
}