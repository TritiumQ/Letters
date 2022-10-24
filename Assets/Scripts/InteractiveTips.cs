using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveTips : MonoBehaviour
{
    [SerializeField, Header("交互指示")]
    TextMeshProUGUI Tips;

    private void Awake()
    {
		Tips.enabled = false;
    }

	#region APIs
	public void StartInteracting(GameObject obj)
    {
        if(obj != null && obj.GetComponent<InteractiveTrigger>() != null)
        {
            //Debug.Log("正在接触" + obj.name);
            Tips.enabled = true;
		}
    }

	public void StopInteracting()
    {
        Tips.enabled = false;
	}
	#endregion

}
