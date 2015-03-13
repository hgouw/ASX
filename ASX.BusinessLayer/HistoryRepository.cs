using System;

namespace ASX.BusinessLayer
{
    public class HistoryRepository
    {
        public History Retrieve(DateTime date, string code)
        {
            var history = new History(date, code);
            history.Open = 2;
            history.High = 2;
            history.Low = 2;
            history.Last = 2;
            return history;
        }

        public bool Save(History history)
        {
            var success = true;

            if (history.IsValid && history.HasChanges)
            {
                if (history.IsNew)
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