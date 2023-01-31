using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        Debug.Log("Play Game");

        SceneManager.LoadScene("Platformer");
    }

    public void Settings() {
        Debug.Log("Settings");
    }
}
