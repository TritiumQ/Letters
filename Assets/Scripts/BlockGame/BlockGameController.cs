using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;               //与每一格的Blocks脚本进行挂接

    [Header("BOARDSPAWN")]
    public int rowNum = 16;             //棋盘行数                
    public int colNum = 16;             //棋盘列数
    public int blackBlockRemain = 4;    //黑色格子剩余数
    public int blackBlockProbability;   //黑色格子生成几率
    public int Probability = 5;         //生成几率

    [Header("GAMECONTROL")]
    public int gameRound = 5;           //游戏轮数
    public int ClickBlockNum;           //目前已点方块数


    ArrayList blockList;                //存格子的动态数组

    private bool Ispink;                //是否是粉格子
    private bool IsEven;                //是否为偶数行
    private bool IsBlack;               //是否生成黑色格子


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
                //Debug.Log(rowIndex + " " + colIndex + " ");
            }

            blockList.Add(temp);        //一行的所有元素存进temp后再存进

        }

    }

    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        //问题：因为生成概率低，有可能出现一个棋盘上生成少于4个的情况
        Mathf.Clamp(blackBlockRemain, 0, 4);

        blackBlockProbability = Random.Range(0, 100);           //随机生成黑色方块概率
        if(blackBlockRemain > 0 && blackBlockProbability < Probability)
        {
            if (rowNum - _rowIndex == 5) Probability = 20;
            IsBlack = true;
            blackBlockRemain--;
            Debug.Log(blackBlockRemain);
        }
        else IsBlack = false;

        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;

        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink,IsBlack);
        
        Ispink = !Ispink;
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
        
    }


}
