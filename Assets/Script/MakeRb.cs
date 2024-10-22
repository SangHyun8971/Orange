using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeRb : MonoBehaviour
{
    public bool canMakeRb = true;

    public Resource resource;
    public int Level; //스피드 레벨 1~5

    public Text text;
    

    public float makeCost; // 만드는데 들어가는 비용
    /**
      로봇 생산 계산 식 기본 20 + (모든 레벨 합 -4) * 5 
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
    void getRbCost() //코스트 만들기
    {
        makeCost =  (Level)*20; 
    }
    public void MakeRobot()
    {
        if(canMakeRb == false)
        {
            Debug.Log("이미 만들어진 로봇이 존재합니다.");
        }
        else if (makeCost > resource.plastic)
        {
            Debug.Log("로봇을 만들 재료가 부족합니다.");
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
