﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Car.Helpers
{
    public class TestCarFactory
    {

        public static MasiniApi.Cars.Models.Car CreateCar(int id)
        {
            return new MasiniApi.Models.Car
            {
                Id = id,
                Model = "test" + id.ToString(),
                Marca = id.ToString(),
                Year = 2000 + id,
                Culoare = "alba"

            };
        }

        public static List<MasiniApi.Cars.Models.Car> CreateCars(int cout) {
        
            List<MasiniApi.Cars.Models.Car> cars = new List<MasiniApi.Cars.Models.Car>();

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
