using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoHandler : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
