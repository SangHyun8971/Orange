using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float maxHp;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetHealth(float _maxHp)
    {
        maxHp = _maxHp;
    }


    public void UpdateHealth(float _updateHp)
    {
        slider.maxValue = maxHp;
        slider.value = _updateHp;
    }
}
