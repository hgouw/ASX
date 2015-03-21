using System;

namespace Clarius.ManualTimesheet.Interface
{
    public interface IOutlookHelper : IDisposable
    {
        void OpenFile(string fullPath);
    }
}
