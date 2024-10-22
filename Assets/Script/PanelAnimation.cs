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
    {   //0�� deck, 1�� makerobot, 2�� ������¡

        Panel[number].gameObject.SetActive(true);

    }

    public void SetActiveFalse(int number)
    {
        Panel[number].gameObject.SetActive(false);
    }
}
