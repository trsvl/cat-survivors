public class LastEnemyController : EnemyController
{
    NewGameManager newGameManager;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (localHealth <= 0)
        {
            newGameManager = FindObjectOfType<NewGameManager>();
            newGameManager.EnableCanvas();
        }
    }
}
