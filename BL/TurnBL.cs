using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class TurnBL
    {
        public static bool IsAvailableHour(ref int index, int numOfWorkers, TimeSpan hour, List<customersInLine> line)
        {
            if (index >= line.Count() || line[index].estimatedHour.TimeOfDay >= hour)
            {
                return true;
            }
            else//אם יש כבר תור בזמן זה 
                // בודק תור פנוי גם לפי מספר הקופות
            {
                int countTurnsForSameHour = 0;
                while (index < line.Count() && line[index].estimatedHour.TimeOfDay == hour)
                {
                    index++;
                    countTurnsForSameHour++;

                }
                if (countTurnsForSameHour < numOfWorkers)
                    return true;
            }
            return false;
        }

        //todo:לאיזה מחלקה מתאימה הפונקציה
        public static void DeleteTurn(int turnId)
        {
            TurnDal.DeleteTurn(turnId);
        }
    }

}
