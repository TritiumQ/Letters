using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    public bool MoveFlag = true;
    public float MoveSpeed = 100f;
    public bool RunFlag = true;
	public float RunRate = 1.5f;
	public bool EnableAnimation = false;

	SkeletonGraphic SG;

	private void Awake()
	{
		if(EnableAnimation)
		{
			SG = gameObject.GetComponent<SkeletonGraphic>();
		}
	}

	private void Update()
    {
		Move();
    }

    private void Move()
    {
		if (MoveFlag)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				float left = -MoveSpeed * Time.deltaTime * 10;
				if (Input.GetKey(KeyCode.LeftShift) && RunFlag)
				{
					left *= RunRate;
				}
				gameObject.transform.Translate(left, 0, 0);
				if(EnableAnimation)
				{
					SG.AnimationState.SetAnimation(0, "ZL", true);
				}
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				float right = MoveSpeed * Time.deltaTime * 10;
				if (Input.GetKey(KeyCode.LeftShift) && RunFlag)
				{
					right *= RunRate;
				}
				gameObject.transform.Translate(right, 0, 0);
				if (EnableAnimation)
				{
					SG.AnimationState.SetAnimation(0, "ZL", true);
				}
			}
			if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
			{
				if (EnableAnimation)
				{
					SG.AnimationState.SetAnimation(0, "animation", true);
				}
			}
		}
	}


}
