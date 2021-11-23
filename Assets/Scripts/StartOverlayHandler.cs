using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverlayHandler : MonoBehaviour
{
    [SerializeField] GameObject overlay;

    public void StartGame()
    {
        GetComponent<GameManager>().StartGame();
    }

    public void Show()
    {
        overlay.SetActive(true);
    }

    public void Hide()
    {
        overlay.SetActive(false);
    }
}
