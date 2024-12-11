using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Bu fonksiyonu Unity'deki Button ile bağlayarak sahne geçişi yapabilirsiniz.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
