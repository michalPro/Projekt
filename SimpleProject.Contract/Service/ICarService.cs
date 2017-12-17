using SimpleProject.Contract.DataContracts;
using System.Collections.Generic;

namespace SimpleProject.Contract.Service
{
    public interface ICarService
    {
        CommonResult<CarDto> GetById(int id);
        CommonResult<List<CarDto>> GetAll();
        CommonResult Delete(int id);
        CommonResult Add(CarDto model);
        CommonResult Edit(CarDto model);
    }
}
