using System;
using System.Threading.Tasks;

namespace Eighth
{
    public interface ITimer : IDisposable
    {
        TimeSpan Time { get; set; }

        void Pause();
        void Reset();
        Task Start();
    }
}