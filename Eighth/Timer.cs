using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Eighth
{
    /// <summary>
    /// Таймер на тасках. Время отстает
    /// </summary>
    //[Obsolete("Время отстает", true)]
    public class Timer : ITimer, INotifyPropertyChanged
    {
        private readonly TimeSpan Delay = TimeSpan.FromMilliseconds(100);
        private TimeSpan time = TimeSpan.Zero;
        private CancellationTokenSource tokenSource = new();
        private CancellationToken Token => tokenSource.Token;

        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }

        public async Task Start()
        {
            tokenSource = new();
            while (!Token.IsCancellationRequested)
            {
                var delay = Task.Delay(Delay);
                var setTime = Task.Run(() => Time += Delay);
                await Task.WhenAll(delay, setTime).ConfigureAwait(false);

                //Time += Delay;
                //await Task.Delay(Delay);
            }
        }

        public void Pause() => tokenSource.Cancel();

        public void Reset()
        {
            tokenSource.Cancel();
            Time = TimeSpan.Zero;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
