using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private SpriteRenderer spriteRenderer;
    private GameObject nextTile;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        // Move
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Copy
        if (IsInCamera() && nextTile == null)
        {
            var nextPos = transform.position + new Vector3(spriteRenderer.bounds.size.x, 0, 0);
            nextTile = Instantiate(gameObject, nextPos, Quaternion.identity);
            nextTile.transform.parent = transform.parent;
        }

        // Destroy
        if (!IsVisible())
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
    }

    private bool IsInCamera()
    {
        var sceenLeftPosPixel = new Vector3(0, Screen.height / 2);
        var screenLeftPos = Camera.main.ScreenToWorldPoint(sceenLeftPosPixel);
        var sceenRightPosPixel = new Vector3(Screen.width, Screen.height / 2);
        var screenRightPos = Camera.main.ScreenToWorldPoint(sceenRightPosPixel);

        var leftPosPixel = new Vector3(spriteRenderer.sprite.bounds.max.x, spriteRenderer.sprite.bounds.max.y / 2, 0);
        var leftBoundPos = spriteRenderer.transform.TransformPoint(leftPosPixel);
        var rightPosPixel = new Vector3(spriteRenderer.sprite.bounds.min.x, spriteRenderer.sprite.bounds.max.y / 2, 0);
        var rightBoundPos = spriteRenderer.transform.TransformPoint(rightPosPixel);

        return leftBoundPos.x > screenLeftPos.x && rightBoundPos.x < screenRightPos.x;
    }

    private bool IsVisible()
    {
        var sceenLeftPosPixel = new Vector3(0, Screen.height / 2);
        var screenLeftPos = Camera.main.ScreenToWorldPoint(sceenLeftPosPixel);

        var leftPosPixel = new Vector3(spriteRenderer.sprite.bounds.max.x, spriteRenderer.sprite.bounds.max.y / 2, 0);
        var leftBoundPos = spriteRenderer.transform.TransformPoint(leftPosPixel);

        return leftBoundPos.x >= screenLeftPos.x;
    }
}
