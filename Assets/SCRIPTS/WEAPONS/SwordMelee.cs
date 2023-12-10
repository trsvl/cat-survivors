using System.Collections;
using UnityEngine;

public class SwordMelee : Melee
{
    Animator animator;

    PlayerMovement playerMovement;

    float dirX;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        dirX = playerMovement.lastVector.x;

        if (dirX > 0)
        {
            animator.SetBool("moveRight", true);
        }
        else
        {
            animator.SetBool("moveRight", false);
        }

    }

    void Update()
    {
        transform.position = playerMovement.transform.position  + new Vector3(dirX > 0 ? 1f : -1f, 0f, 0f);

    }
   

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }
  

}
