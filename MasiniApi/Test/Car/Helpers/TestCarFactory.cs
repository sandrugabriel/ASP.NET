using MasiniApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Car.Helpers
{
    public class TestCarFactory
    {

        public static Masini CreateCar(int id)
        {
            return new Masini
            {
                Id = id,
                Model = "test" + id.ToString(),
                Marca = id.ToString(),
                Year = 2000 + id,
                Culoare = "alba"

            };
        }

        public static List<Masini> CreateCars(int cout) {
        
            List<Masini> cars = new List<Masini>();

            for(int i=0; i < cout; i++)
            {
                cars.Add(CreateCar(i));
            }

            return cars;
        }

        public static List<int> CreateYearsCar(int count)
        {
            Random random = new Random();
            List<int> years = new List<int>();
            for(int i=0;i< count; i++)
            {
                years.Add(random.Next(1900,2024));
            }

            return years;
        }

    }
}
