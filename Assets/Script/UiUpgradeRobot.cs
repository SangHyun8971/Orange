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
            Button button = buttons[i]; // �迭�� �� ��ư�� ������

            int index = i; // ���� ������ ĸó
            button.onClick.AddListener(() => OnClickButton(index));
            // �� ��ư�� ������ �̺�Ʈ�� ����
            AddHoverListener(button, i);
        }
    }

    void AddHoverListener(Button button, int index)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // PointerEnter �̺�Ʈ Ʈ���� �߰�
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;

        // ��ư���� ������ �̺�Ʈ�� �Ҵ��ϱ� ���� ���ٽ� ���
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

            // �ʿ��� ��ŭ �߰�
            default:
                
                break;
        }
    }

}
