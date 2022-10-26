using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End15 : MonoBehaviour
{
    public Image BG2, BG3;
    public DialogueData_SO DS1, DS2, DS3;
    private bool flag = false,endf=false;
    private void Awake()
    {
        BG2.gameObject.SetActive(false);
        BG3.gameObject.SetActive(false);
        DialogueUI.Instance.UpdateDialogue(DS1);
        DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag && !flag && !endf)
        {
            BG2.gameObject.SetActive(true);
            DialogueUI.Instance.UpdateDialogue(DS2);
            DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
            flag = true;
        }
        else if(DialogueUI.Instance.endFlag && flag && !endf)
        {
            BG3.gameObject.SetActive(true);
            DialogueUI.Instance.UpdateDialogue(DS3);
            DialogueUI.Instance.UpdateMainDialogue(DS3.dialoguePieces[0]);
            flag = false;
            endf = true;
        }
        else
        {
            //TODO 结束
        }
    }
}
