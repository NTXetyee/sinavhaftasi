using UnityEngine;
using UnityEngine.SceneManagement;
public class ExamCutsceneScript : MonoBehaviour
{
    public bool copy, fail;
    float timer;
    public void Copy()
    {
        copy = true;
    }
    public void Fail()
    {
        fail = true;
    }
    void Update()
    {
        if (copy)
        {
            timer += Time.deltaTime;
            if (timer > 6)
            {
                SceneManager.LoadScene(6);
            }
        }
        else if (fail)
        {
            timer += Time.deltaTime;
            if (timer > 12)
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}