using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;

    [SerializeField]
    private float offsetY = 0.25f;
    [SerializeField]
    private float sizeY = 0.45f;

    private bool isSliding = false;
    
    private Vector2 startOffset;
    private Vector2 startSize;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        startOffset = boxCollider.offset;
        startSize = boxCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        bool canSlide = animator.GetBool("IsFly") == false;
        if (canSlide)
        {
            if (isSliding)
            {
                bool isKeyUp = Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.DownArrow);
                if (isKeyUp)
                {
                    EndSlide();
                }
            }
            else
            {
                bool isKeyDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.DownArrow);
                if (isKeyDown)
                {
                    StartSlide();
                }
            }
        }
    }

    private void StartSlide()
    {
        boxCollider.offset = new Vector2(startOffset.x, offsetY);
        boxCollider.size = new Vector2(startSize.x, sizeY);

        isSliding = true;
        animator.SetBool("IsCrouch", isSliding);
    }

    private void EndSlide()
    {
        boxCollider.offset = startOffset;
        boxCollider.size = startSize;

        isSliding = false;
        animator.SetBool("IsCrouch", isSliding);
    }
}
