using UnityEngine;
public class MenuScript : MonoBehaviour
{
    public GameObject playMenu;
    public void Play()
    {

    }
    public void Settings()
    {
        playMenu.SetActive(false);
    }
}