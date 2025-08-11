
public class Mage : Character
{
    //EquipmentType Type = EquipmentType.Staff;
    public Mage(string name) : base(name)
    {
        Level = 1;
        Exp = 0;
        MaxHp = 100;
        Hp = MaxHp;
        MaxMp = 80;
        Mp = MaxMp;
        EquippedItem = null;
        Type = EquipmentType.Staff;
    }
    public override void UseSpecialAbility()
    {
        if (Mp >= 20)
        {
            Console.WriteLine($"{Name}이(가) 파이어 볼을 사용했습니다!");
            Mp -= 20;
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
        Mp += 20;
        Level++;
        if (Hp >= MaxHp)
        {
            Hp = MaxHp;
        }
    }
}