using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveTrigger : MonoBehaviour
{
	InteractiveSystem system;

	public bool EnableGlow;

	[SerializeField]
	Image thisImage;

	private void Awake()
	{
		system = GameObject.Find("InteractiveSystem").GetComponent<InteractiveSystem>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (system != null)
		{
			//Debug.Log("Stay");
			system.StartInteracting(gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (system != null)
		{
			Debug.Log("Exit");
			system.StopInteracting();
		}
	}
}
