

using System;

namespace WebBooking.Models.DataModel
{
    public class OrderModel 
	{
	
		public int ID { get; set; }
	
		public int Customer_ID { get; set; }
	
		public double TotalMoney { get; set; }
	
		public DateTime Date { get; set; }
	
		public int Status { get; set; }
	
	}
}
	