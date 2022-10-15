using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;
    public int rowNum = 16;             //棋盘行数                
    public int colNum = 16;             //棋盘列数
    public ArrayList blockList;         //存格子的动态数组
    private bool Ispink;                //是否是粉格子


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //初始化

        for(int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            ArrayList temp = new ArrayList();

            for(int colIndex = 0; colIndex < colNum; colIndex++)
            {
                Blocks b = AddBlocks(rowIndex,colIndex);
                temp.Add(b);
            }

            blockList.Add(temp);        //一行的所有元素存进temp后再存进

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
