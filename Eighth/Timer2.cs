using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Eighth
{
    /// <summary>
    /// Таймер, основаный на <see cref="System.Timers.Timer"/>
    /// </summary>
    public class Timer2 : ITimer, INotifyPropertyChanged
    {
        private DateTime _startDateTime;
        private System.Timers.Timer _timer;
        private TimeSpan time = TimeSpan.Zero;

        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }

        public Task Start()
        {
            _startDateTime = DateTime.Now;
            _timer ??= new System.Timers.Timer(500);
            _timer.Elapsed += (s, e) =>
            {
                Time += e.SignalTime.Subtract(_startDateTime);
                _startDateTime = DateTime.Now;
            };

            _timer.Start();
            return Task.CompletedTask;
        }

        public void Pause() => _timer?.Stop();

        public void Reset()
        {
            Time = TimeSpan.Zero;
            _timer?.Dispose();
            _timer = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Dispose()
        {
            _timer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
