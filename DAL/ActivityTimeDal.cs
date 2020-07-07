using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ActivityTimeDal
    {
        public static List<activityTime> GetActivityTimes(int id)
        {
            using (onLineEntities1 entities=new onLineEntities1())
            {
                return entities.activityTimes.Where(a => a.serviceId == id).ToList();
            }
        }
    }
}
