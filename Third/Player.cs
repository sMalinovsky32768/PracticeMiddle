using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Third
{
    public class Player : IPlayable, IRecodable, INotifyPropertyChanged
    {
        private PlayerState state = PlayerState.Stopped;

        public PlayerState State
        {
            get => state;
            private set
            {
                state = value;
                OnPropertyChanged();
            }
        }
        public void Pause()
        {
            if (State is not PlayerState.Stopped)
            {
                State = State switch
                {
                    PlayerState.Playing => PlayerState.PlayOnPause,
                    PlayerState.Recording => PlayerState.RecordOnPause,
                    PlayerState.PlayOnPause => PlayerState.Playing,
                    PlayerState.RecordOnPause => PlayerState.Recording,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public void Play()
        {
            if (State is not PlayerState.Playing)
            {
                State = PlayerState.Playing;
            }
        }

        public void Record()
        {
            if (State is not PlayerState.Recording)
            {
                State = PlayerState.Recording;
            }
        }

        public void Stop()
        {
            if (State is not PlayerState.Stopped)
            {
                State = PlayerState.Stopped;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
