using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitions : MonoBehaviour
{
    private Animator animaTrans;
    void Start()
    {
        animaTrans = GameObject.Find("Transitions").GetComponent<Animator>();
    }

    public void activeTrans()
    {
        animaTrans.SetTrigger("startFade");
    }
}
