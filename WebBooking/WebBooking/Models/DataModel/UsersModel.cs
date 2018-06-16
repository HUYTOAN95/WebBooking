using System.ComponentModel.DataAnnotations;

namespace WebBooking.Models.DataModel
{ 
	public class UsersModel 
	{
	  
		public int ID { get; set; }
	
		public string Name { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
	    [DataType(DataType.Password)]
		public string Password { get; set; }
	
		public int Rule { get; set; }
	
		public int Status { get; set; }
	
	}
}
	