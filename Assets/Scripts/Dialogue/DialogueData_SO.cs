using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ScriptObject�洢ÿһ�ζԻ�����Դ
[CreateAssetMenu(fileName = "New Dialogue", menuName = "SOAssets/Dialogue Data")]
public class DialogueData_SO : ScriptableObject
{
    public List<DialoguePiece> dialoguePieces = new List<DialoguePiece>();//һ�ξ���Ի������е����ı�
}
