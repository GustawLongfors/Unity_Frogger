using UnityEngine;

namespace Code.UI.WindowsSystem
{
    public abstract class Window : MonoBehaviour
    {
        protected IWindowsManager WindowsManager { get; private set; }

        public void Initialize(IWindowsManager windowsManager)
        {
            WindowsManager = windowsManager;
            Close();
        }

        public abstract void Open();
        public abstract void Close();
    }

    public abstract class Window<T> : Window where T : WindowDisplay
    {
        [SerializeField] private T windowDisplay;

        protected T Display => windowDisplay;

        public override void Open()
        {
            windowDisplay.Show();
        }

        public override void Close()
        {
            windowDisplay.Hide();
        }
    }
}