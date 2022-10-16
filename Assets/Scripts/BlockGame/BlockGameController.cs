using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;               //��ÿһ���Blocks�ű����йҽ�

    public int rowNum = 16;             //��������                
    public int colNum = 16;             //��������
    public int blackBlockRemain = 4;    //��ɫ����ʣ����
    public int blackBlockProbability;   //��ɫ�������ɼ���

    public ArrayList blockList;         //����ӵĶ�̬����

    private bool Ispink;                //�Ƿ��Ƿ۸���
    private bool IsEven;                //�Ƿ�Ϊż����
    private bool IsBlack;               //�Ƿ����ɺ�ɫ����


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //��ʼ��


        for(int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            ArrayList temp = new ArrayList();
            if (rowIndex % 2 == 0) Ispink = true;
            else Ispink = false;

            for (int colIndex = 0; colIndex < colNum; colIndex++)
            {
                
                Blocks b = AddBlocks(rowIndex,colIndex);
                temp.Add(b);
                Debug.Log(rowIndex + " " + colIndex + " ");
            }

            blockList.Add(temp);        //һ�е�����Ԫ�ش��temp���ٴ��

        }

    }

    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        //
        Mathf.Clamp(blackBlockRemain, 0, 4);

        blackBlockProbability = Random.Range(0, 100);
        if(blackBlockRemain > 0 && blackBlockProbability < 2)
        {
            IsBlack = true;
            blackBlockRemain--;

        }
        else IsBlack = false;

        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;

        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink,IsBlack);
        
        Ispink = !Ispink;
        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);
        return b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
