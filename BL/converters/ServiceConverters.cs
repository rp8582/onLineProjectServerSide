using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.converters
{
    class ServiceConverters
    {
        public static DAL.service GetService(DTO.ServiceDTO serviceDTO)
        {
            DAL.service service = new DAL.service()
            {
                serviceId = serviceDTO.ServiceId ,
                serviceName = serviceDTO.ServiceName ,
                businessId = serviceDTO.BusinessId ,
                categoryId = serviceDTO.CategoryId ,
                kindOfPermission=serviceDTO.KindOfPermission,
            };
            return service;
        }

        public static DTO.ServiceDTO GetServiceDTO(DAL.service service)
        {
            DTO.ServiceDTO serviceDTO = new DTO.ServiceDTO()
            {
                ServiceId = service.serviceId ,
                ServiceName = service.serviceName ,
                BusinessId = service.businessId ,
                CategoryId = service.categoryId ,
                KindOfPermission=service.kindOfPermission,
            };
            return serviceDTO;
        }
    }
}
