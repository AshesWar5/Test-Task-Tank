using TestTask.UI.Lose;
using UnityEngine;

namespace TestTask.UI
{
    public class UIMain : ObjectView, ICleaner, ILoseScreenProvider
    {
        [SerializeField]
        private LoseView _lose;

        public void Initialize(IGameRestart restart)
        {
            _lose.Initialize(restart);
            _lose.Hide();
        }

        public void Cleaner()
        {
            _lose.Cleaner();
        }

        public void ShowLoseScreen()
        {
            _lose.Show();
        }
    }
}