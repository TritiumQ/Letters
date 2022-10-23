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
                    GameObject go = new GameObject("GameSystem");
                    instance = go.AddComponent<SingletonGameSystem>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

	#region 各种管理器

    OptionSystem optionSystem;

    AudioController audioController;

	#endregion

	private void Awake()
    {
        instance = this;
        optionSystem = gameObject.AddComponent<OptionSystem>();
        audioController = gameObject.AddComponent<AudioController>();
		DontDestroyOnLoad(instance);
	}
}
