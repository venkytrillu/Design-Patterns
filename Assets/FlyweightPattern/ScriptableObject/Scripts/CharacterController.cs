using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	Rigidbody rb;
    public float speed = 10.0F;
    float rotationSpeed = 50.0F;
    Animator animator;
    static public bool dead = false;
    AnimationCommand idelAnimation, deadAnimation, walkAnimation;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        idelAnimation = new IdleAnimation();
        deadAnimation = new DeadAnimation();
        walkAnimation = new IdleAnimation();
        walkAnimation.Animate(animator, true);
    }

	void FixedUpdate () {
	
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f,rotation,0f);
        rb.MovePosition(rb.position + this.transform.forward * translation);
        rb.MoveRotation(rb.rotation * turn);

        if(translation != 0) 
        {
           // animator.SetBool("Idling", false);
            idelAnimation.Animate(animator, false);
        }
        else
        {
            //animator.SetBool("Idling", true);
            walkAnimation.Animate(animator, true);
        }

        if (dead)
        {
           // animator.SetTrigger("isDead");
            deadAnimation.Animate(animator);
            this.enabled = false;
        }


    }
}


public abstract class AnimationCommand
{
    public abstract void Animate(Animator anim);
    public abstract void Animate(Animator anim,bool status);
}

public class IdleAnimation: AnimationCommand
{
    public override void Animate(Animator anim,bool staus)
    {
        anim.SetBool("Idling", staus);
    }
    public override void Animate(Animator anim)
    {

    }
}

public class DeadAnimation : AnimationCommand
{
    public override void Animate(Animator anim, bool staus)
    {
    }
    public override void Animate(Animator anim)
    {
        anim.SetTrigger("isDead");
    }
}