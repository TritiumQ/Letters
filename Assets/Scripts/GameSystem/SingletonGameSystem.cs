using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameSystem : MonoBehaviour
{
    static SingletonGameSystem instance;
    public static SingletonGameSystem Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SingletonGameSystem>();
                if(instance == null)
                {
                    //GameObject go = new GameObject("GameSystem");
                    GameObject go = Resources.Load<GameObject>("Prefabs/GameSystem");
                    GameObject newOB = Instantiate(go);
					instance = newOB.GetComponent<SingletonGameSystem>();
                    DontDestroyOnLoad(newOB);
                }
            }
            return instance;
        }
    }

    #region 相关属性
    public bool IsPause;

	#endregion

	#region 各种管理器

	public OptionController optionSystem { get; private set; }
    public AudioController audioController { get; private set; }
    public ProcessController processController { get; private set; }

	#endregion

	private void Awake()
    {
        instance = this;
        optionSystem = OptionController.Instance;
        audioController = AudioController.Instance;
        processController = ProcessController.Instance;
		DontDestroyOnLoad(instance);

        audioController.UpdateVolume();

        IsPause = false;
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene().name != "MainMenu")
			{
                if(IsPause)
                {
                    Debug.Log("退出暂停菜单");
                    StopPause();
					optionSystem?.StopMenu();
				}
                else
                {
					Debug.Log("暂停菜单");
					StartPause();
					optionSystem?.StartMenu();
				}
			}
		}
	}

    public void StartPause()
    {
        Time.timeScale = 0;
        IsPause = true;
	}

    public void StopPause()
    {
		Time.timeScale = 1;
        IsPause = false;
	}
}
