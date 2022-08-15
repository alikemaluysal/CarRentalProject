using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarDetailTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var list = carManager.GetCarDetails();
            if (list.Success)
            {
                foreach (var item in list.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3} ", item.BrandName, item.ModelYear, item.ColorName, item.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(list.Message);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var list = carManager.GetAll();
            if (list.Success)
            {
                foreach (var item in list.Data)
                {
                    Console.WriteLine(item.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(list.Message);
            }

        }
    }
}