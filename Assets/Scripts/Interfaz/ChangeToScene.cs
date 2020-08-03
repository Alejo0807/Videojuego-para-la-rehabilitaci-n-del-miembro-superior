using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeToScene: MonoBehaviour {

    public void changeScene(int scene)
    {
        if (scene == 1)
        {
            for (int i = 0; i < 10000000; i++)
            {

            }
        }
        SceneManager.LoadScene(scene);
        //NameScrollList a = new NameScrollList();
        //a.RefreshDisplay();
    }
}
