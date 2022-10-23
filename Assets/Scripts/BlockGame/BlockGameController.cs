using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;               //��ÿһ���Blocks�ű����йҽ�

    [Header("BOARDSPAWN")]
    public int rowNum = 16;             //��������                
    public int colNum = 16;             //��������
    public int blackBlockRemain = 4;    //��ɫ��������ʣ����
    public int blackBlockProbability;   //��ɫ�������ɼ���
    public int Probability = 5;         //���ɼ���

    [Header("GAMECONTROL")]
    public int gameRound = 4;           //��Ϸ����
    public int ClickBlockNum;           //Ŀǰ�ѵ㷽����

    ArrayList blockList;                //����ӵĶ�̬����

    private bool Ispink;                //�Ƿ��Ƿ۸���
    private bool IsEven;                //�Ƿ�Ϊż����


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
                
            }

            blockList.Add(temp);        //һ�е�����Ԫ�ش��temp���ٴ��

        }

    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <returns></returns>
    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        //��������
        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;

        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink);
        
        Ispink = !Ispink;

        BlackBlocksSpawn(_rowIndex, _colIndex, b);

        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);

        
        return b;
    }

    /// <summary>
    /// ��ɫ��������
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public Blocks BlackBlocksSpawn(int _rowIndex,int _colIndex,Blocks b)
    {
        //���⣺��Ϊ���ɸ��ʵͣ��п��ܳ���һ����������������4����ɫ��������
        Mathf.Clamp(blackBlockRemain, 0, 4);
        blackBlockProbability = Random.Range(0, 100);           //������ɺ�ɫ�������
        if (blackBlockRemain > 0 && blackBlockProbability < Probability)
        {
            if (rowNum - _rowIndex == 5) Probability = 20;
            b.GetComponent<Blocks>().BlackBlockController();
            //b.GetComponent<Blocks>().UpdatePosition(_rowIndex,_colIndex);
            blackBlockRemain--;
            Debug.Log(blackBlockRemain);
        }

        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);


        return b;
    }

    public void Erase(Blocks b)
    {
        Destroy(b.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickBlockNum == 4)
        {
            ClickBlockNum = 0;
            blackBlockRemain = 4;
            for (int rowIndex = 0; rowIndex < rowNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colNum; colIndex++)
                {
                    Blocks b = Instantiate(blocks) as Blocks;
                    BlackBlocksSpawn(rowIndex, colIndex, b);
                }
            }

        }
    }


}
