using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyconytoller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Animator anim;
    float virticul;
    float horizontal;
    float jump=9f;
    bool isground=false;
    Transform tr;
    public static int score=5;
    [SerializeField] TextMeshProUGUI text; 

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        tr=GetComponent<Transform>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        virticul = Input.GetAxis("Vertical");      
        horizontal= Input.GetAxis("Horizontal");
        rb.AddRelativeForce(0,0,virticul*70f);
        tr.Rotate(0,horizontal,0);
        if (Input.GetKeyDown("space")){
                anim.SetBool("jump",true);
            }else{
                anim.SetBool("jump",false);
            }
        if (virticul>0){
            anim.SetBool("step",true);
            if (Input.GetKeyDown("left shift")){
                anim.SetBool("run",true);
            }
            if (Input.GetKeyUp("left shift")){
                anim.SetBool("run",false);
            }
        }else{
            anim.SetBool("step",false);
        }
        if(Input.GetKeyDown("space") && isground==true){
             rb.AddForce(0,jump,0, ForceMode.Impulse);
        }
        
        // rb.AddForce(0,0,horizontal*10f);
        // if(Input.GetKeyDown("w")){
        //     print("y");
        //     rb.AddForce(0,0,200f);
        // }
        // if(Input.GetKeyDown("s")){
        //     print("x");
        //     rb.AddForce(0,0,-200f);
        // }
    }
    void OnCollisionEnter(Collision col){
            if(col.gameObject.tag =="ground"){
                isground=true;
            }
            if(col.gameObject.tag==" monetka"){
                score=score-1;
                text.text=score+"";
                Destroy(col.gameObject);
                if (score==0){
                    print("pobeda");
                }  
            }
                
    }
    
    void OnCollisionExit(Collision col){
            if(col.gameObject.tag =="ground"){
                isground=false;
            }       
    }
}
