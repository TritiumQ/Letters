using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoController : MonoBehaviour
{
    MoveAndAnimationController controller;

    private void Awake()
    {
        controller = GetComponent<MoveAndAnimationController>();
        if(controller != null)
        {
            controller.EnableAnim = false;
            controller.EnableMove = false;
            controller.EnableRun = false;
        }
    }

    private void Update()
    {
        
    }



}
