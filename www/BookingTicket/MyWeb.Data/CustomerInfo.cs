namespace MyWeb.Data 
{
	public class CustomerInfo : SqlDataProvider
	{
		public string CusId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string CreditCard { get; set; }
		public string FullName { get; set; }
		public string Sex { get; set; }
		public string Bod { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
        public string Avata { get; set; }
		public string Status { get; set; }

	}
}