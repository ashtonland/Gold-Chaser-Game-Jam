using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(anim.GetBool("Open") == false)
            {
                Time.timeScale = 0.5f;
                anim.SetBool("Open", true);
            }
            else
            {
                Time.timeScale = 1f;
                anim.SetBool("Open", false);
            }
        }
    }
}
