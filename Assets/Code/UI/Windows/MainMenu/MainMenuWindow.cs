using Code.DataManagement;
using Code.Scenes;
using Code.UI.Windows.Common;
using Code.UI.WindowsSystem;
using UnityEngine;

namespace Code.UI.Windows.MainMenu
{
    public class MainMenuWindow : Window<MainMenuWindowDisplay>, ILoadable, ISavable
    {
        private GameSettingsManager settingsManager;
        private ScenesManager scenesManager;
        private GameState gameStateData;

        private void Awake()
        {
            scenesManager = FindObjectOfType<ScenesManager>();
            settingsManager = FindObjectOfType<GameSettingsManager>();
            SaveLoadManager.RegisterLoadable(this);
            SaveLoadManager.RegisterSavable(this);
            Display.OnNewGameButtonClick += Display_OnNewGameButtonClick;
            Display.OnContinueGameButtonClick += Display_OnContinueGameButtonClick;
            Display.OnSettingsButtonClick += Display_OnSettingsButtonClick;
            Display.OnExitButtonClick += Display_OnExitButtonClick;
        }

        private void Start()
        {
            SaveLoadManager.Load();
            Display.ContinueButtonInteractable = gameStateData.CurrentLevelIndex > 0;
        }

        private void OnDestroy()
        {
            SaveLoadManager.UnregisterLoadable(this);
            SaveLoadManager.UnregisterSavable(this);
        }

        private void Display_OnNewGameButtonClick()
        {
            WindowsManager.OpenWindow<ChangeNameWindow>();
            var changeNameWindow = WindowsManager.GetWindow<ChangeNameWindow>();
            changeNameWindow.Init(settingsManager.PlayerData.Name);
            changeNameWindow.OnNameChanged -= OnPlayerNameSet;
            changeNameWindow.OnNameChanged += OnPlayerNameSet;
        }

        private void Display_OnContinueGameButtonClick()
        {
            LoadGameplay();
        }

        private void Display_OnSettingsButtonClick()
        {
            WindowsManager.OpenWindow<SettingsWindow>();
        }

        private void Display_OnExitButtonClick()
        {
            Application.Quit();
        }

        public void LoadData()
        {
            gameStateData = SaveLoadManager.LoadData<GameState>(GameState.DefaultUniqueID);
        }

        private void OnPlayerNameSet(string playerName)
        {
            gameStateData = new();
            settingsManager.PlayerData.Name = playerName;
            SaveLoadManager.Save();
            LoadGameplay();
        }

        private void LoadGameplay()
        {
            scenesManager.Load(SceneNames.GAMEPLAY);
        }

        public void SaveData()
        {
            SaveLoadManager.SaveData(gameStateData);
        }
    }
}