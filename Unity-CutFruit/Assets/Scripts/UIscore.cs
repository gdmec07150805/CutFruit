using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIscore : MonoBehaviour {
    [HideInInspector]public static UIscore _instance;
    public void Awake()
    {
        _instance = this;
    }
    private int count = 0;
    public Text countText;

    public void AddScore()
    {
        count += 1;
        countText.text = ""+count;
    }
    public void LessScore()
    {
        count -= 5;
        if (count<0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        countText.text = "" + count;
    }
}
