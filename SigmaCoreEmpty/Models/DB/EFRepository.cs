using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreEmpty.Models.DB
{
    public class EFRepository:IRepository
    {
        adonetContext _dbContrext = new adonetContext();

        public void Delete(int Id)
        {
            var deleteAnimals = _dbContrext.Animals.FirstOrDefault(animals => animals.Id == Id);
            if (deleteAnimals!=null)
            {
                _dbContrext.Animals.Remove(deleteAnimals);
                _dbContrext.SaveChanges();
            }

        }

        public void Update(string name, decimal weight, decimal height, int Id)
        {
            var updateAnimals = _dbContrext.Animals.FirstOrDefault(animals => animals.Id == Id);
            if (updateAnimals != null)
            {
                updateAnimals.Height = height;
                updateAnimals.Weight = weight;
                updateAnimals.Name = name;
                _dbContrext.SaveChanges();
            }
        }

        public void AddAnimals(string name, decimal weight, decimal height)
        {
            Animals animals = new Animals();
            animals.Height = height;
            animals.Weight = weight;
            animals.Name = name;
            _dbContrext.Animals.Add(animals);
            _dbContrext.SaveChanges();
        }

        public List<GenarateAnimals> SelectAnimals()
        {
            List<GenarateAnimals> lstAnimals = new List<GenarateAnimals>();
            var selc = _dbContrext.Animals.Select(animals => animals).ToList();
            foreach (var animal in selc)
            {
                lstAnimals.Add(new GenarateAnimals { Height = (decimal)animal.Height,Id = animal.Id,Weigth = (decimal)animal.Weight,Name = animal.Name});
            }
            return lstAnimals;
        }
    }
}
