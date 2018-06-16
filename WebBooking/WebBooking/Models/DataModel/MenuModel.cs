
using System;

namespace WebBooking.Models.DataModel
{
	public class MenuModel 
	{
	
		public int ID { get; set; }
	
		public string Name { get; set; }
	
		public string Link { get; set; }
	
		public int Order { get; set; }
	
		public int ParentID { get; set; }
	
	}
}
	