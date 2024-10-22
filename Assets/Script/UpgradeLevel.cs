using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLevel : MonoBehaviour
{
    public MakeRb makeRb;
    public bool canUpgrade = false;
    // Start is called before the first frame update
    void Start()
    {
        makeRb = GameObject.Find("EventTile").GetComponent<MakeRb>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canUpgrade = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canUpgrade = false;
    }

    private void FixedUpdate()
    {
        if (canUpgrade)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                makeRb.Upgrade();
            }
        }
        
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                makeRb.Upgrade();
            }
        }
    }*/
}
