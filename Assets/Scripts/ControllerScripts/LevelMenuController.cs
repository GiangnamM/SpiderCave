using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
   

    public void ChooseBtnLevel1()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
