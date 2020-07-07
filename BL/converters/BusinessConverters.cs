using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.converters
{
  public  class BusinessConverters
    {

        public static DAL.business GetBusiness(BusinessDTO BusinessDto)
        {
            DAL.business business = new DAL.business()
            {
                businessName = BusinessDto.BusinessName ,
                passward = BusinessDto.Password ,
                Adress_city = BusinessDto.Address_city ,
                Adress_street = BusinessDto.Address_street ,
                Adress_numOfStreet = BusinessDto.Address_numOfBuilding ,
                managerid = BusinessDto.ChainManagerId
            };
            return business;
        }

        public static BusinessDTO GetBusinessDTO(DAL.business business)
        {
            BusinessDTO businessDTO = new BusinessDTO()
            {
                BusinessId = business.businessId ,
                BusinessName = business.businessName ,
                Password = business.passward ,
                Address_city = business.Adress_city ,
                Address_street = business.Adress_street ,
                Address_numOfBuilding = business.Adress_numOfStreet ,
                ChainManagerId = (int) business.managerid
            };
            return businessDTO;
        }

        public static List<BusinessDTO> GetListBusinessDTO(List<DAL.business> lBusiness)
        {
            List<BusinessDTO> l = new List<BusinessDTO>();
            lBusiness.ForEach(b => l.Add(GetBusinessDTO(b)));
            return l;
        }

        public static List<DAL.business> GetListBusiness(List<BusinessDTO> lBusiness)
        {
            List<DAL.business> l = new List<DAL.business>();
            lBusiness.ForEach(b => l.Add(GetBusiness(b)));
            return l;
        }



        /// business to show

        public static TurnInBusinessDTO GetSmallBusinessDTO(DAL.business business)
        {
            TurnInBusinessDTO businessDTO = new TurnInBusinessDTO()
            {
                BusinessName = business.businessName ,
                Address = business.Adress_city + " " + business.Adress_street + " " + business.Adress_numOfStreet ,
            };
            return businessDTO;
        }


        public static List<TurnInBusinessDTO> GetListSmallBusinessDTO(List<DAL.business> lBusiness)
        {
            List<TurnInBusinessDTO> l = new List<TurnInBusinessDTO>();
            lBusiness.ForEach(b => l.Add(GetSmallBusinessDTO(b)));
            return l;
        }

    }
}
