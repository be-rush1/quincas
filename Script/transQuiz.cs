using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class transQuiz : MonoBehaviour
{
    public GameObject quiz;
    public GameObject contagemQuiz;
    public Text contagem;
    public float timeMax;
    public float time;
    private bool start = false;

    public transitions trans;

    void Start()
    {
        time = timeMax;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        contagem.text = time.ToString("F0");

        if (start && time > 1)
        {
            time -= Time.deltaTime;
        }

        if(time < 1)
        {
            if(start)
            {
                StartCoroutine("pass");
            }
            start = false;
        }

    }

    IEnumerator pass()
    {
        yield return new WaitForSeconds(0.2f);
        contagemQuiz.SetActive(false);
        Instantiate(quiz, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        trans.activeTrans();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(PlayerPrefs.GetString("tema"));
    }
}
