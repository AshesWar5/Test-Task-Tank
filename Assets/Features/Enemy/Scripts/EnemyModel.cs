namespace TestTask.Enemy
{
    public sealed class EnemyModel
    {
        public float Health { get; set; }
        public float SpeedMovement { get; set; }

        public readonly EnemyComponent Enemy;
        public readonly float Protection;
        public readonly int Damage;

        public EnemyModel(EnemyComponent enemy, float health, float protection, float speedMovement,
            int damage) 
        {
            Enemy = enemy;
            Health = health;
            SpeedMovement = speedMovement;
            Protection = protection;
            Damage = damage;
        }
    }
}