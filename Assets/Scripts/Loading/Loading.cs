using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    static string nextScene;

    [SerializeField] private float posY;

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (op.progress >= 0.9f)
            {
                posY = Mathf.Lerp(posY, 3.5f, timer);
                if (posY >= 3.4f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            else
            {
                posY = Mathf.Lerp(posY, 3.0f, timer);
                if (posY >= 2.9f)
                    timer = 0f;
            }
        }
    }

    void Update()
    {
        transform.position = new Vector3(0, posY, 0);
    }
}
