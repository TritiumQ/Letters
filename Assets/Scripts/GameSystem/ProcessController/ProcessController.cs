using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessController : MonoBehaviour
{
    public ProcessData data;
    public string CurrentSceneName;
    public Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        CurrentSceneName = scene.name;
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
