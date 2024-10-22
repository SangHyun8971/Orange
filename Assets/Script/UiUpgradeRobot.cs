using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Reflection;

public class UiUpgradeRobot : MonoBehaviour
{
    private MakeRb makeRbScript;
    public Button[] buttons;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        makeRbScript = GameObject.Find("EventTile").GetComponent<MakeRb>();
        text = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i]; // 배열의 각 버튼을 가져옴

            int index = i; // 로컬 변수로 캡처
            button.onClick.AddListener(() => OnClickButton(index));
            // 각 버튼에 고유한 이벤트를 연결
            AddHoverListener(button, i);
        }
    }

    void AddHoverListener(Button button, int index)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // PointerEnter 이벤트 트리거 추가
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;

        // 버튼별로 고유한 이벤트를 할당하기 위해 람다식 사용
        entry.callback.AddListener((data) => { OnHoverButton(button, index); });

        trigger.triggers.Add(entry);
    }

    private void OnClickButton(int index)
    {
        makeRbScript.Level = index+1;
        if (makeRbScript.makeCost <= GameObject.Find("GameManager").GetComponent<Resource>().plastic)
        {
            _ = GameObject.Find("GameManager").GetComponent<Resource>().plastic - makeRbScript.makeCost;
            gameObject.SetActive(false);
        }
    }

    void OnHoverButton(Button button, int index)
    {
  
        switch (index)
        {
            case 0:
                text.text = $"{(makeRbScript.makeCost * 1).ToString()} Cost";
                break;
            case 1:
                text.text = $"{(makeRbScript.makeCost * 2).ToString()} Cost";
                break;
            case 2:
                text.text = $"{(makeRbScript.makeCost * 3).ToString()} Cost";
                break;
            case 3:
                text.text = $"{(makeRbScript.makeCost * 4).ToString()} Cost";
                break;
            case 4:
                text.text = $"{(makeRbScript.makeCost * 5).ToString()} Cost"; 
                break;

            // 필요한 만큼 추가
            default:
                
                break;
        }
    }

}
