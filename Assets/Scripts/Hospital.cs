using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    public Image BG;
    public DialogueData_SO DSO;
    private void Awake()
    {
        BG.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            BG.gameObject.SetActive(true);
            DialogueUI.Instance.UpdateDialogue(DSO);
            DialogueUI.Instance.UpdateMainDialogue(DSO.dialoguePieces[0]);
        }
    }


}
