
public class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
        Level = 1;
        Exp = 0;
        MaxHP = 150;
        CurrentHP = MaxHP;
        MaxMP = 50;
        Mp = MaxMP;
        EquippedItem = null;
        Type = EquipmentType.Sword;
    }
    public override void UseSpecialAbility(IDefender target)
    {
        if(Mp>=30)
        {
            target.TakeDamage(40);
            Console.WriteLine($"{Name}이(가) 강력한 일격을 사용했습니다!");
            Mp -= 30;
            if (Mp <= 0)
            {
                Mp = 0;
            }
        }
        else
        {
            Console.WriteLine("마나 부족");
            return;
        }
    }

    protected override void OnLevelUp()
    {
        Level++;
        CurrentHP += 30;
        if(CurrentHP >= MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }
}