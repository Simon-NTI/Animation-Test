using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MageController : MonoBehaviour
{
    [SerializeField] float speed = 6;
    Animator animator;
    string LastDirection;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        string clipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.Translate(speed * Time.deltaTime * movement.normalized);

        //print(animator.GetCurrentAnimatorClipInfo(0)[0].clip);

        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack")
        {
            switch(Input.GetAxisRaw("Horizontal"))
            {
                case > 0:
                    animator.Play("MageRight");
                    animator.SetInteger("Horizontal", 1);
                    animator.SetInteger("Vertical", 0);
                    break;

                case < 0:
                    animator.Play("MageLeft");
                    animator.SetInteger("Horizontal", -1);
                    animator.SetInteger("Vertical", 0);
                    break;
            }

            if(Input.GetAxisRaw("Horizontal") == 0)
            switch(Input.GetAxisRaw("Vertical"))
            {
                case > 0:
                    animator.Play("MageUp");
                    animator.SetInteger("Vertical", 1);
                    animator.SetInteger("Horizontal", 0);
                    break;

                case < 0:
                    animator.Play("MageDown");
                    animator.SetInteger("Vertical", -1);
                    animator.SetInteger("Horizontal", 0);
                    break;
            }


            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                switch(clipName)
                {
                    case "MageRight":
                        animator.Play("MageIdleRight");
                        break;

                    case "MageLeft":
                        animator.Play("MageIdleLeft");
                        break;

                    case "MageUp":
                        animator.Play("MageIdleUp");
                        break;

                    case "MageDown":
                        animator.Play("MageIdleDown");
                        break;
                }
            }
        }


        // Onödig null-coalescing, men det är kul :)
        byte? direction = null;

        if(animator.GetInteger("Vertical") == 0 && animator.GetInteger("Horizontal") != 0)
        {
            direction = (byte)(animator.GetInteger("Horizontal") + 1);
        }
        else if(animator.GetInteger("Vertical") != 0)
        {
            direction = (byte)(animator.GetInteger("Vertical") + 2);
        }

        print(direction);

        if(Input.GetAxisRaw("Fire1") != 0)
        {
            switch(direction ?? 0)
            {
                case 0:
                    animator.Play("AttackLeft");
                    break;

                case 1:
                    animator.Play("AttackDown");
                    break;

                case 2:
                    animator.Play("Attack");
                    break;

                case 3:
                    animator.Play("AttackUp");
                    break;

                default:
                    print("Not found");
                    break;

            }
        }
    }
}
