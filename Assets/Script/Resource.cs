using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    //���� ������ ���� ��ũ��Ʈ�Դϴ�.

    public float endTime; //�������� ���� �ð�
    public bool indoor = true ; //���� ����� ������ ������


    public float rbMoveSpeed = 1.0f; //�κ� �⺻ �̵��ӵ�
    public float rbPower = 100.0f ; // �κ����� �⺻ �ִ� ����
    public float rbEfficiency = 10.0f; // �κ� �⺻ ȿ��
    public float rbCapacity = 40.0f; //�κ� �⺻ ���緮
    

    public float rbNextMoveSpeed = 1.0f; //���� �κ� �̵��ӵ�
    public float rbNextPower = 40.0f; //���� �κ� �ִ� ����
    public float rbNextEfficiency = 10.0f; // ���� �κ� ȿ��
    public float rbNextCapacity = 40.0f; // ���� �κ� ���緮
    public bool rbNextReady = true; //���� �κ� ���� �غ�

    public float spPower; //���ּ� ����
    public float maxSpPower; //���ּ� �ִ� ����
    public float spHp1; //���ּ� ������ ü��  
    public float spHp2; //���ּ� ���� ü��
    public float spHp3; //���ּ� ���� ü��
    public float spMaxHp;

    public float metal; //�ڿ� ����1 -ö
    public float plastic; //�ڿ� ����2 - �ö�ƽ
    public float uranium; //�ڿ� ����3 - ����

    // �ǽð� ���ҷ� ����

    public float spPoewrReduce = 1f;
    public float spHpRightReduce = 0.07f;
    public float spHpLeftReduce = 0.1f;
    public float spHpFrontReduce = 0.13f;

    public float endTimeReduce = 0.02f;

    public GameObject dark;
    // Start is called before the first frame update
    void Start()
    {
        dark.GetComponent<Image>().color = new Color32(255, 255, 255, 0); 
        // ���� ���ּ� ���� 
        spPower = maxSpPower;
        GameObject.Find("DepotShipBar").GetComponent<DepotShipBar>().SetHealth(spPower);
        // ó�� �κ� ����
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ʴ� ����
        spPower -= spPoewrReduce * Time.deltaTime;
        spHp1 -= spHpRightReduce * Time.deltaTime;
        spHp2 -= spHpLeftReduce * Time.deltaTime;
        spHp3 -= spHpFrontReduce * Time.deltaTime;
        endTime -= endTimeReduce * Time.deltaTime;

        if (spHp1 < 0 || spHp2 <0 || spHp3 < 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().BedEnding();
        }
        if (endTime < 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GoodEnding();
        }

        if(spPower < 50 )   // �þ� ����
        {
            if (spPower < 0)
                spPower = 0;
            float value = 255 - spPower;
            dark.GetComponent<Image>().color = new Color32(255, 255, 255, ((byte)value) > (byte)255 ? (byte)255 : ((byte)value));
        }
        else
        {
            dark.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        
    }
}
