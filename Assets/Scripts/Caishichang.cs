using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caishichang : MonoBehaviour
{
    public Button b1, b2, b3;
    public Button b4, b5, b6;
    public bool IsClicked = false;
    public DialogueData_SO DS1,DS2;
    private int num = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
        b4?.gameObject.SetActive(false);
        b5?.gameObject.SetActive(false);
        b6?.gameObject.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueUI.Instance.endFlag)
        {
            if(IsClicked)
            {
                num++;
                IsClicked = false;
            }

            switch(num)
            {
                case 1:
                    b1.gameObject.SetActive(true);
                    b2.gameObject.SetActive(true);
                    b3.gameObject.SetActive(true);
                    break;
                case 2:
                    DialogueUI.Instance.UpdateDialogue(DS1);
                    DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);
                    num++;
                    break;
                case 3:
                    b4.gameObject.SetActive(true);
                    b5.gameObject.SetActive(true);
                    b6.gameObject.SetActive(true);
                    break;
                case 4:
                    DialogueUI.Instance.UpdateDialogue(DS2);
                    DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
                    num++;
                    break;
                case 5:

                    break;
            }
        }

        
    }

    public void ButtonOnclick()
    {
        IsClicked = true;
        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
        b4.gameObject.SetActive(false);
        b5.gameObject.SetActive(false);
        b6.gameObject.SetActive(false);

        
    }

}