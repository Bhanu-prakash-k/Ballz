using System;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    

    public GameObject m_MainMenuQuitPanel;
    public GameObject m_SettingsPanel;
    public GameObject m_PauseMenu;  // or backMenu (panel)

    private float m_timeScale;

    void Start ()
    {
        m_SettingsPanel.SetActive(false);
    }

    void Update()
    {
        switch(GameManager.Instance.m_GameState)
        {
            case GameManager.GameState.MainMenu:
                if (Input.GetKeyUp(KeyCode.Escape) && !m_MainMenuQuitPanel.activeInHierarchy)
                    m_MainMenuQuitPanel.SetActive(true);
                else if (Input.GetKeyUp(KeyCode.Escape) && m_MainMenuQuitPanel.activeInHierarchy)
                    m_MainMenuQuitPanel.SetActive(false);
                break;

            case GameManager.GameState.Playable:
                if (Input.GetKeyUp(KeyCode.Escape) && !m_PauseMenu.activeInHierarchy)
                    ShowPauseMenu();
                else if (Input.GetKeyUp(KeyCode.Escape) && m_PauseMenu.activeInHierarchy)
                    HidePauseMenu();
                break;
        }
    }

    public void StartGame()
    {
        GameManager.Instance.m_GameState = GameManager.GameState.Playable;
    }

    public void ShowPauseMenu()
    {
        // 1 - stop the time scale
        m_timeScale = Time.timeScale;
        Time.timeScale = 0;

        // 2 - active m_PauseMenu
        m_PauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        // 1 - relaunch the time scale
        Time.timeScale = m_timeScale;
        m_timeScale = 0;

        // 2 - deactive m_PauseMenu
        m_PauseMenu.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        // 1 - stop the time scale
        m_timeScale = Time.timeScale;
        Time.timeScale = 0;

        m_SettingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        // 1 - relaunch the time scale
        Time.timeScale = m_timeScale;
        m_timeScale = 0;

        m_SettingsPanel.SetActive(false);
    }

   

    
    




    

    #region GameOver Menu
    public void GotoMainMenuAfterGameOver()
    {
        GameManager.Instance.m_GameState = GameManager.GameState.MainMenu;
        //Saver.Instance.Save(true);
    }

    public void ReplayAfterGameOver()
    {
        GameManager.Instance.m_GameState = GameManager.GameState.MainMenu;
        GameManager.Instance.m_GameState = GameManager.GameState.Playable;
        //Saver.Instance.Save(true);
    }
    #endregion

    #region Pause Menu
    public void GotoMainMenu()
    {
        GameManager.Instance.m_GameState = GameManager.GameState.MainMenu;
        HidePauseMenu();
    }

    public void ResumeGame()
    {
        HidePauseMenu();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID && !UNITY_EDITOR
        ScoreManager.Instance.SubmitScoreToLeaderboard();
        Application.Quit();
#endif
    }
    #endregion
}