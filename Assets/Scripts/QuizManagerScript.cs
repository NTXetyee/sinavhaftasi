using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManagerScript : MonoBehaviour
{
    public List<Qna> qna;
    public GameObject[] options;
    public int currentQuestion;

    public Text questionText;

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        qna.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i];

            if (qna[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void GenerateQuestion()
    {
        if(qna.Count > 0)
        {
            currentQuestion = Random.Range(0, qna.Count);

            questionText.text = qna[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            SceneManager.LoadScene(10);
        }
    }
}
