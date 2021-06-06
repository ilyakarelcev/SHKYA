using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject LoseMenu;
    public GameObject PauseMenu;
    public GameObject MenuButton;

    public void Pause() {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        MenuButton.SetActive(false);
    }

    public void Unpause() {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        MenuButton.SetActive(true);
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lose() {
        Time.timeScale = 0f;
        LoseMenu.SetActive(true);
        MenuButton.SetActive(false);
    }

}
