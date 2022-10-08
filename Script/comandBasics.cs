using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandBasics : MonoBehaviour
{

    public void caregaCena(string nomeCena)
    {
        soundsEffects.Instance.MakeSelection();
        StartCoroutine(tempCena(nomeCena));
    }

    public IEnumerator tempCena(string nomeCena)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(nomeCena);
    }

    public void livre()
    {
        PlayerPrefs.SetString("tema", "temaLivre"); 
        PlayerPrefs.SetString("conhecimento", "Aleatório");
    }

    public void categorias(string selectCategoria)
    {
        PlayerPrefs.SetString("tema", selectCategoria); //salvando qual categoria foi selecionada

        if(PlayerPrefs.GetString("tema") == "tema1")
        {
            PlayerPrefs.SetString("conhecimento", "Antropologia");
        }
        else if(PlayerPrefs.GetString("tema") == "tema2")
        {
            PlayerPrefs.SetString("conhecimento", "Ciência Política");
        }
        else if(PlayerPrefs.GetString("tema") == "tema3")
        {
            PlayerPrefs.SetString("conhecimento", "Sociologia");
        }

    }
    public void dificuldade(int qntPerguntas)
    {
        PlayerPrefs.SetInt("perguntas", qntPerguntas); //quantidade de perguntas que serão respondidas
    }

    public void tempoPergunta(float timeMax)
    {
        PlayerPrefs.SetFloat("tempo", timeMax); //tempo da dificuldade
    }

    public void empate()
    {
        PlayerPrefs.SetInt("pontosGrupo1",0);
        PlayerPrefs.SetInt("pontosGrupo2",0);
        PlayerPrefs.SetInt("pontosGrupo3",0);
        PlayerPrefs.SetInt("pontosGrupo4",0);
        PlayerPrefs.SetString("grupo1",PlayerPrefs.GetString("grupoDesempate1"));
        PlayerPrefs.SetString("grupo2",PlayerPrefs.GetString("grupoDesempate2"));
        PlayerPrefs.SetString("grupo3",PlayerPrefs.GetString("grupoDesempate3"));
        PlayerPrefs.SetString("grupo4",PlayerPrefs.GetString("grupoDesempate4"));
        PlayerPrefs.SetInt("qntGrupos", PlayerPrefs.GetInt("qntGruposDesempate"));
        empateCena();
    }

    public void empateCena()
    {
        soundsEffects.Instance.MakeSelection();
        StartCoroutine(tempCena("looby"));
    }

    public void linkLabes()
    {
        Application.OpenURL("http://www.labes.fe.ufrj.br/?cat_id=6&sec_id=22");
    }

    public void reiniciaMusic()
    {
        soundsEffects.Instance.music.Play();
    }

}
