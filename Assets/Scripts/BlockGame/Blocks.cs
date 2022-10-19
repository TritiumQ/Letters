using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    //x��ƫ��ֵ
    public float Xoffset;
    //y��ƫ��ֵ
    public float Yoffset;

    public int rowIndex = 0;
    public int colIndex = 0;

    int blockType;

    public GameObject[] blockArray;         //��������

    public BlockGameController controller;  //��BlockGameController���йҽ�

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

    public void RandomCreateBlocks(bool Ispink,bool IsBlack)
    {
        

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

    public void OnMouseDown()                   //���¼���ʱ���Ǻ�ɫ����Ľ���Destory
    {
        //Debug.Log("row " + this.rowIndex + " col " + this.colIndex);
        Debug.Log("block�� " + this.GetComponent<Blocks>().blockType);
        if (this.GetComponent<Blocks>().blockType == 2)
        {
            controller.Erase(this);
        }
        
    }
}
