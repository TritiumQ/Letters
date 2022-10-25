using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    public bool endFlag = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private DialogueData_SO currentData;//��ǰ�Ի�����
    private int currentIndex;//�Ի����

    [SerializeField]
    private Canvas dialogueCanvas;
    private bool canContinue;

    [Header("===== Dialogue Basic Element =====")]
    [SerializeField]
    private Image standA;//�������
    [SerializeField]
    private Image standB;//Npc����
    [SerializeField]
    private Text speakerName;//˵��������
    [SerializeField]
    private Text mainText;//�Ի��ı�

    private void Update()
    {
        endFlag = false;
        if (canContinue && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < currentData.dialoguePieces.Count)
            {
                UpdateMainDialogue(currentData.dialoguePieces[currentIndex]);
            }
            else
            {
                canContinue = false;
                dialogueCanvas.enabled = false;
                endFlag = true;
            }
        }
    }

    public void UpdateDialogue(DialogueData_SO data)//�˺���Ϊÿ�ο����Ի��ĵ�һ��ˢ��
    {
        currentData = data;
        currentIndex = 0;
    }
    public void UpdateMainDialogue(DialoguePiece piece)//�˺���Ϊÿ�μ����Ի�ʱ������һ������
    {
        canContinue = true;
        dialogueCanvas.enabled = true;
        standA.enabled = false;
        standB.enabled = false;

        if (!piece.isNpc)
        {
            standA.enabled = true;
            standA.sprite = piece.image;
        }
        else if (piece.isNpc)
        {
            standB.enabled = true;
            standB.sprite = piece.image;
        }

        mainText.text = "";
        speakerName.text = "";
        speakerName.text = piece.speakerName;
        mainText.text = piece.text;

        if (currentData.dialoguePieces.Count > 0)
        {
            currentIndex++;
        }
    }
}
