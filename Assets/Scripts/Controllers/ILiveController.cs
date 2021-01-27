public interface ILiveController
{
    int Damage { get; }

    void GetHit(int incomeDamage);
    void SetLives(int lives);
}