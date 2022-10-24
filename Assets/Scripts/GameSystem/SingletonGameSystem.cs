using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	#region 各种管理器

    public OptionController optionSystem { get; private set; }
    public AudioController audioController { get; private set; }
    public ProcessController processController { get; private set; }

	#endregion

	private void Awake()
    {
        instance = this;
        optionSystem = GetComponent<OptionController>();
        audioController = GetComponent<AudioController>();
        processController = GetComponent<ProcessController>();
		DontDestroyOnLoad(instance);

	}
}
