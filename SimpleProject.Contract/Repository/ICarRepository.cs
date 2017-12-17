using SimpleProject.Contract.DataContracts;
using System.Collections.Generic;

namespace SimpleProject.Contract.Repository
{
    public interface ICarRepository
    {
        CarDto GetById(int id);
        List<CarDto> GetAll();
        void Delete(int id);
        void Add(CarDto model);
        void Edit(CarDto model);
    }
}
