using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActSector : InterActResource
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interActPlayer)
        {
            SearchKeyStatuse();
        }
    }

    void SearchKeyStatuse()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keydown = true;
            player.AnimationSet(true);
            countTime = 0.0f;
            StartCoroutine(StartRepair());
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            keydown = false;
            player.AnimationSet(false);
            countTime = 0.0f;
        }
    }

    IEnumerator StartRepair()
    {
        while (keydown)
        {
            countTime += Time.deltaTime;
            //���ּ� ���� = �ڿ� x 2
            //���� ���� = �ڿ� x 5 
            switch (name)
            {
                case "DeckRepair1":         // ���� ���� ��ȣ�ۿ�
                    if (countTime >= 2.0f)
                    {
                        if (resource.metal >= 50)
                        {
                            resource.spHp1 = resource.spMaxHp;
                            resource.metal -= 50;
                            Debug.Log("Deck1 ������ �Ϸ�Ǿ����ϴ�");
                            player.AnimationSet(false);
                            //player.AnimationSet(false);
                        }
                        else
                        {
                            Debug.Log("Deck1 ������ ���еǾ����ϴ�");
                            player.AnimationSet(false);
                            //rbMove.AnimationSet(true);
                        }

                        keydown = false;
                    }
                    break;

                case "DeckRepair2":         // ������ ���� ��ȣ�ۿ�
                    if (countTime >= 2.0f)
                    {
                        if (resource.metal >= 50)
                        {
                            resource.spHp2 = resource.spMaxHp;
                            resource.metal -= 50;
                            Debug.Log("Deck2 ������ �Ϸ�Ǿ����ϴ�");
                            player.AnimationSet(false);
                            //rbMove.AnimationSet(true);

                        }
                        else
                        {
                            Debug.Log("Deck2 ������ ���еǾ����ϴ�");
                            player.AnimationSet(false);
                            //rbMove.AnimationSet(true);
                        }

                        keydown = false;

                    }
                    break;

                case "DeckRepair3":       // ���� ���� ��ȣ�ۿ�
                    if (countTime >= 2.0f)
                    {
                        if (resource.metal >= 50)
                        {
                            resource.spHp3 = resource.spMaxHp;
                            resource.metal -= 50;
                            Debug.Log("Deck3 ������ �Ϸ�Ǿ����ϴ�");
                            player.AnimationSet(false);

                        }
                        else
                        {
                            Debug.Log("Deck3 ������ ���еǾ����ϴ�");
                            player.AnimationSet(false);
                        }

                        keydown = false;
                    }
                    break;

                case "Entrance":
                    Debug.Log("in");// ���Ա� ��ȣ�ۿ�
                    resource.indoor = true;
                    //if()
                    keydown = false;
                    break;

                case "Exit":            // ���Ա� ��ȣ�ۿ�
                    Debug.Log("exit");
                    resource.indoor = false;
                    //if()
                    keydown = false;
                    break;

                case "RobotManufacturing":  // �κ� ���� ��ȣ�ۿ�
                    
                        if (countTime >= 2.0f)
                        {
                                player.AnimationSet(false);
                                GameObject.Find("EventTile").GetComponent<MakeRb>().MakeRobot();
                                keydown = false;

                        }

                    break;

                case "EngineCharging":      // ������ ���� ��ȣ�ۿ�
                    if ((resource.uranium * 5) >= resource.maxSpPower - resource.spPower)
                    {
                        player.AnimationSet(false);
                        if(resource.spPower <= 90)
                            resource.spPower += 10f;
                        resource.uranium -= 3;
                    }
                    else
                    {
                        player.AnimationSet(false);
                        resource.spPower += resource.uranium * 5;
                        resource.uranium = 0;
                    }
                    Debug.Log("interact enginecharging");
                    keydown = false;
                    break;
            }
            yield return new WaitForSeconds(0);
        }
    }
}
