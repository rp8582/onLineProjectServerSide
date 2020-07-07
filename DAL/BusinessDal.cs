﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BusinessDal
    {
        public static business GetBusinessById(int id)
        {
            try
            {
                using (onLineEntities1 entities1 = new onLineEntities1())
                {
                    return entities1.businesses.FirstOrDefault(b => b.businessId == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddBusiness(business business)
        {
            using (onLineEntities1 entities1=new onLineEntities1())
            {
                entities1.businesses.Add(business);
                entities1.SaveChanges();
                int id = business.businessId;
            }
        }
    }
}
