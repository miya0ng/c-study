public interface IDefender
{
    int CurrentHP { get; }
    int MaxHP { get; }
    void TakeDamage(int damage);
    bool IsDead { get; }
}
