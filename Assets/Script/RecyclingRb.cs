using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingRb : MonoBehaviour
{
    // Start is called before the first frame update
    public Resource resource;
    private RbMove rbMoveScript;
    private float destroySpeed;
    public float rbHp = 20f, maxRbHp;
    private bool canDestroy = false;

    public Slider slider;
    // Update is called once per frame
    private void Start()
    {
        maxRbHp = rbHp;     //처음 자원
        slider.maxValue = maxRbHp;
        slider.gameObject.SetActive(false);
        rbMoveScript = GetComponent<RbMove>();
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
    }

    private void FixedUpdate()
    {   if(rbMoveScript.rbPower <= 0)
        {
            slider.gameObject.SetActive(true);      //죽었을때 슬라이드 보여줌
        }

        if (canDestroy)
        {
            if (Input.GetKey(KeyCode.E))
            {
                rbHp -= destroySpeed * Time.deltaTime;
                if(rbHp <= 0)
                {
                    resource.plastic += 5f;
                    Debug.Log("파괴");
                    Destroy(gameObject);
                } 
            }
            else
            {
                rbHp = 20f;
            }
            
        }
        slider.value = rbHp;
        
    }

    private void OnCollisionEnter2D(Collision2D rb)
    {
        if(rb.collider.tag == "Player")
        {
            canDestroy = true;
            destroySpeed = 1f * rb.gameObject.GetComponent<RbMove>().rbEfficiency;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canDestroy = false;
        rbHp = 20f;
    }

}
