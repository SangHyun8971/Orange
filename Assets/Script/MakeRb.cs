using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeRb : MonoBehaviour
{
    public bool canMakeRb = true;

    public Resource resource;
    public int Level; //���ǵ� ���� 1~5

    public Text text;
    

    public float makeCost; // ����µ� ���� ���
    /**
      �κ� ���� ��� �� �⺻ 20 + (��� ���� �� -4) * 5 
    **/
    public float[] speed = {1.0f , 1.2f ,1.45f , 1.7f , 2.0f};
    public float[] power = { 100f, 120f, 140f, 160f, 180f };
    public float[] effect = { 20f, 25f, 33f, 45f, 70f };
    public float[] capacity = { 40f, 55f, 70f, 85f, 100f };
    
    // Start is called before the first frame update
    void Start()
    {
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
    }

    public void setText()
    {
        text.text = Level.ToString() + " LV\n" +
            makeCost.ToString()+"Cost";
    }
    public void Upgrade()
    {
        Level += 1;
        if (Level >= 6) Level = 1;
        getRbCost();
    }

    // Update is called once per frame
    void getRbCost() //�ڽ�Ʈ �����
    {
        makeCost =  (Level)*20; 
    }
    public void MakeRobot()
    {
        if(canMakeRb == false)
        {
            Debug.Log("�̹� ������� �κ��� �����մϴ�.");
        }
        else if (makeCost > resource.plastic)
        {
            Debug.Log("�κ��� ���� ��ᰡ �����մϴ�.");
        }
        else
        {
            resource.plastic -= makeCost;
            resource.rbNextMoveSpeed = speed[Level - 1];
            resource.rbNextPower = power[Level - 1];
            resource.rbNextEfficiency = effect[Level - 1];
            resource.rbCapacity = capacity[Level - 1];
            resource.rbNextReady = true;
            canMakeRb = false;
            Debug.Log("Interact RobotManufacturing");
        }
    }
}
