using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        GameSave.SaveState(new Save(123));
                 
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BuyItem(int price)
    {
        if (CollisionController.coins < price)
            return;

        CollisionController.coins -= price;
        Debug.Log("Item bought: ");
    }

}
