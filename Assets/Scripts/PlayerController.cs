using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 moveDirection;
    public LayerMask detectLayer;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            moveDirection = Vector2.right;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveDirection = Vector2.down;

        if (moveDirection != Vector2.zero)
        {
            if(CanMoveToDir(moveDirection))
            {
                Move(moveDirection);
            }
        }

        moveDirection= Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, detectLayer);

        if(!hit.collider) return true;
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
               return hit.collider.GetComponent<Box>().CanMoveToDir(dir);

        }

        return false;
    }

    void Move(Vector2 dir)
    {
        transform.Translate(dir);
    }
}
