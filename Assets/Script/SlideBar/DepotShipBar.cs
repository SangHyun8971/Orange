using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepotShipBar : MonoBehaviour
{
    public Slider slider;
    private Resource resourceScript;
    private float maxHp;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        resourceScript = GameObject.Find("GameManager").GetComponent<Resource>();
    }

    public void SetHealth(float _maxHp)
    {
        maxHp = _maxHp;
    }

    private void Update()
    {
        slider.maxValue = maxHp;
        slider.value = resourceScript.spPower;
    }

}
