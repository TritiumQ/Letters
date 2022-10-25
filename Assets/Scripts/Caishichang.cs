using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caishichang : MonoBehaviour
{
    public Button b1, b2, b3;
    // Start is called before the first frame update
    private void Awake()
    {


        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            b1.gameObject.SetActive(true);
            b2.gameObject.SetActive(true);
            b3.gameObject.SetActive(true);
        }
    }


}