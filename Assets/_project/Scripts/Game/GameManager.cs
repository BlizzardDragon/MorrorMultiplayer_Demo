namespace _project.Scripts.Game
{
    public enum GameStatus
    {
        Pause,
        Play
    }

    public interface IGameManager
    {
        GameStatus CurrentGameStatus { get; }

        void SetGameStatus(GameStatus gameStatus);
    }

    public class GameManager : IGameManager
    {
        public GameStatus CurrentGameStatus { get; private set; }

        public void SetGameStatus(GameStatus gameStatus)
        {
            CurrentGameStatus = gameStatus;
        }
    }
}