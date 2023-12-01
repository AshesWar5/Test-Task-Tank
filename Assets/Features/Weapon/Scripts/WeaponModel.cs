namespace TestTask.Weapon
{
    public sealed class WeaponModel
    {
        public readonly WeaponComponent Weapon;
        public readonly int Damage;
        public readonly WeaponType WeaponType;

        public WeaponModel(WeaponComponent weapon, int damage, WeaponType weaponType)
        {
            Weapon = weapon;
            Damage = damage;
            WeaponType = weaponType;
        }
    }
}