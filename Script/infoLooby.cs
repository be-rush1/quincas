using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoLooby : MonoBehaviour
{
    public Text grupo1;
    public Text grupo2;
    public Text grupo3;
    public Text grupo4;
    public Text conhecimento;
    public GameObject fundoG1;
    public GameObject fundoG2;
    public GameObject fundoG3;
    public GameObject fundoG4;

    void Start()
    {
        grupo1.text = "Grupo 1: " + PlayerPrefs.GetString("grupo1");
        grupo2.text = "Grupo 2: " + PlayerPrefs.GetString("grupo2");
        grupo3.text = "Grupo 3: " + PlayerPrefs.GetString("grupo3");
        grupo4.text = "Grupo 4: " + PlayerPrefs.GetString("grupo4");
        
        if(PlayerPrefs.GetString("conhecimento") != "Aleatório")
        {
            conhecimento.text = "Área: " + PlayerPrefs.GetString("conhecimento");
        }
        else
        {
            conhecimento.text = "Modo: " + PlayerPrefs.GetString("conhecimento");
        }

        if(grupo3.text == "Grupo 3: ")
        {
            grupo3.text = "";
            fundoG3.SetActive(false);
        }

        if(grupo4.text == "Grupo 4: ")
        {
            grupo4.text = "";
            fundoG4.SetActive(false);
        }
    }
}
