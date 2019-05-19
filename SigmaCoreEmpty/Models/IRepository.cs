using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SigmaCoreEmpty.Models;

namespace SigmaCoreEmpty
{
    public interface IRepository
    {
        void Delete(int id);
        void Update(string name, decimal weight, decimal height, int Id);
        void AddAnimals(string name, decimal weight, decimal height);

        List<GenarateAnimals> SelectAnimals();
    }
}
