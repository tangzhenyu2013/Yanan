using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private XMLManager xMLManager;

    public static string NextScene;

    public static XMLManager XMLManager
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
}
