using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCoreEmpty.Models
{
    public class GenarateAnimals
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Weigth { get; set; }
        public decimal Height { get; set; }

        private static List<GenarateAnimals> lstAnimalsesTest = new List<GenarateAnimals>();

        public static List<GenarateAnimals> lstAnimals(int CountAnimals)
        {
             List<string>  lstNameAnimals = new List<string>{"Horse","Dog","Cat","Raptile","Spider","Bird","Camel","Lione","Tiger","Alligator","Fox","Zebra","Beer","Frog","Viper","Meduaza)"};
            if (lstAnimalsesTest.Count<1)
            {
                for (int i = 1; i <= CountAnimals; i++)
                {
                    Random rand = new Random();
                    lstAnimalsesTest.Add(new GenarateAnimals
                    {
                        Height = (decimal)rand.Next(1, 100),
                        Id = i,
                        Name = lstNameAnimals[rand.Next(0, (int)lstNameAnimals.Count - 1)].ToString(),
                        Weigth = (decimal)rand.Next(0, 5)
                    });
                }
            }
            return lstAnimalsesTest;
        }
    }
}
