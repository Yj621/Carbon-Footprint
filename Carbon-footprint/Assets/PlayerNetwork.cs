using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    [SerializeField] float Speed = 8f;
    NetworkVariable<int> randomValue = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Debug.Log(OwnerClientId +"; randomValue: "+randomValue.Value);
        if(!IsOwner)return;
        if(Input.GetKeyDown(KeyCode.T)){
            randomValue.Value = Random.Range(0, 100);
        }
      
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