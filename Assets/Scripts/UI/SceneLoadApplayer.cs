using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadApplayer : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
