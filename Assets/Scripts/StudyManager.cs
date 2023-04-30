using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyManager : MonoBehaviour
{
    float timer;
    public bool clicked;
    public void Clicked()
    {
        clicked = true;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (clicked)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                //Sınav kısmı
                SceneManager.LoadScene(9);
            }
        }
    }
}
