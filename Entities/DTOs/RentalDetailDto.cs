using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string CompanyName { get; set; }
        public string CarBrand { get; set; }
        public decimal CarDailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
