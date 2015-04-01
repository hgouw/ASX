using System;

namespace ASX.BusinessLayer
{
    public class EndOfDayRepository
    {
        public EndOfDay Retrieve(string code, DateTime date)
        {
            var endOfDay = new EndOfDay(code, date);
            endOfDay.Open = 2;
            endOfDay.High = 2;
            endOfDay.Low = 2;
            endOfDay.Last = 2;
            return endOfDay;
        }

        public bool Save(EndOfDay endOfDay)
        {
            var success = true;

            if (endOfDay.IsValid && endOfDay.HasChanges)
            {
                if (endOfDay.IsNew)
                {
                    // Call Insert Stored Procedure
                }
                else
                {
                    // Call Update Stored Procedure
                }
            }

            return success;
        }
    }
}