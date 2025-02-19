using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Color finishColor;
    Color originColor;

    private void Start()
    {
        originColor = GetComponent<SpriteRenderer>().color;
        FindObjectOfType<GameManager>().totalBoxs++;
    }
    public bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir * 0.5f, dir, 0.5f);

        if (!hit||hit.collider.tag=="Target")
        {
            transform.Translate(dir);
            return true;
        }
            

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            FindObjectOfType<GameManager>().finishBoxs++;
            FindObjectOfType<GameManager>().CheckFinish();
            GetComponent<SpriteRenderer>().color = finishColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            FindObjectOfType<GameManager>().finishBoxs--;
            GetComponent<SpriteRenderer>().color = originColor;
        }
    }
}
