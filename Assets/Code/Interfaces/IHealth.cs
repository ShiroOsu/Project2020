namespace PlayerControls
{
    public interface IHealth
    {
        void RestoreHealth();
        void UpgradeHealth();
        void TakeDamage(float foo);
    }
}