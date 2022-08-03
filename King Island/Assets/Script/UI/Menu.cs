using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    public GameObject _islands;
    public GameObject _island1Buttons;
    public GameObject _island2Buttons;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadmainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoIslandRight()
    {
        _islands.transform.DOMove(new Vector3(0, 0, 0),.25f);
    }

    public void GoIslandLeft()
    {
        _islands.transform.DOMove(new Vector3(-46.8f, 0, 0),.25f);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
