using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnClickButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
