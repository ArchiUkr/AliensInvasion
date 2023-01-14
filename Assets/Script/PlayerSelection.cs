using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] GameObject[] starsSparrow;
    int selectionPlayer = 0;

    public void NextCharacter()
    {
        starsSparrow[selectionPlayer].SetActive(false);
        selectionPlayer = (selectionPlayer + 1) % starsSparrow.Length;
        starsSparrow[selectionPlayer].SetActive(true);
    }

    public void PreviousCharacter()
    {
        starsSparrow[selectionPlayer].SetActive(false);
        selectionPlayer--;
        if(selectionPlayer > 0)
        {
            selectionPlayer += starsSparrow.Length;
        }
        starsSparrow[selectionPlayer].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectionPlayer", selectionPlayer);
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }
}
