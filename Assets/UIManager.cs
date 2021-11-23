using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject resultMenu;

    public void Show()
    {
        resultMenu.SetActive(true);
    }

    public void Hide()
    {
        resultMenu.SetActive(false);
    }
}
