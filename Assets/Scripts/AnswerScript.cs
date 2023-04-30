using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerScript quizManager;
    public GameObject failObj;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Doğru cevap!");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Yanlış cevap!");
            failObj.SetActive(true);
            fail = true;
        }
    }
    bool fail;
    float timer;
    private void Update()
    {
        if (fail)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
