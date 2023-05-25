using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool Swap;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Swap = animator.GetBool("AlexAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Swap = !Swap; // Switches Swap between True and false
            animator.SetBool("AlexAnimation", Swap);
        }
    }
}
