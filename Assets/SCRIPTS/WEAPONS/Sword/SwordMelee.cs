using UnityEngine;

public class SwordMelee : Melee
{
    Animator animator;
    PlayerMovement playerMovement;
    SwordController controller;
    float dirX;
    void Awake()
    {
        controller = FindObjectOfType<SwordController>();
        weaponData = controller.WeaponData;
    }
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        dirX = controller.DirXFirstSword;

        if (gameObject.name == "sword2")
        {
            animator.SetBool("moveRight", (dirX > 0) ? false : true);
        }
        else
        {
            animator.SetBool("moveRight", (dirX > 0) ? true : false);
        }
        ChangeLocalScale(2, 1.1f);
        ChangeLocalScale(3, 1.3f);
        ChangeLocalScale(4, 1.5f);
        ChangeLocalScale(5, 2f);
    }
    void ChangeLocalScale(int lvl, float value)
    {
        if (weaponData.level == lvl)
        {
            transform.localScale = transform.localScale * value;
        }
    }
    void Update()
    {
        if (gameObject.name == "sword0")
        {
            transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? 1f : -1f, 0f, 0f);
        }
        if (gameObject.name == "sword1")
        {
            if (weaponData.level == 3)
            {
                transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? 4f : -4f, 0f, 0f);
            }
            if (weaponData.level == 4)
            {
                transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? 5f : -5f, 0f, 0f);
            }
            if (weaponData.level == 5)
            {
                transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? 6f : -6f, 0f, 0f);
            }
            else
            {
                transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? 3f : -3f, 0f, 0f);
            }
        }
        if (gameObject.name == "sword2")
        {
            transform.position = playerMovement.transform.position + new Vector3(dirX > 0 ? -1f : 1f, 0f, 0f);
        }
    }
}
