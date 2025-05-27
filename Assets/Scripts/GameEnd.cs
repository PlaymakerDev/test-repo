using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static GameEnd instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject btnObj = GameObject.Find("Quit");
        GameObject retryObj = GameObject.Find("Retry");

        if (btnObj != null)
        {
            Button btn = btnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(LoadTitleScene);
            }
        }

        if (retryObj != null)
        {
            Button btn = retryObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(LoadNewScene);
            }
        }
    }

    // Update is called once per frame
    public void LoadTitleScene()
    {
        if (!string.IsNullOrEmpty("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LoadNewScene()
    {
        if (!string.IsNullOrEmpty("Gameplay"))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

}
