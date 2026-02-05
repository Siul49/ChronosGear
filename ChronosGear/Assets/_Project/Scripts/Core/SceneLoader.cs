using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    
    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeDuration = 0.5f;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }
    
    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        // Don't try to fade if canvas is missing
        if (fadeCanvas != null)
            yield return StartCoroutine(Fade(1f));
        
        var async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
            yield return null;
        
        if (fadeCanvas != null)
            yield return StartCoroutine(Fade(0f));
    }
    
    private IEnumerator Fade(float target)
    {
        float start = fadeCanvas.alpha;
        float elapsed = 0f;
        
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            fadeCanvas.alpha = Mathf.Lerp(start, target, elapsed / fadeDuration);
            yield return null;
        }
        
        fadeCanvas.alpha = target;
    }
}
