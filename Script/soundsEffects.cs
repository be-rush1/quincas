using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class soundsEffects : MonoBehaviour
{
    public static soundsEffects Instance;
    public AudioSource music;
    public AudioClip acerto;
    public AudioClip erro;
    public AudioClip gameOver;
    public AudioClip somConfete;
    public AudioClip selection;
    public AudioClip empate;
    public AudioClip aplausos;
    public AudioClip clickVolume;
    public float volumeMusica;
    public float volumeSons;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Error");
        }
        
        Instance = GameObject.Find("Songs").GetComponent<soundsEffects>();
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "menu")
        {
            music.Play();
        }
    }
    void Update() 
    {
        music.volume = volumeMusica/100;
        if(SceneManager.GetActiveScene().name == "transQuiz")
        {
            music.Stop();
        }    
    }

    public void MakeVolume()
    {
        MakeSound (clickVolume);
    }
    public void MakeAcerto()
    {
        MakeSound (acerto);
    }
    public void MakeErro()
    {
        MakeSound (erro);
    }

    public void MakeGameOver()
    {
        MakeSound (gameOver);
    }

    public void MakeConfete()
    {
        MakeSound (somConfete);
    }
    public void MakeSelection()
    {
        MakeSound (selection);
    }

    public void MakeAplausos()
    {
        MakeSound (aplausos);
    }

    public void MakeEmpate()
    {
        MakeSound (empate);
    }

    private void MakeSound(AudioClip original)
    {
        AudioSource.PlayClipAtPoint(original,transform.position, volumeSons/10);
    }
}
