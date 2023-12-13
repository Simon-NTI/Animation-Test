using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbaController : MonoBehaviour
{

    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            // GetComponent<Animator>().SetTrigger("Speen");
            // GetComponent<Animator>().SetFloat("x", 1);

            GetComponent<Animator>().Play("Speen");
        }
    }
}
