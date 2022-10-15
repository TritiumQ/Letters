using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;
    public int rowNum = 16;             //��������                
    public int colNum = 16;             //��������
    public ArrayList blockList;         //����ӵĶ�̬����
    private bool Ispink;                //�Ƿ��Ƿ۸���


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //��ʼ��

        for(int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            ArrayList temp = new ArrayList();

            for(int colIndex = 0; colIndex < colNum; colIndex++)
            {
                Blocks b = AddBlocks(rowIndex,colIndex);
                temp.Add(b);
            }

            blockList.Add(temp);        //һ�е�����Ԫ�ش��temp���ٴ��

        }

    }

    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        
        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;
        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink);
        Ispink = !Ispink;
        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);
        return b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
