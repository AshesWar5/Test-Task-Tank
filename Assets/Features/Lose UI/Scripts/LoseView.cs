using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI.Lose
{
    public class LoseView : ObjectView, ICleaner
    {
        [SerializeField]
        private Button _restart;

        private IGameRestart _restartGame;

        public Button Restart => _restart;

        public void Initialize(IGameRestart restart)
        {
            _restartGame = restart;
            _restart.onClick.AddListener(OnRestartGame);
        }

        public void Cleaner()
        {
            Restart.onClick.RemoveListener(OnRestartGame);
        }

        private void OnRestartGame()
        {
            _restartGame.RestartGame();
        }
    }
}