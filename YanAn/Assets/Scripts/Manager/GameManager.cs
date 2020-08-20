using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private XMLManager xMLManager;

    public static string NextScene;

    public XMLManager XMLManager
    {
        get
        {
            if (null == GetInstance.xMLManager)
            {
                GetInstance.xMLManager = new XMLManager();
            }
            return GetInstance.xMLManager;
        }
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene("加载等待");
        NextScene = scene;
    }

    private JsonManager jsonManager;

    public JsonManager JsonManager
    {
        get
        {
            if (null == GetInstance.jsonManager)
            {
                GetInstance.jsonManager = new JsonManager();
            }
            return GetInstance.jsonManager;
        }
    }

}
