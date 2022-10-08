using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultados : MonoBehaviour
{   
    public GameObject confete;
    public Text pontosTotais;
    public Text nomeGrupo;
    public Text respostas;
    private string cena;
    void Start()
    {
        respostas.text = "Resposta: " + PlayerPrefs.GetString("alt");

        if(PlayerPrefs.GetInt("pontosPergunta") > 0)
        {
            pontosTotais.text = "Resposta Certa, Ganhos: " + PlayerPrefs.GetInt("pontosPergunta").ToString();
            nomeGrupo.text = "Grupo "+ (PlayerPrefs.GetInt("GrupoAcerto")) + ": " + PlayerPrefs.GetString("grupo" + PlayerPrefs.GetInt("grupoCerto").ToString());
            Instantiate(confete);
            soundsEffects.Instance.MakeConfete();
            soundsEffects.Instance.MakeAcerto();
        }
        else
        {
            pontosTotais.text = "";
            nomeGrupo.text = "Ninguém acertou";
            soundsEffects.Instance.MakeGameOver();
        }
    }

    public void voltaTema()
    {
        soundsEffects.Instance.MakeSelection();

        if(PlayerPrefs.GetInt("perguntas") <= 0)
        {
            cena = "resultadoFinal";
            StartCoroutine("tempCena");
        }
        else
        {
            cena = "transQuiz";
            StartCoroutine("tempCena");
        }
    }

    IEnumerator tempCena()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(cena);
    }

}
