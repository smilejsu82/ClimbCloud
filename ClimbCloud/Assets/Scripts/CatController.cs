using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    public float jumpForce = 650f; //점프하는 힘 
    private float moveForce = 30f;  //이동하는 힘 
    private Animator anim;

    void Start()
    {
        //this.gameObject.GetComponent<Rigidbody2D>();
        this.rBody2D = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //점프한다 
            //this.rBody2D.AddForce(방향 * 힘);
            this.rBody2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
        }

        //-1 0 1 (방향)
        int dirX = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) 
            dirX = -1;

        if (Input.GetKey(KeyCode.RightArrow)) 
            dirX = 1;

        //ForceMode2D.Force : 지속적으로 힘을 가할때 
        //ForceMode2D.Impulse : 충격을 줘서 힘을 가할때 
        float speedX = Mathf.Abs(this.rBody2D.velocity.x);

        if (speedX < 2f)
        {
            //this.rBody2D.AddForce(new Vector2(dirX, 0) * this.moveForce);
            this.rBody2D.AddForce(this.transform.right * dirX * this.moveForce);
        }

        //방향에따라서 반전 
        if (dirX != 0) {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        //플레이어의 속도에 따라서 애니메니션 속도를 바꾸자 
        this.anim.speed = speedX / 2.0f;


        Debug.LogFormat("velocity : {0}", this.rBody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogFormat("OnTriggerEnter2D: {0}", collision.name);
        Debug.Log("ClearScene씬으로 전환!");
        SceneManager.LoadScene("ClearScene");
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.LogFormat("OnTriggerStay2D: {0}", collision.name);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.LogFormat("OnTriggerExit2D: {0}", collision.name);
    //}

}
