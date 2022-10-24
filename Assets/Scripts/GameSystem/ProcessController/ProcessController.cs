using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessController : MonoBehaviour
{
    public static ProcessController Instance { get; private set; }

    public ProcessData data;
    public string CurrentSceneName;
    public string NextSceneName;
    public Scene scene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scene = SceneManager.GetActiveScene();
        CurrentSceneName = scene.name;
        //NextSceneName = data.sceneDatas.Find((SceneData sd) => { return sd.SceneName == CurrentSceneName; }).nextScene;

    }

    #region APIs

    public void GoNextScene()
    {

    }

    public string GetNextScene()
    {
        return null;
    }

     

	#endregion

	#region Utility
    public static ProcessData LoadProcessData()
    {
        ProcessData data = Resources.Load<ProcessData>("/ProcessData/MainPocess");
        return data;
    }
	#endregion

}
