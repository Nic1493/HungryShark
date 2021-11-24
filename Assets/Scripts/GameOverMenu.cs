public class GameOverMenu : Menu
{
    protected override void Awake()
    {
        base.Awake();

        FindObjectOfType<Shark>().GameOverAction += Open;
    }
}