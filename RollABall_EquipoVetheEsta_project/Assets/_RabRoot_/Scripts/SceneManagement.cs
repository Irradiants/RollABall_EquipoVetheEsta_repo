using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void LoadScene(int sceneLoad) 
    {
        SceneManager.LoadScene(sceneLoad);
    }

    public void ExitGame() 
    {
        Debug.Log("Has cerrado el juego");
        Application.Quit();
    }

}
