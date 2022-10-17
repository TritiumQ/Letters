using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveSystem : MonoBehaviour
{
    [Header("是否允许交互")]
    public bool InvestgateFlag = true;

    [SerializeField,Header("可交互物品列表")]
    List<GameObject> InteractiveObjects;

    [SerializeField,Header("交互主体")]
    GameObject Character;

    [SerializeField,Header("交互指示")]
    TextMeshProUGUI Tips;

    private void Update()
    {
        
    }

    private void Check()
    {
        
    }

}
