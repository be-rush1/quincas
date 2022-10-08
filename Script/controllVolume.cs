using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controllVolume : MonoBehaviour
{
    public Text musicaText;
    public Text somText;
    private soundsEffects volumes;
    void Awake()
    {
        volumes = GameObject.Find("Songs").GetComponent<soundsEffects>();
    }

    void Update()
    {
        musicaText.text = volumes.volumeMusica.ToString();
        somText.text = volumes.volumeSons.ToString();
    }

    public void aumentaValor(string controle)
    {
        soundsEffects.Instance.MakeVolume();
        if(volumes.volumeMusica < 10 && controle == "musica")
        {
            volumes.volumeMusica++;
        }

        if(volumes.volumeSons < 10 && controle == "sons")
        {
            volumes.volumeSons++;
        }
    }

    public void diminuiValor(string controle)
    {
        soundsEffects.Instance.MakeVolume();
        if(volumes.volumeMusica > 0 && controle == "musica")
        {
            volumes.volumeMusica--;
        }

        if(volumes.volumeSons > 0 && controle == "sons")
        {
            volumes.volumeSons--;
        }
    }
}
