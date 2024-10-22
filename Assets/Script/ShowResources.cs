using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResources : MonoBehaviour
{
    public Text[] allTexts;
    private Resource resourceScript;
    // Start is called before the first frame update
    void Start()
    {
        allTexts = GetComponentsInChildren<Text>();
        resourceScript = GameObject.Find("GameManager").GetComponent<Resource>();
    }

   
    void Update()
    {
        //int maxHp = _maxHp;
        allTexts[0].text = resourceScript.metal.ToString();
        allTexts[1].text = resourceScript.uranium.ToString();
        allTexts[2].text = resourceScript.plastic.ToString();

    }
}
