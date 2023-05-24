using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public float Speed;
    float h;
    float v;
    bool isHorizonMove;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //키씹힘방지
        if (hDown)
            isHorizonMove = true; 
        else if (vDown)
            isHorizonMove = false;
        else if(hUp || vUp)
            isHorizonMove = h !=0;

        //isChange의 값은 키가 바뀌었을때를 의미
        if(anim.GetInteger("hAxisRaw") != h){
            anim.SetBool("isChange",true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v){
            anim.SetBool("isChange",true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else{
            anim.SetBool("isChange",false );
        }
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }
}
