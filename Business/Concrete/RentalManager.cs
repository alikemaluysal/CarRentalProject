using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _iRentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarNotReturned);
            }
        }

        public IResult Delete(Rental rental)
        {

            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetAllByCar(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r=>r.CarId==carId), Messages.RentalsListed);

        }

        public IDataResult<List<Rental>> GetAllByCustomer(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.CustomerId == customerId), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
