using Third;

namespace ThirdApp
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            Player = new();

            Stop = new PlayerCommand(_ => Player?.Stop(), _ => Player?.State is not PlayerState.Stopped);
            Pause = new PlayerCommand(_ => Player?.Pause(), _ => Player?.State is PlayerState.Playing or PlayerState.Recording);
            Play = new PlayerCommand(_ => Player?.Play(), _ => Player?.State is PlayerState.Stopped or PlayerState.PlayOnPause);
            Record = new PlayerCommand(_ => Player?.Record(), _ => Player?.State is PlayerState.Stopped or PlayerState.RecordOnPause);
        }

        public Player Player { get; }

        public PlayerCommand Stop { get; }
        public PlayerCommand Pause { get; }
        public PlayerCommand Play { get; }
        public PlayerCommand Record { get; }
    }
}
