namespace BlaisePascal.LessonsExamples3E.Domain
{
    public class Enemy
    {
        // Backing field
        private int _health;

        public string Name { get; set; }

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 100)
                {
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }
        }

        public int Damage { get; private set; }

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return Health > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
            }
        }

    }
}