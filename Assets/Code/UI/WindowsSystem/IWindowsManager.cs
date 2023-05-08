namespace Code.UI.WindowsSystem
{
    public interface IWindowsManager
    {
        void OpenWindow<T>() where T : Window;
        void CloseCurrentWindow();
        T GetWindow<T>() where T : Window;
    }
}