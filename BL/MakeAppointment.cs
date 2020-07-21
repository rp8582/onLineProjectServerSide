﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class MakeAppointment
    {

        public static void BookAppointment(TurnDetailsDTO appointment)
        {
            ActivityTimeDTO activityTime = ActivityTimeBL.GetActivityTime(appointment.EstimatedHour.TimeOfDay , appointment.ServiceId);
            customersInLine turn = new customersInLine()
            {
                activityTimeId = activityTime.ActivityTimeId,
                custId=appointment.CustId,
                estimatedHour =appointment.EstimatedHour,
                statusTurn=1,
                
            };
        }
        //todo: ?למצוא שם מתאים יותר
        public static TimeSpan ConsiderHour(DateTime dateTime, ActivityTimeDTO activityTime)
        {
            //מה משך זמן ארוך יותר
            //todo: change in database: avgNumOfWaitingPeople-avgDuration
            //
        }

        public static List<int> GetOptionalDaysPerService(int serviceId)
        {
            int day = (int) DateTime.Today.DayOfWeek + 1;
            List<activityTime> activityTimes = ActivityTimeDal.GetActivityTimes(serviceId);
            List<int> optionalDays = new List<int>();
            int limitDays = ServiceDal.GetServicById(serviceId).limitDays.Value;
            for(int i = 0; i < limitDays; i++, day++)
            {
                if(day == 7)
                    day = 1;
                if(activityTimes.FirstOrDefault(a => a.dayInWeek == day) != null)
                    optionalDays.Add(day);
            }
            return optionalDays;
        }

        public static List<TimeSpan> GetOptionalHoursPerDay(int serviceId , int day)
        {
            List<activityTime> activityTimes = ActivityTimeDal.GetActivityTimesByDay(serviceId , day);
            List<TimeSpan> optionalHours = new List<TimeSpan>();
            int activityTimeIndex = 0;
            int index = 0;
            while(activityTimeIndex < activityTimes.Count())
            {
                activityTime activityTime = activityTimes[activityTimeIndex];
                List<customersInLine> line = TurnDal.GetLinePerBusiness(activityTime.activityTimeId);
                double durationOfService = activityTime.ActualDurationOfService.Value;
                TimeSpan ts = TimeSpan.FromMinutes(durationOfService);
                for(TimeSpan hour = activityTime.startTime; hour < activityTime.endTime; hour = hour.Add(ts))
                {
                    if(TurnBL.IsAvailableHour(ref index , activityTime.numOfWorkers , hour.Add(ts) , line))
                        optionalHours.Add(hour);
                    index++;
                }
                activityTimeIndex++;
            }
            return optionalHours;

        }

    }
}
