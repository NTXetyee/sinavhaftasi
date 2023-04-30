using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialAnim : MonoBehaviour
{
    [SerializeField] float maxSpeed, smoothSpeed = 0.25f;
    public Transform player, destination;
    public GameObject wasd;
    Vector2 vel = Vector2.zero;
    // WASD harflerinin yavaşça belirmesi için gereken değişkenler
    float smoothTime = 0.3f, smoothVel = 0, currentValue = 0, targetValue = 1;

    List<Transform> children;

    // Ana karakterimizin sahneye girme animasyonu
    void Animation()
    {
        player.position = Vector2.SmoothDamp(player.position, destination.position, ref vel, smoothSpeed, maxSpeed);
    }


    void Start()
    {
        wasd.SetActive(false);
        children = GetChildren(wasd.transform);
    }
    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        
        foreach(Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }
    bool makeYellow = false, dissapear, isEntering = true;

    void Update()
    {
        if (!isEntering)
        {
            wasd.SetActive(true);
            Color color = wasd.GetComponentInChildren<Text>().color;

            if (color.a > 0.95f)
            {
                if (!dissapear)
                {
                    MakeYellow();
                    makeYellow = true;
                    player.GetComponent<PlayerScript>().enabled = true;
                }
            }
            else if (!makeYellow)
            {
                // WASD harflerinin yavaşça belirme kodu
                currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref smoothVel, smoothTime);
                color = new Color(color.r, color.g, color.b, currentValue);
                wasd.GetComponentInChildren<Text>().color = color;
                foreach (Transform child in children)
                {
                    child.GetComponent<Text>().color = color;
                }
            }
        }
        if (Vector2.Distance(player.position, destination.position) < 0.1f)
        {
            isEntering = false;
        }
        else if (isEntering)
        {
            Animation();
        }



        if (dissapear)
        {
            Dissapear();
        }


        if (congrats)
        {
            Congrats();
        }
    }
    // Eğitim bölümünde hareket tuşlarına basıldığını belirten kod
    bool w = false, a = false, s = false, d = false;
    void MakeYellow()
    {
        if (Input.GetKeyDown(KeyCode.W) && !w)
        {
            GameObject.Find("W").GetComponent<Text>().color = Color.yellow;
            w = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && !a)
        {
            GameObject.Find("A").GetComponent<Text>().color = Color.yellow;
            a = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && !s)
        {
            GameObject.Find("S").GetComponent<Text>().color = Color.yellow;
            s = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && !d)
        {
            GameObject.Find("D").GetComponent<Text>().color = Color.yellow;
            d = true;
        }
        if (w && a && s && d)
        {
            dissapear = true;
            makeYellow = false;
        }
    }
    // WASD harfleri yavaşça kaybolur
    void Dissapear()
    {
        Color color = wasd.GetComponentInChildren<Text>().color;
        currentValue = Mathf.SmoothDamp(currentValue, 0, ref smoothVel, smoothTime);
        color = new Color(color.r, color.g, color.b, currentValue);
        wasd.GetComponentInChildren<Text>().color = color;
        if (color.a < 0.05f)
        {
            foreach (Transform child in children)
            {
                child.GetComponent<Text>().color = new Color(0, 0, 0, 0);
            }
            congrats = true;
            dissapear = false;
        }
        else
        {
            foreach (Transform child in children)
            {
                child.GetComponent<Text>().color = color;
            }
        }
    }
    bool congrats;
    void Congrats()
    {
        SceneManager.LoadScene(2);
    }
}