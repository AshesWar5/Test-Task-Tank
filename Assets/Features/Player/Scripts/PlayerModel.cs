using TestTask.Weapon;

namespace TestTask.Player
{
    public sealed class PlayerModel
    {
        public float Health { get; set; }

        public readonly PlayerComponent Player;
        public readonly float Protection;
        public readonly float SpeedMovement;
        public readonly WeaponType[] Weapons;


        public PlayerModel(PlayerComponent player, float health, float protection,
            float speedMovement, WeaponType[] weapons) 
        {
            Player = player;
            Health = health;
            SpeedMovement = speedMovement;
            Protection = protection;
            Weapons = weapons;
        }
    }
}