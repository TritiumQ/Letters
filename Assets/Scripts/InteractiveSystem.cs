using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveSystem : MonoBehaviour
{
    [Header("是否允许交互")]
    public bool InvestgateFlag = true;

    GameObject InteractiveObject = null;

    [SerializeField, Header("交互指示")]
    TextMeshProUGUI Tips;

    private void Awake()
    {
		Tips.enabled = false;
    }

    private void Update()
    {
        if (InvestgateFlag && InteractiveObject != null) 
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("调查" + InteractiveObject.name);
            }
        }
        if(Tips == null)
        {
            Debug.Log("Tips已销毁");
        }
    }

    public void StartInteracting(GameObject obj)
    {
        if(obj != null && obj.GetComponent<InteractiveTrigger>() != null)
        {
            //Debug.Log("正在接触" + obj.name);
            InteractiveObject = obj;
            Tips.enabled = true;
		}
    }

	public void StopInteracting()
    {
        Tips.enabled = false;
		InteractiveObject = null;
	}
}
