using static System.Net.Mime.MediaTypeNames;

public class Archer : Character
{
    public Archer(string name) : base(name)
    {
        Level = 1;
        Exp = 0;
        MaxHP = 120;
        CurrentHP = MaxHP;
        MaxMP = 70;
        Mp = 70;
        EquippedItem = null;
        Type = EquipmentType.Bow;
    }
    public override void UseSpecialAbility(IDefender target)
    {
        if(Mp>=25)
        {
            target.TakeDamage(40);
            Console.WriteLine($"{Name}이(가) 더블 샷을 사용했습니다!");
            Mp -= 25;
            if (Mp <= 0)
            {
                Mp = 0;
            }
        }
        else
        {
            Console.WriteLine("마나 부족");
        }
    }

    protected override void OnLevelUp()
    {
        Mp += 15;
        CurrentHP += 15;
        Level++;
        if (CurrentHP >= MaxHP)
        {
            CurrentHP = MaxHP;
        }
        if (Mp >= MaxMP)
        {
            Mp = MaxMP;
        }
    }
}

