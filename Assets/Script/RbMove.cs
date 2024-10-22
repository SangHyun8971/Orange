using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMove : MonoBehaviour
{
    
    //�κ� �̵��� ���õ� ��ũ��Ʈ�Դϴ�.

    public float rbMoveSpeed; // �κ� �ӵ�
    public float rbPower; //�κ� �Ŀ�
    public float rbEfficiency; //�κ� ȿ��
    public float rbCapacity; //�κ� �κ��ִ� ũ��

    public float rbSpeed;// �κ� ���� �ӵ�

    public int kind = 0; //�ڿ� ����
    public float[] inventory = new float[3];//�κ��丮

    public Animator animator;

    public Resource resource;
    private HealthBar healthBarScript;

    public bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        resource = GameObject.Find("GameManager").GetComponent<Resource>();
        healthBarScript = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        
          // �κ� ������
          rbMoveSpeed = resource.rbNextMoveSpeed;
        rbPower = resource.rbNextPower;
        rbEfficiency = resource.rbNextEfficiency;
        rbCapacity = resource.rbNextCapacity;


        //���� �κ� �ʱ�ȭ
        resource.rbNextMoveSpeed = resource.rbMoveSpeed;
        resource.rbNextPower = resource.rbPower;
        resource.rbNextEfficiency = resource.rbEfficiency;
        resource.rbNextCapacity = resource.rbCapacity;

        GameObject.Find("Main Camera").GetComponent<CameraMove>().rb = gameObject;
        healthBarScript.SetHealth(rbPower);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthBarScript.UpdateHealth(rbPower);
        rbPower -= 1.0f * Time.deltaTime;
        if(rbPower <= 0.0f)
            Death();
        if (canMove)
            Move();
        Item();
    }
    void Item()
    {
        for(int i = 0; i < 3; i++)
        {
            if (inventory[i] >= rbCapacity)
                inventory[i] = rbCapacity;
        }
        if (resource.indoor)
        {
            resource.metal += inventory[0];
            resource.plastic += inventory[1];
            resource.uranium += inventory[2];
            for (int i = 0; i < 3; i++)
            {
                inventory[i] = 0;
            }
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 10, 0) * rbMoveSpeed * Time.deltaTime;
        }if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -10, 0) * rbMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(10, 0, 0) * rbMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-10, 0, 0) * rbMoveSpeed * Time.deltaTime;
        }
    }
    void Death()
    {
        

        GameObject.Find("GameManager").GetComponent<GameManager>().RbDeathStop();
        if (resource.indoor)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.tag = "Death";
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Destroy(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AnimationSet(bool onOff)
    {
        if(onOff) { animator.SetBool("on", true); } else
        {
            animator.SetBool("on", false);
        }
        
    }
}
