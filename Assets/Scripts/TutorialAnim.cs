using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TutorialAnim : MonoBehaviour
{
    public float timer;
    [SerializeField] float maxSpeed, smoothSpeed = 0.25f;
    public Transform player, destination;
    public GameObject wasd;
    Vector2 vel = Vector2.zero;

    float smoothTime = 0.3f, smoothVel = 0, currentValue = 0, targetValue = 1;
    List<Transform> children;
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
    void Update()
    {
        Debug.Log(Vector2.Distance(player.position, destination.position));
        if (Vector2.Distance(player.position, destination.position) < 0.1f)
        {
            wasd.SetActive(true);
            Color color = wasd.GetComponentInChildren<Text>().color;


            currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref smoothVel, smoothTime);
            color = new Color(color.r, color.g, color.b, currentValue);
            wasd.GetComponentInChildren<Text>().color = color;


            foreach (Transform child in children)
            {
                child.GetComponent<Text>().color = color;
            }

        }
        else
        {
            Animation();
        }
    }
    void Animation()
    {
        player.position = Vector2.SmoothDamp(player.position, destination.position, ref vel, smoothSpeed, maxSpeed);
    }
}