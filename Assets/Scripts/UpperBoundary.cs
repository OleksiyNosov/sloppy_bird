using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBoundary : MonoBehaviour
{
    private void Update()
    {
        var screenX = Screen.width / 2;
        var screenY = Screen.height;
        var screenPoint = new Vector3(screenX, screenY);

        var verticalOffset = 0.5f;
        var pointPos = Camera.main.ScreenToWorldPoint(screenPoint);
        var objPos = new Vector3(pointPos.x, pointPos.y + verticalOffset);

        transform.position = objPos;
    }
}
