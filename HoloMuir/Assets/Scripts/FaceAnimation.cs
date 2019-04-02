using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
    }

    public void Talking(){
        anim.SetBool("isTalking", true);
    }

    public void NotTalking(){
        anim.SetBool("isTalking", false);
    }


    // Update is called once per frame
    void Update(){
        
    }
}
