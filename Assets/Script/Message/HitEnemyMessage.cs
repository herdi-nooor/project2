namespace LightFight.Message
{
    public struct HitEnemyMessage
    {
        public int Damage { get; set; }

        public HitEnemyMessage(int damage)
        {
            Damage = damage;
        }
    }
}