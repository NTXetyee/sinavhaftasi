using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Level1Manager : MonoBehaviour
{
    Image black;
    
    void Start()
    {
        black = GameObject.Find("Black").GetComponent<Image>();
    }
    float vel;
    public bool gameOver;
    void Update()
    {
        if (gameOver)
        {
            float colorA = black.color.a;
            float newColorA = Mathf.SmoothDamp(black.color.a, 1, ref vel, 0.5f);
            black.color = new Color(black.color.r, black.color.g, black.color.b, newColorA);
            if (black.color.a < 0.1f)
            {
                NextLevel();
            }
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(4);
    }
}