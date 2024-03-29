using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUILevelManager : MonoBehaviour
{
    [SerializeField] private Sprite toggleFalse;
    [SerializeField] private Sprite toggleTrue;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private GameObject musicToggle;
    [SerializeField] private GameObject soundToggle;
    [SerializeField] private GameObject fullscreenToggle;
    [SerializeField] private GameObject menu;

    bool isMainMenuOn = true;

    static bool isFullScreen = true;

    private void Awake()
    {
        if (mainMenu == null)
        {
            isMainMenuOn = false;
        }
        if (MusicManager.isMusicOn)
        {
            musicToggle.GetComponent<Image>().sprite = toggleTrue;
        }
        else
        {
            musicToggle.GetComponent<Image>().sprite = toggleFalse;
        }
        if (SoundManager.isSoundOn)
        {
            soundToggle.GetComponent<Image>().sprite = toggleTrue;
        }
        else
        {
            soundToggle.GetComponent<Image>().sprite = toggleFalse;
        }
        if (isFullScreen)
        {
            fullscreenToggle.GetComponent<Image>().sprite = toggleTrue;
        }
        else
        {
            fullscreenToggle.GetComponent<Image>().sprite = toggleFalse;
        }
    }

    private void Update()
    {
        if (isMainMenuOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (levelMenu.activeSelf)
                {
                    Messenger.Broadcast(GameEvent.BUTTON_SOUND);
                    mainMenu.SetActive(true);
                    levelMenu.SetActive(false);
                }
                if (howToPlayMenu.activeSelf)
                {
                    Messenger.Broadcast(GameEvent.BUTTON_SOUND);
                    mainMenu.SetActive(true);
                    howToPlayMenu.SetActive(false);
                }
            }
        }
    }

    public void StartLevel(GameObject scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void Continue()
    {
        Manager.link.isItOver = false;
        Manager.link.isMenuOn = false;
        menu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void FullScreenToggle(Button button)
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            button.image.sprite = toggleTrue;
        }
        else
        {
            button.image.sprite = toggleFalse;
        }
    }

    public void SoundToggle(Button button)
    {
        SoundManager.isSoundOn = !SoundManager.isSoundOn;
        if (SoundManager.isSoundOn)
        {
            Messenger.Broadcast(GameEvent.ON_SOUND);
            button.image.sprite = toggleTrue;
        }
        else
        {
            Messenger.Broadcast(GameEvent.OFF_SOUND);
            button.image.sprite = toggleFalse;
        }
    }

    public void MusicToggle(Button button)
    {
        MusicManager.isMusicOn = !MusicManager.isMusicOn;
        if (MusicManager.isMusicOn)
        {
            Messenger.Broadcast(GameEvent.ON_MUSIC);
            button.image.sprite = toggleTrue;
        }
        else
        {
            Messenger.Broadcast(GameEvent.OFF_MUSIC);
            button.image.sprite = toggleFalse;
        }
    }

    public void ButtonSoundBroadcast()
    {
        Messenger.Broadcast(GameEvent.BUTTON_SOUND);
    }
    public void ReloadSceneButton()
    {
        Manager.link.ReloadScene();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
