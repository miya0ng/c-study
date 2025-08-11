public class Character
{
    public string Name { get; init; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public int MaxMp { get; set; }
    public int Mp { get; set; }
    public EquipmentType Type { get; set; }
    public Equipment? ReadOnlyEquippedItem { get { return EquippedItem; } }
    public Equipment? EquippedItem { get; set; }
    public Character(string name)
    {
        Name = name;
        Level = 1;
        Exp = 0;
        MaxHp = 0;
        MaxHp = 0;
        Hp = MaxHp;
        Mp = MaxMp;
        EquippedItem = null;
    }
    public void AddExp(int exp)
    {
        if (exp < 0)
        {
            Console.WriteLine("경험치는 음수일 수 없습니다.");
            return;
        }
        Exp += exp;
        while (Exp >= 1000)
        {
            Exp -= 1000;
            LevelUp();
        }
    }
    private void LevelUp()
    {
        if (Level >= 99)
        {
            Console.WriteLine($"{Name} : 더 이상 레벨업할 수 없습니다.");
            return;
        }
        OnLevelUp();
        Console.WriteLine($"{Name} : 레벨 {Level}로 상승!");
    }
    public void EquipItem(Equipment item)
    {
        if (item.RequiredLevel > Level)
        {
            Console.WriteLine($"{item.Name} : 레벨 {item.RequiredLevel} 이상만 장착 가능");
            return;
        }

        if(Type != item.Type)
        {
            Console.WriteLine("타입에 맞지 않는 무기를 장착 할 수 없습니다.");
            return;
        }
        //if(this.GetType().Name=="Warrior")
        //{
        //    if (EquippedItem != EquipmentType.Sword)
        //        return;
        //}
        //else if (this.GetType().Name == "Archer")
        //{
        //    if (EquippedItem != EquipmentType.Staff)
        //        return;
        //}
        //else if (this.GetType().Name == "Mage")
        //{
        //    if (EquippedItem != EquipmentType.Bow)
        //        return;
        //}
        EquippedItem = item;

        Console.WriteLine($"{item.Name} : 장착!");
    }
    public void UnequipItem()
    {
        if (EquippedItem == null)
        {
            Console.WriteLine("장착된 장비가 없습니다.");
            return;
        }

        Console.WriteLine($"{EquippedItem.Name} : 해제!");
        EquippedItem = null;
    }
    public override string ToString()
    {
        return $"캐릭터: {Name} (레벨: {Level}, 경험치: {Exp}/1000)\nHP: {Hp}/{MaxHp}, MP: {Mp}/{MaxMp}\n장착 장비: {(ReadOnlyEquippedItem != null ? ReadOnlyEquippedItem.Name : "없음")}";
    }

    public virtual void UseSpecialAbility()
    {

    }
    protected virtual void OnLevelUp()
    {

    }
}