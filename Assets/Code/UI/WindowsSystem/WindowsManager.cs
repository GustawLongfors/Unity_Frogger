using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.WindowsSystem
{
    public class WindowsManager : MonoBehaviour, IWindowsManager
    {
        [SerializeField] private Window firstWindowToOpen;
        
        private readonly Stack<Window> windowsStack = new();
        private List<Window> allWindows;
        private Window currentWindow;

        private void Awake()
        {
            allWindows = new List<Window>(FindObjectsOfType<Window>(true));
            foreach (var window in allWindows)
            {
                window.Initialize(this);
            }

            OpenWindow(firstWindowToOpen);
        }

        private void OpenWindow(Window window)
        {
            if (currentWindow != null)
            {
                currentWindow.Close();
            }
            window.Open();
            windowsStack.Push(window);
            currentWindow = window;
        }

        public void OpenWindow<T>() where T : Window
        {
            var window = GetWindow<T>();
            if (window != null)
            {
                OpenWindow(window);
            }
            else
            {
                throw new InvalidOperationException($"Could not find window of type {typeof(T).Name}");
            }
        }

        public void CloseCurrentWindow()
        {
            if (windowsStack.Count <= 0) return;
            
            var currentWindow = windowsStack.Pop();
            currentWindow.Close();

            if (windowsStack.Count > 0)
            {
                var previousWindow = windowsStack.Peek();
                previousWindow.Open();
                this.currentWindow = previousWindow;
            }
            else
            {
                this.currentWindow = null;
            }
        }

        public T GetWindow<T>() where T : Window
        {
            return allWindows.Find(window => window.GetType() == typeof(T)) as T;
        }
    }
}
