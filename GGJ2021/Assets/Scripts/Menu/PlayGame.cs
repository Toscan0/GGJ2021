using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private string SceneName;

    public void Play() 
    {
        if (string.IsNullOrWhiteSpace(SceneName)) 
        {
            throw new UnityException("Missing: SceneName");
        }

        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
