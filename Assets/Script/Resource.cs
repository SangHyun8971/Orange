using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    //변수 관리를 위한 스크립트입니다.

    public float endTime; //엔딩까지 남은 시간
    public bool indoor = true ; //현재 배경이 안인지 밖인지


    public float rbMoveSpeed = 1.0f; //로봇 기본 이동속도
    public float rbPower = 100.0f ; // 로봇전력 기본 최대 전력
    public float rbEfficiency = 10.0f; // 로봇 기본 효율
    public float rbCapacity = 40.0f; //로봇 기본 적재량
    

    public float rbNextMoveSpeed = 1.0f; //다음 로봇 이동속도
    public float rbNextPower = 40.0f; //다음 로봇 최대 전력
    public float rbNextEfficiency = 10.0f; // 다음 로봇 효율
    public float rbNextCapacity = 40.0f; // 다음 로봇 적재량
    public bool rbNextReady = true; //다음 로봇 생성 준비

    public float spPower; //우주선 전력
    public float maxSpPower; //우주선 최대 전력
    public float spHp1; //우주선 오른쪽 체력  
    public float spHp2; //우주선 왼쪽 체력
    public float spHp3; //우주선 앞쪽 체력
    public float spMaxHp;

    public float metal; //자원 종류1 -철
    public float plastic; //자원 종류2 - 플라스틱
    public float uranium; //자원 종류3 - 전력

    // 실시간 감소량 변수

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
        // 시작 우주선 전력 
        spPower = maxSpPower;
        GameObject.Find("DepotShipBar").GetComponent<DepotShipBar>().SetHealth(spPower);
        // 처음 로봇 세팅
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //초당 감소
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

        if(spPower < 50 )   // 시야 암전
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
