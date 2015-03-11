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

        public bool Save()
        {
            return true;
        }
    }
}