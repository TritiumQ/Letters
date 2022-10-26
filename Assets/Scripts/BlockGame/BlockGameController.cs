using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int curePercent = 0;      //���ƽ��Ȱٷֱ�
    public int ClickBlockNum;           //Ŀǰ�ѵ㷽����
    public TMP_Text cureProcess;        //���ƽ���

    ArrayList blockList;                //����ӵĶ�̬����
    Blocks[] BlocksStorge;

    private bool Ispink;                //�Ƿ��Ƿ۸���


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //��ʼ��
        BlocksStorge = new Blocks[rowNum * colNum];
        
        int i = 0;

        for(int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            
            ArrayList temp = new ArrayList();
            if (rowIndex % 2 == 0) Ispink = true;
            else Ispink = false;

            for (int colIndex = 0; colIndex < colNum; colIndex++)
            {
                
                Blocks b = AddBlocks(rowIndex,colIndex);
                BlocksStorge[i] = b;
                Debug.Log("��" + i + "��Ԫ���Ѿ�����BlocksStorge");
                temp.Add(b);
                i++;
                
            }
            
            blockList.Add(temp);        //һ�е�����Ԫ�ش��temp���ٴ��

        }
        Debug.Log("ĿǰBlocksStorge���Ԫ�ظ���Ϊ" + BlocksStorge.Length);

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

        b.GetComponent<Blocks>().BlackBlockSpawn();             //�Ȱ����еĺ�ɫ��������

        RandomAddBlackBlocks(_rowIndex, _colIndex,b);

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
    public void RandomAddBlackBlocks(int _rowIndex,int _colIndex,Blocks b)
    {
        //���⣺��Ϊ���ɸ��ʵͣ��п��ܳ���һ����������������4����ɫ��������
        Mathf.Clamp(blackBlockRemain, 0, 4);
        blackBlockProbability = Random.Range(0, 100);           //������ɺ�ɫ�������
        if (blackBlockRemain > 0 && blackBlockProbability < Probability)
        {
            if (rowNum - _rowIndex == 5) Probability = 20;
            //b.GetComponent<Blocks>().BlackBlockController();
            //b.GetComponent<Blocks>().UpdatePosition(_rowIndex,_colIndex);
            b.GetComponent<Blocks>().BlackBlockShow();
            blackBlockRemain--;
            Debug.Log(blackBlockRemain);
        }

        //b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);

    }

    public void Erase(Blocks b)
    {
        Destroy(b.gameObject);
    }

    // Update is called once per frame
    // ���⣺�����޷���ȡԭ�����ɵ�blocks(Clone)��ķ�����Ϣ����ÿһ���ĸ�����֮���������Instantiateһ�����̵���
    // �ڰ������֮��controller��ȡ������ɫ��������޷�ɾ��
    void Update()
    {
        Mathf.Clamp(curePercent, 0, 100);
        if (ClickBlockNum == 4)
        {
            ClickBlockNum = 0;
            blackBlockRemain = 4;
            
            for(int i = 0;i < BlocksStorge.Length;i++)
            {
                Blocks b = BlocksStorge[i];
                if(b != null)
                {
                    RandomAddBlackBlocks(b.GetComponent<Blocks>().rowIndex, b.GetComponent<Blocks>().colIndex, b);
                }
                else
                {
                    Debug.LogError("BlocksStorge" + i + "�Ҳ�������");
                }
                
                
            }

        }
        cureProcess.text = curePercent.ToString();

        if(curePercent == 100)
        {
            ProcessController.Instance.GoNextScene();
        }
    }


}
