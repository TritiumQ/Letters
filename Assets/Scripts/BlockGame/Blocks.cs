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

    public GameObject[] blockArray;         //方格数组
    //public int blocktype = 0;             //方格类型
    //public int blackprobability;            //黑块生成几率

    private GameObject blocks;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void RandomCreateBlocks(bool Ispink,bool IsBlack)
    {
        int blockType;

        if (blocks != null) return;
        if(Ispink) blockType = 0;
        else blockType = 1;

        if(IsBlack)
        {
            blockType = 2;
            
        }

        blocks = Instantiate(blockArray[blockType]) as GameObject;
        blocks.transform.parent = this.transform;
        
    }
}
