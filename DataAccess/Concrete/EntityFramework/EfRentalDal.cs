using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new RentalDetailDto()
                             {
                                 Id = r.Id,
                                 CarBrand = b.Name,
                                 CompanyName = cu.CompanyName,
                                 UserFullName = u.FirstName + " " + u.LastName,
                                 CarDailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }

    }
}
