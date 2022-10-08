using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudGrupo : MonoBehaviour
{
    private Animator anima;
    public Text nameGrupo;
    private perguntas infoPerguntas;

    void Start()
    {
        anima = GetComponent<Animator>();
        infoPerguntas = GameObject.FindObjectOfType<perguntas>();
    }

    void Update()
    {
        anima.SetInteger("grupo", infoPerguntas.nGrupos);
        nameGrupo.text = "Grupo " + infoPerguntas.nGrupos.ToString() + ": " + PlayerPrefs.GetString("grupo" + infoPerguntas.nGrupos.ToString());
    }
}
