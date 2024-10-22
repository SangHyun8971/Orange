using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    public Transform[] Panel;

    private void Start()
    {
        for (int i = 0; i < Panel.Length; i++)
        {
            Panel[i].gameObject.SetActive(false);
        }
    }

    public void SetActiveTrue(int number)
    {   //0은 deck, 1은 makerobot, 2는 엔진차징

        Panel[number].gameObject.SetActive(true);

    }

    public void SetActiveFalse(int number)
    {
        Panel[number].gameObject.SetActive(false);
    }
}
