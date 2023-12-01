using UnityEngine;

namespace TestTask.Weapon
{
    [CreateAssetMenu(fileName = "Weapon Factory", menuName = "Factories/Weapon")]
    public sealed class WeaponFactory : GameObjectFactory, IWeaponFactory, IAmmoFactory
    {
        [SerializeField]
        private WeaponConfig _gun, _granade;

        public WeaponModel Get(WeaponType type, Transform parrent, Vector3 pos,
            Vector3 rot)
        {
            var config = GetConfig(type);
            var instance = CreateGameObjectInstance(config.Prefab, parrent, pos, rot,
                config.Scale);
            return new WeaponModel(instance, config.Damage, type);
        }

        public AmmoComponent Get(WeaponType type, Vector3 pos)
        {
            var config = GetConfig(type);
            return CreateGameObjectInstance(config.Ammo, pos:pos);

        }

        private WeaponConfig GetConfig(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Gun:
                    return _gun;
                case WeaponType.Granade:
                    return _granade;
            }

            Debug.LogError($"Config by Weapon Type: {type} not found!");
            return null;
        }
    }
}
