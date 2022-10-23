using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public bool EnableMove = true;
	[Range(1f, 100f)]
	public float MoveSpeed = 20f;
	public bool EnableRun = true;
	[Range(1f, 5f)]
	public const float RunRate = 1.5f;

	public string HorizontalAxis = "Horizontal";

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		if (EnableMove)
		{
			float input = Input.GetAxisRaw(HorizontalAxis);
			if (input != 0f)
			{
				if (input < 0f)
				{
					float left = -MoveSpeed * Time.deltaTime * 3;
					if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
					{
						left *= RunRate;
					}
					gameObject.transform.Translate(left, 0, 0);
				}
				if (input > 0f)
				{
					float right = MoveSpeed * Time.deltaTime * 3;
					if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
					{
						right *= RunRate;
					}
					gameObject.transform.Translate(right, 0, 0);
				}
			}
		}
	}
}
