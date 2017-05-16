using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_gameContol : MonoBehaviour {
	public void loadLevel()
    {
        
        Invoke("loadlevel",1);
        
    }
    public void loadLevel2()
    {
        
        Invoke("loadlevel2", 1);
        
    }
    void loadlevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
    void loadlevel2()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
  
}
