using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRobot : MonoBehaviour
{
    private MakeRb makeRb;
    void Start()
    {
        makeRb = GameObject.Find("EventTile").GetComponent<MakeRb>();
    }

    // Update is called once per frame
    void Update()
    {
        makeRb.setText();
    }
}
