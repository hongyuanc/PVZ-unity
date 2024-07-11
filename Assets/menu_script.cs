using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Day");
    }
}
