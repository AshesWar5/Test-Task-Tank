namespace TestTask.Weapon
{
    public sealed class WeaponsSwitch
    {
        private readonly WeaponComponent[] _weapons;

        private int _lastIndexWeapon = 0;

        public WeaponsSwitch(WeaponComponent[] weapons)
        {
            _weapons = weapons;
            OnSwitchWeapon(0);
        }

        public void OnSwitchWeapon(int numberSwitch)
        {
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].Deactivate();
            }

            _lastIndexWeapon = _lastIndexWeapon + numberSwitch;
            if (_lastIndexWeapon < 0)
            {
                _lastIndexWeapon = _weapons.Length - 1;
            }
            else if (_lastIndexWeapon >= _weapons.Length)
            {
                _lastIndexWeapon = 0;
            }
            _weapons[_lastIndexWeapon].ActivateWeapon();
        }
    }
}