using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class perguntas : MonoBehaviour
{

    public AudioSource relogio;
    private float speedPitch = 1f;
    private float time;
    public Image clock;
    private int contDica;
    public Text timeTxt;
    public Text euSouText;
    public Text dicaText;
    public GameObject HudPause;
    public Text txtPause;
    public SpriteRenderer fundoColor;
    public Color grupo1;
    public Color grupo2;
    public Color grupo3;
    public Color grupo4;


    public string[] euSou;
    public string[] dica1;
    public string[] dica2;
    public string[] dica3;
    public string[] dica4;
    public string[] respostas;

    private int varDica;
    private int points;
    private int pointsTotal;
    private int varPerguntas;
    private int varDesafio;
    private bool pause;
    public int nGrupos;
    private bool playRelogioGame;

    void Awake() 
    {
        varPerguntas = PlayerPrefs.GetInt("perguntas");
        time = PlayerPrefs.GetFloat("tempo");
        nGrupos = PlayerPrefs.GetInt("ordem");

        if(PlayerPrefs.GetInt("ordem") < PlayerPrefs.GetInt("qntGrupos"))
        {
            PlayerPrefs.SetInt("ordem", PlayerPrefs.GetInt("ordem") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("ordem", 1);
        }
    }

    void Start() 
    {
        contDica = 0;
        geraPergunta();
    }

    void Update() 
    {
        relogioPitch();

        ordemGrupos();
        clock.fillAmount = time/PlayerPrefs.GetFloat("tempo");
        timeTxt.text = time.ToString("F0");

        if(time <= 0)
        {
            if(contDica == 0)
            {
                carregaDica2();
            }
            else if(contDica == 1)
            {
                carregaDica3();
            }
            else if(contDica == 2)
            {
                carregaDica4();
            }
            else if(contDica == 3)
            {
                fimDica();
            }
            relogio.Pause();
            playRelogioGame = false;
        }
        else
        {
            if(!pause)
            {
                time -= Time.deltaTime;
            }
        }

        if(time <= 20 && !playRelogioGame)
        {
            StartCoroutine("playRelogio");
            playRelogioGame = true;
        }
    }

    void ordemGrupos()
    {
        if(nGrupos >= PlayerPrefs.GetInt("qntGrupos") + 1) 
        {
            nGrupos = 1;
        }

        if(nGrupos == 1)
        {
            fundoColor.color = grupo1;
        }
        else if(nGrupos == 2)
        {
            fundoColor.color = grupo2;
        }
        else if(nGrupos == 3)
        {
            fundoColor.color = grupo3;
        }
        else if(nGrupos == 4)
        {
            fundoColor.color = grupo4;
        }
    }

    public void VerificaPergunta()
    {
        if(PlayerPrefs.GetInt("anterior") == varDesafio)
        {
            geraPergunta();
        }
        else
        {
            carregaPerfil();
            PlayerPrefs.SetInt("anterior", varDesafio);
        }
    }
    public void geraPergunta()
    {
        varDesafio = Random.Range(0, euSou.Length);
        VerificaPergunta();
    }
    public void carregaPerfil()
    {
        Debug.Log("Pergunta: " +  varDesafio);
        varDica = 1;
        points = 5;
        euSouText.text = euSou[varDesafio];
        dicaText.text = "Dica 1: " + dica1[varDesafio];
        PlayerPrefs.SetString("alt", respostas[varDesafio]);
    }

    public void btnPause()
    {
        pause = !pause;

        if(!pause)
        {
            
            txtPause.text = "PAUSE";
            HudPause.SetActive(false);

            if(time <= 20)
            {
                relogio.Play();
            }
        }
        else
        {
            relogio.Pause();
            txtPause.text = "RETOMAR";
            HudPause.SetActive(true);
        }
    }

    public void carregaDica2()
    {
        soundsEffects.Instance.MakeErro();

        if(varDica == 1)
        {
            dicaText.text = "Dica 2: " + dica2[varDesafio];
            points = points - 2;
            varDica++;
            time = PlayerPrefs.GetFloat("tempo");
            contDica++;
            nGrupos++;
        }
    }
    public void carregaDica3()
    {   
        soundsEffects.Instance.MakeErro();

        if(varDica == 2)
        {
            dicaText.text = "Dica 3: " + dica3[varDesafio];
            points--;
            varDica++;
            time = PlayerPrefs.GetFloat("tempo");
            contDica++;
            nGrupos++;
        }
    }
    public void carregaDica4()
    {
        soundsEffects.Instance.MakeErro();

        if(varDica == 3)
        {
            dicaText.text = "Dica 4: " + dica4[varDesafio];
            points--;
            time = PlayerPrefs.GetFloat("tempo");
            contDica++;
            nGrupos++;
        }
    }

    public void fimDica()
    {
        varPerguntas--;
        PlayerPrefs.SetInt("perguntas", varPerguntas);
        PlayerPrefs.SetInt("pontosPergunta", 0);
        SceneManager.LoadScene("resultado");
    }

    public void resposta(string alternativa)
    {
        if(alternativa == "certo" && !pause)
        {
            varPerguntas--;
            pointsTotal = points; 
            PlayerPrefs.SetInt("pontosPergunta", pointsTotal);
            PlayerPrefs.SetInt("pontosGrupo"+ nGrupos, pointsTotal + PlayerPrefs.GetInt("pontosGrupo"+ nGrupos));
            PlayerPrefs.SetInt("perguntas", varPerguntas);
            PlayerPrefs.SetInt("grupoCerto", nGrupos);
            SceneManager.LoadScene("resultado");
            PlayerPrefs.SetInt("GrupoAcerto", nGrupos);
        }   

        if(alternativa == "errado" && !pause)
        {
            if(contDica == 0)
            {
                carregaDica2();
            }
            else if(contDica == 1)
            {
                carregaDica3();
            }
            else if(contDica == 2)
            {
                carregaDica4();
            }
            else if(contDica == 3)
            {
                fimDica();
            }
        }
    }
    void relogioPitch()
    {
        relogio.pitch = speedPitch;

        if(time <= 20)
        {
            speedPitch = 1.3f;
        }
        if(time <= 10)
        {
            speedPitch = 1.5f;
        }
    }

    IEnumerator playRelogio()
    {
        yield return new WaitForSeconds(0.1f);
        relogio.Play();
    }
}
