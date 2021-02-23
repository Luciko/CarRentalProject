﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Ef
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from ca in context.Cars
                             join co in context.Color on ca.ColorId equals co.Id
                             join br in context.Brand on ca.BrandId equals br.Id
                             select new CarDetailsDto
                             {
                                 CarId = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}