using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
//using static UnityEngine.InputManagerEntry;

public class InterActResource : MonoBehaviour
{

    [SerializeField]
    public bool interActPlayer;
    [SerializeField]
    public bool keydown;
    [SerializeField]
    public RbMove player;
    private PanelAnimation panelAnimationScript;

    [SerializeField]
    public Resource resource;
    //public UiUpgradeRobot robot;
    [SerializeField]
    public float countTime;



    // Start is called before the first frame update
    void Start()
    {
        interActPlayer = false;
        keydown = false;
        player = GameObject.FindWithTag("Player").GetComponent<RbMove>();
        panelAnimationScript = GameObject.Find("Panel")?.GetComponent<PanelAnimation>();
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
        //robot = GameObject.Find("UpgradeRobot").GetComponent<UiUpgradeRobot>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("enter collider");
            player = col.GetComponent<RbMove>();
            interActPlayer = true;
            switch (tag)
            {

                case "Deck":
                    panelAnimationScript.SetActiveTrue(0);
                    break;

                case "Robot":
                    panelAnimationScript.SetActiveTrue(1);
                    break;

                case "Engine":
                    panelAnimationScript.SetActiveTrue(2);
                    break;

                default:
                    break;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            interActPlayer = false;
            switch (tag)
            {

                case "Deck":
                    panelAnimationScript.SetActiveFalse(0);
                    break;

                case "Robot":
                    panelAnimationScript.SetActiveFalse(1);
                    break;

                case "Engine":
                    panelAnimationScript.SetActiveFalse(2);
                    break;

                default:
                    break;
            }
        }
    }
}