using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotCountText : MonoBehaviour
{
    public Text textTest;
    // Start is called before the first frame update
    void Start()
    {
        textTest.text = "RobotCount : " + GameObject.Find("GameManager").GetComponent<GameManager>().rbCode;
    }

    // Update is called once per frame
    void Update()
    {
        textTest.text = "RobotCount : " + GameObject.Find("GameManager").GetComponent<GameManager>().rbCode;
    }
}
