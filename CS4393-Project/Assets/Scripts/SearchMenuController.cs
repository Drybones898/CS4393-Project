using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SearchMenuController : MonoBehaviour
{
    public ScreenReader ScreenReader;
    [Header("Options Stuff")]
    //public TMP_Dropdown resolutionDropdown;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public GameObject menu;
    public Button optionsButton;
    public Button resumeButton;
    public Button confirmButton;
    public Button quitButton;
    public Toggle fullscreenToggle;
    public bool pauseActive;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(resumeGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toPauseMenu);
        quitButton.onClick.AddListener(Quit);

        fullscreenToggle.onValueChanged.AddListener(delegate {
            SetFullScreen();
        });

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                resumeGame();
            }
            else
            {
                toPauseMenu();
                pauseActive = !pauseActive;
            }
        }
    }

    void toPauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        menu.SetActive(false);
    }

    void toOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void resumeGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        menu.SetActive(true);
        pauseActive = !pauseActive;
    }

    void Quit()
    {
        Application.Quit();
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}