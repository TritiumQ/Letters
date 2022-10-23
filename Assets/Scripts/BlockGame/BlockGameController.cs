using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;               //与每一格的Blocks脚本进行挂接

    [Header("BOARDSPAWN")]
    public int rowNum = 16;             //棋盘行数                
    public int colNum = 16;             //棋盘列数
    public int blackBlockRemain = 4;    //黑色格子生成剩余数
    public int blackBlockProbability;   //黑色格子生成几率
    public int Probability = 5;         //生成几率

    [Header("GAMECONTROL")]
    public int gameRound = 4;           //游戏轮数
    public int ClickBlockNum;           //目前已点方块数

    ArrayList blockList;                //存格子的动态数组

    private bool Ispink;                //是否是粉格子
    private bool IsEven;                //是否为偶数行


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //初始化

        

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

            blockList.Add(temp);        //一行的所有元素存进temp后再存进

        }

    }
    /// <summary>
    /// 棋盘生成
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <returns></returns>
    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        //棋盘生成
        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;

        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink);
        
        Ispink = !Ispink;

        BlackBlocksSpawn(_rowIndex, _colIndex, b);

        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);

        
        return b;
    }

    /// <summary>
    /// 黑色方块生成
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public Blocks BlackBlocksSpawn(int _rowIndex,int _colIndex,Blocks b)
    {
        //问题：因为生成概率低，有可能出现一个棋盘上生成少于4个黑色方块的情况
        Mathf.Clamp(blackBlockRemain, 0, 4);
        blackBlockProbability = Random.Range(0, 100);           //随机生成黑色方块概率
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
