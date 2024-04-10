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
    Resolution[] resolutions;
    public bool pauseActive;
    // Start is called before the first frame update
    void Start()
    {
        //Add listener for when the value of the Dropdown changes, to take action
        /*
        resolutionDropdown.onValueChanged.AddListener(delegate {
            onResolutionChanged(resolutionDropdown);
        });
        */
        resumeButton.onClick.AddListener(resumeGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toPauseMenu);
        quitButton.onClick.AddListener(Quit);

        fullscreenToggle.onValueChanged.AddListener(delegate {
            SetFullScreen();
        });

        fullscreenToggle.isOn = Screen.fullScreen;
        /*
        resolutions = Screen.resolutions;
        resolutionDropdown.options = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));

            //set to be our default
            if (PlayerPrefs.GetInt("set default resolution") == 0)
            {
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    resolutionDropdown.value = i;
                    PlayerPrefs.SetInt("set default resolution", 1);
                    //ScreenReader.StaticReadText(resolutionDropdown.value.ToString());
                    //Debug.Log(resolutionDropdown.value.ToString());
                    Debug.Log("Hello There");
                    SetResolution();
                }
            }
        }
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution");
        */
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
    /*
    public void onResolutionChanged(TMP_Dropdown change)
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionDropdown.value);
    }
    */

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
    /*
    public void SetResolution()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        //ScreenReader.StaticReadText(resolutionDropdown.value.ToString());
        //Debug.Log(resolutionDropdown.value.ToString());
        PlayerPrefs.SetInt("resolution", resolutionDropdown.value);
    }
    */
    public void SetFullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}