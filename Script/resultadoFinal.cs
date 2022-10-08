using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultadoFinal : MonoBehaviour
{
    public GameObject fundoVencedor;
    public Text pontosGrupo1;
    public Text pontosGrupo2;
    public Text pontosGrupo3;
    public Text pontosGrupo4;
    public int[] vencedor;
    public Text record; 
    private int maiorVar;
    public int contador;
    public int contadorV;
    private int contVencedorR;
    public GameObject buttonDesempate;
    private string[] grupoEmpate = new string [4];
    private int grupos;
    private int indices;

    public GameObject confete;
    void Start()
    {

        pontosGrupo1.text = PlayerPrefs.GetString("grupo1") + ": " + PlayerPrefs.GetInt("pontosGrupo1").ToString();
        pontosGrupo2.text = PlayerPrefs.GetString("grupo2") + ": " + PlayerPrefs.GetInt("pontosGrupo2").ToString();
        pontosGrupo3.text = PlayerPrefs.GetString("grupo3") + ": " + PlayerPrefs.GetInt("pontosGrupo3").ToString();
        pontosGrupo4.text = PlayerPrefs.GetString("grupo4") + ": " + PlayerPrefs.GetInt("pontosGrupo4").ToString();

        if(pontosGrupo3.text == ": 0")
        {
            pontosGrupo3.text = "";
        }

        if(pontosGrupo4.text == ": 0")
        {
            pontosGrupo4.text = "";
        }

        grupoEmpate[0] = PlayerPrefs.GetString("grupo1");
        grupoEmpate[1] = PlayerPrefs.GetString("grupo2");
        grupoEmpate[2] = PlayerPrefs.GetString("grupo3");
        grupoEmpate[3] = PlayerPrefs.GetString("grupo4");

        vencedor[0] = PlayerPrefs.GetInt("pontosGrupo1");
        vencedor[1] = PlayerPrefs.GetInt("pontosGrupo2");
        vencedor[2] = PlayerPrefs.GetInt("pontosGrupo3");
        vencedor[3] = PlayerPrefs.GetInt("pontosGrupo4");

        maiorVar = Mathf.Max(vencedor);

        verificador();
    
    }  
    void verificador()
    {
        for(int i = 0; i < vencedor.Length; i++)
        {
            for(int j = 0; j < vencedor.Length-1; j++)
            {
                if(vencedor[i] > vencedor[j+1])
                {
                    contadorV++;
                    grupos = i;
                    addGrupo();
                    break;
                }
                if(vencedor[i] == vencedor[j+1])
                {
                    if(vencedor[i] > 0 && vencedor[j+1] > 0)
                    {
                        contador++;
                        grupos = i;
                        addGrupo();
                        break;
                    }
                }
            }
        }

        if(contadorV == 0 && contador == 0)
        {
            empate();
            empateNulo();
        }
        else if(contador > 1 && contadorV < 1 )
        {
            empate();
        }
        else
        {
            Debug.Log("PROCURA VENCEDOR");
            vencedorVe();
        }
    }
    void vencedorVe() // verifica quem tem o maior numero do array, se tiver mais de um numero que esteja com o mesmo numero do maior numero do array é impate.
    {
        PlayerPrefs.DeleteKey("grupoDesempate1");
        PlayerPrefs.DeleteKey("grupoDesempate2");
        PlayerPrefs.DeleteKey("grupoDesempate3");
        PlayerPrefs.DeleteKey("grupoDesempate4");
        PlayerPrefs.DeleteKey("qntGruposDesempate");

        for(int i = 0; i < vencedor.Length; i++)
        {
            if(vencedor[i] == maiorVar)
            {
                contVencedorR++;
                grupos = i;
                addGrupoV();
                indices = i;
            }
        }
        if(contVencedorR > 1)
        {
            empate();
        }
        else
        {
            indices++;
            record.text = PlayerPrefs.GetString("grupo" + indices.ToString());
            fundoVencedor.SetActive(true);
            Instantiate(confete);
            soundsEffects.Instance.MakeConfete();
            soundsEffects.Instance.MakeAplausos();
        }
        Debug.Log("VALOR VENCEDOR: "+ contVencedorR);
    }
    void addGrupo()
    {
        if(contador > 0) 
        {
            PlayerPrefs.SetString("grupoDesempate"+ contador.ToString(), grupoEmpate[grupos]);
            PlayerPrefs.SetInt("qntGruposDesempate", contador);
        }
        if(contadorV > 0)
        {
            PlayerPrefs.SetString("grupoDesempate"+ contadorV.ToString(), grupoEmpate[grupos]);
            PlayerPrefs.SetInt("qntGruposDesempate", contadorV);
        }
    }
    void addGrupoV()
    {
        PlayerPrefs.SetString("grupoDesempate"+ contVencedorR.ToString(), grupoEmpate[grupos]);
        PlayerPrefs.SetInt("qntGruposDesempate", contVencedorR);
    }
    void empateNulo() //esse metodo é para pegar os grupos para o desempate que estejam com o valor 0
    {
        for(int i = 0; i < PlayerPrefs.GetInt("qntGrupos"); i++)
        {
            for(int j = 0; j < PlayerPrefs.GetInt("qntGrupos")-1; j++)
            {
                if(vencedor[i] == vencedor[j+1])
                {
                    contador++;
                    grupos = i;
                    addGrupo();
                    break;
                }
            }
        }
    }
    void empate()
    {
        record.text = "EMPATE";
        buttonDesempate.SetActive(true);
        fundoVencedor.SetActive(false);
        soundsEffects.Instance.MakeEmpate();
    }
}