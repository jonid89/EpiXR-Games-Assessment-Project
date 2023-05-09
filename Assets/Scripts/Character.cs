using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public CharacterController _controller;
    public float _speed = 7;
    public float _rotationSpeed = 180;
    public Animator animator;
 

    void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();        
    }

    public void Update()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(rotation);
 
        Vector3 move = gameObject.transform.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        _controller.Move(move * _speed);
        

        if(Input.GetAxisRaw("Vertical") != 0){
            animator.SetBool("Moving",true);
        }else{
            animator.SetBool("Moving",false);
        }
       
    }
    
}
