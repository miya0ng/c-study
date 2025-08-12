public class Monster : IDefender, IAttacker
{
    public Monster(string name, int level, int hp, int dmg, int exp)
    {
        Name = name;
        Level = level;
        MaxHP = hp;
        CurrentHP = MaxHP;
        Dmg = dmg;
        ExpReward = exp;
    }
    public string Name {  get; set; } 
    public int Level {  get; set; }
    public int Dmg { get; set; }
    public int ExpReward {  get; set; }

    public int CurrentHP { get; set; }

    public int MaxHP {  get; set; }       

    public bool IsDead {  get; set; }

    public int AttackPower {  get; set; }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
    }

    public override string ToString()
    {
        return $"{Name}, {Level}";
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(10);
    }
}
