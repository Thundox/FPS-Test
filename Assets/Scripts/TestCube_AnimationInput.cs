using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube_AnimationInput : MonoBehaviour
{
    Animator TCAnimator;
    // Start is called before the first frame update
    void Start()
    {
        TCAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TCAnimator != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                TCAnimator.SetBool("BoolLeft", true);
            }
            else
            {
                TCAnimator.SetBool("BoolLeft", false);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                TCAnimator.SetBool("BoolRight", true);
            }
            else
            {
                TCAnimator.SetBool("BoolRight", false);
            }
        }
    }
}
