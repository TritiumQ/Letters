using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveSystem : MonoBehaviour
{
    [Header("�Ƿ�������")]
    public bool InvestgateFlag = true;

    GameObject InteractiveObject = null;

    [SerializeField, Header("����ָʾ")]
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
                Debug.Log("����" + InteractiveObject.name);
            }
        }
        if(Tips == null)
        {
            Debug.Log("Tips������");
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
