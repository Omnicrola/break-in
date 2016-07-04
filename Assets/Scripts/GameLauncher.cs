using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{

    public void LaunchGame()
    {
        SceneManager.LoadScene("GameScene");

    }
}
