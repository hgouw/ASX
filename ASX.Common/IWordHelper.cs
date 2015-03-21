using System;

namespace Clarius.ManualTimesheet.Interface
{
    public interface IWordHelper : IDisposable
    {
        void OpenFile(string fullPath);
    }
}
