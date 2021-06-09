using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject LoseMenu;
    public GameObject PauseMenu;
    public GameObject MenuButton;

    [Header("SettingsMenu")]
    public GameObject SettingsMenu;
    public GameObject SettingsButton;

    public void Pause() {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        MenuButton.SetActive(false);
        MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
    }

    public void Unpause() {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        MenuButton.SetActive(true);
        MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
    }

    public void Lose() {
        Time.timeScale = 0f;
        LoseMenu.SetActive(true);
        MenuButton.SetActive(false);
    }

    public void ShowSettingsMenu() {
        SettingsMenu.SetActive(true);
        SettingsButton.SetActive(false);
    }

    public void HideSettingsMenu() {
        SettingsMenu.SetActive(false);
        SettingsButton.SetActive(true);
    }

}
