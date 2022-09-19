using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helpers.FileHelper;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.XPath;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        //private string _root = "wwwrooot\\Images\\CarImages";
        private string _root = "Resources\\Images\\";

        public CarImageManager(ICarImageDal iCarImageDal, IFileHelper iFileHelper)
        {
            _carImageDal = iCarImageDal;
            _fileHelper = iFileHelper;

        }

    public IResult Add(IFormFile image, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckCarImageLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }
            string imagePath = _fileHelper.Upload(image, _root);
            carImage.ImagePath = imagePath;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);

        }
        public IResult Update(IFormFile image, CarImage carImage)
        {
            var oldImage = _carImageDal.Get(i=>i.Id == carImage.Id);
            if (oldImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFund);
            }
            _fileHelper.Update(image, oldImage.ImagePath, _root);
            return new SuccessResult(Messages.CarImageUpdated);

        }
        public IResult Delete(CarImage carImage)
        {
            var imageToDelete = _carImageDal.Get(i => i.Id == carImage.Id);
            if (imageToDelete == null)
            {
                return new ErrorResult(Messages.CarImageNotFund);
            }
            _fileHelper.Delete(imageToDelete.ImagePath);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count == 0)
            {
                result = new List<CarImage> { new CarImage { ImagePath = "DefaultImage.png" } };

            }
            return new SuccessDataResult<List<CarImage>>(result);

        }
        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
