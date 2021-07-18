using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] int sceneBuildIndex;
    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Awake()
    {
        // if (sceneBuildIndex)
        sceneBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            LoadNextScene();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex > sceneBuildIndex)
        {
            if(logDebug) Debug.LogWarning("No more scenes!");
            return;
        }

        if(logDebug) Debug.Log("Loading Scene: " + SceneManager.GetSceneByBuildIndex(nextIndex).name);
        SceneManager.LoadScene(nextIndex);
    }
}
