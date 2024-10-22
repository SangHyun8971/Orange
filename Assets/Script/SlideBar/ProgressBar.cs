using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    private Resource resourceScript;
    private float maxp;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        resourceScript = GameObject.Find("GameManager").GetComponent<Resource>();
        maxp = 10f;
    }

    private void Update()
    {
        slider.maxValue = maxp;
        slider.value = maxp - resourceScript.endTime;
    }

}
