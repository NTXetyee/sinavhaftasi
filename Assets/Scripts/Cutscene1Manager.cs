using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cutscene1Manager : MonoBehaviour
{
    float timer = 0;
    public bool pressed;
    public void Pressed()
    {
        pressed = true;
    }
    bool beltSoundPlayed;
    public Transform sound;
    void Update()
    {
        if (pressed)
        {
            timer += Time.deltaTime;
        }

        if (timer > 13)
        {
            if (!beltSoundPlayed)
            {
                // Buraya kemer sesi
                sound.GetComponent<AudioSource>().Play();

                beltSoundPlayed = true;
            }
        }
        if (timer > 15)
        {
            SceneManager.LoadScene(3);
        }
    }
}