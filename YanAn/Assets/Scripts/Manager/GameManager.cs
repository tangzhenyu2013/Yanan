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

    private UIPanelManager uIPanelManager;

    public UIPanelManager UIPanelManager
    {
        get
        {
            if (null == GetInstance.uIPanelManager)
            {
                GetInstance.uIPanelManager = new UIPanelManager();
            }
            return GetInstance.uIPanelManager;
        }
    }

    private AssessmentManager assessmentManager;

    public AssessmentManager AssessmentManager
    {
        get
        {
            if (null == GetInstance.assessmentManager)
            {
                GetInstance.assessmentManager = new AssessmentManager();
            }
            return GetInstance.assessmentManager;
        }
    }

    public static void LoadScene(string scene)
    {
        GetInstance.UIPanelManager.Reset();
        NextScene = scene;
        SceneManager.LoadScene("加载等待");
    }
}
