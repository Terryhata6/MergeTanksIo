using System.Collections.Generic;
using UnityEngine;

public class UIController : BaseController
{
    private List<BaseMenuView> _menues;
    private UIView _uiView;

    public UIController()
    {
        _menues = new List<BaseMenuView>();
    }


    public override void Initialize()
    {
        base.Initialize();

        _uiView = Object.Instantiate(Resources.Load<GameObject>("UI/UI")).GetComponent<UIView>();

        for (int i = 0; i < _uiView.Menues.Length; i++)
        {
            AddView(_uiView.Menues[i]);
        }

        UIEvents.Current.OnButtonStartGame += StartGame;
        UIEvents.Current.OnButtonPauseGame += PauseGame;
        UIEvents.Current.OnButtonResumeGame += StartGame;
        UIEvents.Current.OnButtonNextLevel += NextLevel;
        UIEvents.Current.OnButtonRestartGame += RestartGame;

        LevelEvents.Current.OnLevelComplete += WinGame;
        LevelEvents.Current.OnLevelFailed += LoseGame;

        Time.timeScale = 0.0f;
        SwitchUI(UIState.MainMenu);
    }


    private void StartGame()
    {
        Time.timeScale = 1.0f;
        SwitchUI(UIState.InGame);
        LevelEvents.Current.LevelStart();
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        SwitchUI(UIState.Pause);
    }

    private void WinGame()
    {
        Time.timeScale = 0.0f;
        SwitchUI(UIState.WinMenu);
    }

    private void LoseGame()
    {
        Time.timeScale = 0.0f;
        SwitchUI(UIState.LoseMenu);
    }

    private void NextLevel()
    {
        LevelEvents.Current.LevelNext();
    }

    private void RestartGame()
    {
        LevelEvents.Current.LevelRestart();
    }

    private void AddView(BaseMenuView view)
    {
        _menues.Add(view);
    }

    #region Switch
    private void SwitchUI(UIState state)
    {
        if (_menues.Count == 0)
        {
            Debug.LogWarning("There is no menues to switch.");
        }
        switch (state)
        {
            case UIState.MainMenu:
                SwitchMenu(typeof(MainMenuView));
                break;
            case UIState.InGame:
                SwitchMenu(typeof(InGameUIView));
                break;
            case UIState.Pause:
                SwitchMenu(typeof(PauseMenuView));
                break;
            case UIState.WinMenu:
                SwitchMenu(typeof(WinMenuView));
                break;
            case UIState.LoseMenu:
                SwitchMenu(typeof(LoseMenuView));
                break;
        }
    }
    private void SwitchMenu(System.Type type)
    {
        bool isFound = false;

        for (int i = 0; i < _menues.Count; i++)
        {
            if (_menues[i].GetType() == type)
            {
                _menues[i].Show();
                isFound = true;
            }
            else
            {
                _menues[i].Hide();
            }

            if (i == _menues.Count - 1f && !isFound)
            {
                Debug.LogWarning($"Oops! Menu {type} not found");
            }
        }
    }
    #endregion
}