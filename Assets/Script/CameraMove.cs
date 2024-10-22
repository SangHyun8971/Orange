using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject rb;
    public float speed = 1f;

    private Camera thisCamera;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            gameObject.transform.position = new Vector3(rb.transform.position.x,rb.transform.position.y,-10);
        }
        move();
    }

    void move()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;
        if (scroll != 0)
        {
            Debug.Log(scroll);
        }
        // scroll < 0 : scroll downÇÏ¸é ÁÜÀÎ
        if (thisCamera.orthographicSize <= 5f && scroll > 0)
            thisCamera.orthographicSize = 5f;
        else if (thisCamera.orthographicSize >= 10f && scroll < 0)
            thisCamera.orthographicSize = 10f;
        else thisCamera.orthographicSize -= scroll;
    }
}
