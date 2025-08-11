public class Equipment
{
    public string Name { get; init; } = "";
    public int RequiredLevel { get; init; } = 1;
    public int AttackBonus { get; init; } = 0;

    public EquipmentType Type { get; init; }
    public override string ToString()
    {
        return $"{Name} (공격력 +{AttackBonus}, 필요 레벨: {RequiredLevel}, 종류: {Type})";
    }
}