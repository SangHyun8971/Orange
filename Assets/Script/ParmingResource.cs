using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParmingResource : InterActResource
{
    public int kind;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(interActPlayer)
        {
            SearchKeyStatuse();
        }
        else
        {
            keydown = false;
        }
    }

    void SearchKeyStatuse()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keydown = true;
            StartCoroutine(GetResource());
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            keydown = false;
        }
    }

    IEnumerator GetResource()
    {
        while(keydown)
        {
            Debug.Log("Get Resource");
            switch (kind)
            {

                case 0:
                    player.inventory[0] += 10f;
                    break;

                case 1:
                    player.inventory[1] += 2f;
                    break;

                case 2:
                    player.inventory[2] += 1f;
                    break;

                default:
                    break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
