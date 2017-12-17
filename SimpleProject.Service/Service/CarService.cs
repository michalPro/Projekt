using SimpleProject.Contract;
using SimpleProject.Contract.DataContracts;
using SimpleProject.Contract.Repository;
using SimpleProject.Contract.Service;
using System;
using System.Collections.Generic;

namespace SimpleProject.Service.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CommonResult Add(CarDto model)
        {
            try
            {
                _carRepository.Add(model);

                return CommonResult.Success();
            }
            catch (Exception ex)
            {
                return CommonResult.Failure(ex.Message);
            }
        }

        public CommonResult Delete(int id)
        {
            try
            {
                _carRepository.Delete(id);

                return CommonResult.Success();
            }
            catch (Exception ex)
            {
                return CommonResult.Failure(ex.Message);
            }
        }

        public CommonResult Edit(CarDto model)
        {
            try
            {
                _carRepository.Edit(model);

                return CommonResult.Success();
            }
            catch (Exception ex)
            {
                return CommonResult.Failure(ex.Message);
            }
        }

        public CommonResult<List<CarDto>> GetAll()
        {
            try
            {
                var result = _carRepository.GetAll();

                return CommonResult<List<CarDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return CommonResult<List<CarDto>>.Failure(null, ex.Message);
            }
        }

        public CommonResult<CarDto> GetById(int id)
        {
            try
            {
                var result = _carRepository.GetById(id);

                return CommonResult<CarDto>.Success(result);
            }
            catch (Exception ex)
            {
                return CommonResult<CarDto>.Failure(null, ex.Message);
            }
        }
    }
}
