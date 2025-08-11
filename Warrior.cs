
public class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
        Level = 1;
        Exp = 0;
        MaxHp = 150;
        Hp = MaxHp;
        MaxMp = 50;
        Mp = MaxMp;
        EquippedItem = null;
        Type = EquipmentType.Sword;
    }
    public override void UseSpecialAbility()
    {
        if(Mp>=30)
        {
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
        Hp += 30;
        if(Hp>=MaxHp)
        {
            Hp = MaxHp;
        }
    }
}