using System;
namespace MP.ApiDotNet6.Application.DTOs.Purchase
{
	public class PurchaseDTO
	{
		public string CodErp { get; set; }				
        public string Document { get; set; }
        public int Id { get; set; }
        public string?  ProductName  { get; set; }
        public decimal? Price { get; set; }
    }
}

