using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult Add(IFormFile image, CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
