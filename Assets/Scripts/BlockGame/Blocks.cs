using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    //x轴偏离值
    public float Xoffset;
    //y轴偏离值
    public float Yoffset;

    public int rowIndex = 0;
    public int colIndex = 0;

    int blockType;                          //方格种类，0是粉，1白，2黑
    int formerType;                         //被黑色方块覆盖的棋盘原先方格的颜色

    public GameObject[] blockArray;         //方格数组

    public BlockGameController controller;  //与BlockGameController进行挂接
    private GameObject[] blackBlock;

    private GameObject blocks;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<BlockGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePosition(int _rowIndex,int _colIndex)
    {
        rowIndex = _rowIndex;
        colIndex = _colIndex;
        this.transform.position = new Vector3(colIndex + Xoffset , rowIndex + Yoffset , 0);
    }

    /// <summary>
    /// 棋盘的生成
    /// </summary>
    /// <param name="Ispink"></param>
    /// <param name="IsBlack"></param>
    public void RandomCreateBlocks(bool Ispink)
    {
        if (blocks != null) return;
        if(Ispink) blockType = 0;
        else blockType = 1;

        blocks = Instantiate(blockArray[blockType]) as GameObject;
        blocks.transform.parent = this.transform;
        
    }
    /// <summary>
    /// 用于控制黑色方块的生成以及消除后随机变换位置
    /// </summary>
    public void BlackBlockController()
    {
        blockType = 2;
        blocks = Instantiate(blockArray[2]) as GameObject;
        blocks.transform.parent = this.transform;
    }

    //设想：利用黑色方块的setActive来控制生成，初始生成棋盘是的每一个blocks下会有一个棋盘底色块和一个设置为false的黑色方块

    public void OnMouseDown()                   //按下键盘时将是黑色方块的进行Destory
    {
        
        Debug.Log("block： " + this.GetComponent<Blocks>().blockType);
        
        Debug.Log("原先棋盘格子类型：" + this.formerType);
        Transform black = transform.Find("BlackBlocks(Clone)");
        if(black != null)
        {
            black.gameObject.SetActive(false);
            controller.ClickBlockNum++;         //点击方块++
        }
        else
        {
            Debug.Log("找不到对象");
        }
            
        //this.gameObject.SetActive(false);
            
            
        
        
    }
}
