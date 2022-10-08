using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerenciaGrupos : MonoBehaviour
{
    public GameObject bntConfirma;
    public Text grupo1;
    public Text grupo2;
    public Text grupo3;
    public Text grupo4;
    public string[] nameGrupos;
    public int players;
    private int num;

    void Update()
    {

        if(grupo1.text != "" && grupo2.text != "")
        {
            bntConfirma.SetActive(true);
            players = 2;
        }
        else
        {
            bntConfirma.SetActive(false);
        }
        
        if(grupo3.text != "")
        {
            players = 3;
        }
        if(grupo4.text != "")
        {
            players = 4;
        }
    }

   
    public void ConfirmaGrupos()
    {
        nameGrupos[0]= grupo1.text;
        nameGrupos[1]= grupo2.text;
        nameGrupos[2]= grupo3.text;
        nameGrupos[3]= grupo4.text;
        PlayerPrefs.SetString("grupo1",nameGrupos[0]);
        PlayerPrefs.SetString("grupo2",nameGrupos[1]);
        PlayerPrefs.SetString("grupo3",nameGrupos[2]);
        PlayerPrefs.SetString("grupo4",nameGrupos[3]);
        PlayerPrefs.SetInt("qntGrupos", players);
    }
}
