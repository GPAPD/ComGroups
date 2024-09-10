using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComGroups.Services.CouponAPI.Model
{
	public class Coupon
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int CouponId { get; set; }
		[Required]
		public string CouponCode { get; set; }
		[Required]
		public double DiscountAmount { get; set; }
		public double MinAmount { get; set; }
	}
}
