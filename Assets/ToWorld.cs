using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWorld : MonoBehaviour
{
    private void Update()
    {
        var screenX = Screen.width / 2;
        var screenY = Screen.height / 2;
        var screenPos = new Vector3(screenX, screenY);

        var pointPos = Camera.main.ScreenToWorldPoint(screenPos);
        
        transform.position = new Vector3(pointPos.x, pointPos.y);
    }
}
