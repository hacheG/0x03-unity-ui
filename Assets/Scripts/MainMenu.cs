using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayMaze()
    {
        SceneManager.LoadScene(1);
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");

    }
    // Update is called once per frame
    void Update()
    {

    }
}
