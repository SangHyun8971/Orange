using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임의 시작 정지, 재시작을 관리하는 스크립트입니다.
    public GameObject DeathImage;
    public Resource resource;
    public GameObject newrB;

    public ResourceGenerator generator;

    public int rbCode = 0; // 지금까지 만든 로봇 수


    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.Find("MiningTilemap")?.GetComponent<ResourceGenerator>();
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
    }

    private void FixedUpdate()
    {
        
    }
    public void StopGame() // 게임 일시정지
    {
        GameObject.FindWithTag("Player").GetComponent<RbMove>().canMove = false;

        resource.spPoewrReduce = 0;
        resource.spHpRightReduce = 0;
        resource.spHpLeftReduce = 0;
        resource.spHpFrontReduce = 0;
    }

    public void RbDeathStop() //로봇 죽음
    {
        
        DeathImage.SetActive(true);
        
        resource.spPoewrReduce = 0;
        resource.spHpRightReduce = 0;
        resource.spHpLeftReduce = 0;
        resource.spHpFrontReduce = 0;
        resource.endTimeReduce = 0f;

        if (resource.rbNextReady == false)
        {
            BedEnding();
        }
        if (resource.endTime <= 0)
        {
            GoodEnding();
        }
    }


    public void ReStart() // 단순 일시 정지 해제
    {
        GameObject.FindWithTag("Player").GetComponent<RbMove>().canMove = true;

        resource.spPoewrReduce = 1f + rbCode * 0.1f;
        resource.spHpRightReduce = 0.1f + rbCode * 0.1f;
        resource.spHpLeftReduce = 0.1f + rbCode * 0.1f;
        resource.spHpFrontReduce = 0.1f + rbCode * 0.1f;

    }


    public void StartGame() // 로봇을 만들면서 시작
    {
       

        rbCode += 1;
        GameObject instance = Instantiate(newrB, new Vector3(0, 0, 0), Quaternion.identity);
        instance.name = "ROBOT." + rbCode;
        //게임 진행중 감소량
        resource.spPoewrReduce = 1f  ;
        resource.spHpRightReduce = 0.5f ;
        resource.spHpLeftReduce = 1.3f ;
        resource.spHpFrontReduce = 0.8f ;
        resource.endTimeReduce = 0.02f;

        generator.GeneratorResource();

        resource.endTime -= 1f;

        GameObject.Find("EventTile").GetComponent<MakeRb>().canMakeRb = true;
        resource.indoor = true;
        resource.rbNextReady = false;
        //
    }
    public void BedEnding()
    {
        resource.spPoewrReduce = 0;
        resource.spHpRightReduce = 0;
        resource.spHpLeftReduce = 0;
        resource.spHpFrontReduce = 0;
        resource.spHp1 = 999;
        resource.spHp2 = 999;
        resource.spHp3 = 999;
        resource.spPower = 999;
        SceneManager.LoadScene("LoseScene");

    }
    public void GoodEnding()
    {
        Debug.Log("목표 도달에 성공했습니다.");
        SceneManager.LoadScene("WinScene");
    }
    
}
