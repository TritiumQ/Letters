using Spine.Unity;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
	[SerializeField]
	AnimState CurrentState, PreviousState;
	bool facingLeft;

	public bool EnableAnim = true;

	public bool IsNPC;

	[SerializeField,Range(-1f, 1f)]
	float currentSpeed;

	public SkeletonGraphic skeleton;

	public string horizontalAxis = "Horizontal";

	public AnimationReferenceAsset run, idle, walk;

	public float currentHorizontal;

    private void Awake()
    {
        
    }

    private void Update()
	{
		if (skeleton == null) return;

		if(EnableAnim)
		{
			currentHorizontal = Input.GetAxisRaw(horizontalAxis);
			if (IsNPC)
			{
				currentHorizontal = -currentHorizontal;
			}
			TryMove(currentHorizontal);
		}

		if ((skeleton.Skeleton.ScaleX < 0) != facingLeft)
		{
			Turn();
		}

		if (PreviousState != CurrentState)
		{
			PlayNewStableAnimation();
		}
		PreviousState = CurrentState;

	}

	void PlayNewStableAnimation()
	{
		var newState = CurrentState;
		Spine.Animation nextAnimation;

		if (newState == AnimState.Walking)
		{
			nextAnimation = walk;
		}
		else if(newState == AnimState.Running)
		{
			nextAnimation = run;
		}
		else
		{
			nextAnimation = idle;
		}

		skeleton.AnimationState.SetAnimation(0, nextAnimation, true);
	}
	/// <summary>
	/// ×ªÏò
	/// </summary>
	void Turn()
	{
		if(!IsNPC)
        {
			skeleton.Skeleton.ScaleX = facingLeft ? -1f : 1f;
		}
		
	}

	void TryMove(float speed)
	{
		currentSpeed = speed; // show the "speed" in the Inspector.

		if (speed != 0)
		{
			bool speedIsNegative = (speed < 0f);
			facingLeft = speedIsNegative; // Change facing direction whenever speed is not 0.
		}

		CurrentState = (speed == 0) ? AnimState.Idle : AnimState.Walking;
	}
}

enum AnimState
{
	Walking,
	Running,
	Idle,
}