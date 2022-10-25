using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO currentData;

    private bool canTalk = false;

    [SerializeField]
    private bool isInteract;//�Ƿ�Ϊ���������Ի����������������ײ�������Զ������Ի���

    private bool isTrigger; //�Ƿ�Ϊ��Ҫ���������ɶԻ����������ڽ��볡����ֱ�ӽ��е��ã�

    private void Update()
    {
        if (canTalk && !isInteract)
        {
            OpenDialogue();
            canTalk = false;
        }

        if (canTalk && isInteract && Input.GetKeyDown(KeyCode.E))
        {
            OpenDialogue();
        }
    }

    public void OpenDialogue()
    {
        //InputDeviceDetection.GameplayUIController.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
        DialogueUI.Instance.UpdateDialogue(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }

    //void OnButtonClick()
    //{
    //    DialogueUI.Instance.UpdateDialogue(currentData);
    //    DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
        }
    }
}
