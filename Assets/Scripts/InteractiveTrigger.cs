using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class InteractiveTrigger : MonoBehaviour
{
	InteractiveSystem system;

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
			//Debug.Log("Exit");
			system.StopInteracting();
		}
	}

}
