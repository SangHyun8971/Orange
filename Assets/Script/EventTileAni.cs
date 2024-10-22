using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTileAni : MonoBehaviour
{
    public Resource resource;
    public Animator[] animator;
    // Start is called before the first frame update
    void Start()
    {
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(resource.spHp1 <= 35)
        {
            animator[0].SetBool("on", true);
        }
        else
        {
            animator[0].SetBool("on", false);
        }

        if (resource.spHp2 <= 35)
        {
            animator[1].SetBool("on", true);
        }
        else
        {
            animator[1].SetBool("on", false);
        }

        if (resource.spHp3<= 35)
        {
            animator[2].SetBool("on", true);
        }
        else
        {
            animator[2].SetBool("on", false);
        }
    }
}
