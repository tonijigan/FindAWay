public class LeaderBoardPlayer
{
    public LeaderBoardPlayer(int coins, string name)
    {
        Coins = coins;
        Name = name;
    }

    public int Coins { get; private set; }
    public string Name { get; private set; }
}