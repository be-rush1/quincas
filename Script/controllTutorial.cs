using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllTutorial : MonoBehaviour
{
    private Animator animaTutorial;
    private int id = 1;
    void Start()
    {
        animaTutorial = GameObject.Find("tutorial").GetComponent<Animator>();
    }

    void Update() 
    {
        animaTutorial.SetInteger("states", id);
    }

    public void maisID()
    {
        if(id < 12)
        {
            id++;
        }
    }

    public void menosID()
    {
        if(id > 1)
        {
            id--;
        }
    }
}
