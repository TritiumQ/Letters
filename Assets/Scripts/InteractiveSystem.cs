using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveSystem : MonoBehaviour
{
    [Header("�Ƿ�������")]
    public bool EnableIteraction = true;

    GameObject InteractiveObject = null;

    [SerializeField, Header("����ָʾ")]
    TextMeshProUGUI Tips;

    private void Awake()
    {
		Tips.enabled = false;
    }

    private void Update()
    {
        if (EnableIteraction && InteractiveObject != null) 
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("����" + InteractiveObject.name);
            }
        }
    }

    public void StartInteracting(GameObject obj)
    {
        if(obj != null && obj.GetComponent<InteractiveTrigger>() != null)
        {
            //Debug.Log("���ڽӴ�" + obj.name);
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
