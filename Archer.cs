public class Archer : Character
{
    public Archer(string name) : base(name)
    {
        Level = 1;
        Exp = 0;
        MaxHp = 120;
        Hp = 120;
        MaxMp = 70;
        Mp = 70;
        EquippedItem = null;
        Type = EquipmentType.Bow;
    }
    public override void UseSpecialAbility()
    {
        if(Mp>=25)
        {
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
        Hp += 15;
        Level++;
        if (Hp >= MaxHp)
        {
            Hp = MaxHp;
        }
        if (Mp >= MaxMp)
        {
            Mp = MaxMp;
        }
    }
}

