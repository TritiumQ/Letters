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

    int blockType;                          //�������࣬0�Ƿۣ�1�ף�2��
    int formerType;                         //����ɫ���鸲�ǵ�����ԭ�ȷ������ɫ

    public GameObject[] blockArray;         //��������

    public BlockGameController controller;  //��BlockGameController���йҽ�
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
        this.transform.position = new Vector3(colIndex * 0.84f + Xoffset , rowIndex * 0.84f  + Yoffset , 0);
    }

    /// <summary>
    /// ���̵�����
    /// </summary>
    /// <param name="Ispink"></param>
    /// <param name="IsBlack"></param>
    public void RandomCreateBlocks(bool Ispink)
    {
        if (blocks != null) return;
        if(Ispink) blockType = 0;
        else blockType = 1;

        blocks = Instantiate(blockArray[blockType]) as GameObject;
        //blocks = Instantiate(blockArray[2]) as GameObject;          //����һ����ɫ����

        //Transform black = transform.Find("BlackBlocks(Clone)");     //������ɫ��������Ϊfalse
        //black.gameObject.SetActive(false);
        blocks.transform.parent = this.transform;
        
    }
    /// <summary>
    /// ���ڿ��ƺ�ɫ���������
    /// </summary>
    public void BlackBlockSpawn()
    {   
        blockType = 2;
        blocks = Instantiate(blockArray[2]) as GameObject;
        blocks.gameObject.SetActive(false);
        blocks.transform.parent = this.transform;
    }

    public void BlackBlockShow()
    {
        Transform black = transform.Find("BlackBlocks(Clone)");
        black.gameObject.SetActive(true);
    }


    public void OnMouseDown()                                           //���¼���ʱ���Ǻ�ɫ����Ľ���SetActiveΪfalse
    {
        
        //Debug.Log("block�� " + this.GetComponent<Blocks>().blockType);
        
        //Debug.Log("ԭ�����̸������ͣ�" + this.formerType);
        Transform black = transform.Find("BlackBlocks(Clone)");
        if(black != null && black.gameObject.activeSelf)                //�����ɫ����û�б���ʾ���»���ʾ�Ҳ�������
        {
            black.gameObject.SetActive(false);
            controller.ClickBlockNum++;                                 //�������++
            if(controller.curePercent < 100)
            {
                controller.curePercent += 5;
            }
            
        }
        else
        {
            if(controller.curePercent > 0)
            {
                controller.curePercent -= 5;
            }
            Debug.Log("�Ҳ�������");
        }
            
        //this.gameObject.SetActive(false);
            
            
        
        
    }
}
