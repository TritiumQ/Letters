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
        this.transform.position = new Vector3(colIndex + Xoffset , rowIndex + Yoffset , 0);
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
        blocks.transform.parent = this.transform;
        
    }
    /// <summary>
    /// ���ڿ��ƺ�ɫ����������Լ�����������任λ��
    /// </summary>
    public void BlackBlockController()
    {
        blockType = 2;
        blocks = Instantiate(blockArray[2]) as GameObject;
        blocks.transform.parent = this.transform;
    }

    //���룺���ú�ɫ�����setActive���������ɣ���ʼ���������ǵ�ÿһ��blocks�»���һ�����̵�ɫ���һ������Ϊfalse�ĺ�ɫ����

    public void OnMouseDown()                   //���¼���ʱ���Ǻ�ɫ����Ľ���Destory
    {
        
        Debug.Log("block�� " + this.GetComponent<Blocks>().blockType);
        
        Debug.Log("ԭ�����̸������ͣ�" + this.formerType);
        Transform black = transform.Find("BlackBlocks(Clone)");
        if(black != null)
        {
            black.gameObject.SetActive(false);
            controller.ClickBlockNum++;         //�������++
        }
        else
        {
            Debug.Log("�Ҳ�������");
        }
            
        //this.gameObject.SetActive(false);
            
            
        
        
    }
}
