using System.Data;

namespace BlaisePascal.Game.Domain;

public class Player
{
    private string _name;
    public string Name
    {
        get { return _name; }
        private set
        {
            if (value != "") _name = value;
            else _name = "Player";
        }
    }

    private int _health;
    public int Health
    {
        get { return _health; }
        private set
        {
            if (value >= 0 && value <= MaxHealth)
            {
                _health = value;
                if (value == 0) IsAlive = false;
            }
            else throw new ArgumentOutOfRangeException("Health must be between 0 and MaxHealth");
        }
    }
    public int Level
    {
        get;
        private set
        {
            if (value > 1) Level = value;
        }
    }
    public int Experience
    {
        get;
        private set
        {
            if (value > 0) Experience = value;
            else throw new ArgumentOutOfRangeException("Experience must be greater than 0");
        }
    }
    private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        private set
        {
            if (value > 0) _maxHealth = value;
            else throw new ArgumentOutOfRangeException("MaxHealth must be greater than 0");
        }
    }
    /*public bool IsAlive { 
        get 
        {
            if (Health == 0) return false;
            else return true;
        }
    }
    */
    public bool IsAlive { get; private set; }
    public int Gold { get; private set; }

    public void AddExperience(int experiencetoAdd)
    {
        if (experiencetoAdd >= 0)
        {
            while (Experience + experiencetoAdd >= 100)
            {
                Level += 1;
                experiencetoAdd -= 100;
            }
        }
        else throw new ArgumentException("Cannot add negative experience");

    }
    public void ResetExperience()
    {
        Experience = 0;
    }
    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;
    }

    public void Heal(int healthHealed)
    {
        if (healthHealed > 0) Health += healthHealed;
        else throw new ArgumentException("Cannot heal by negative values");
    }

    public void AddGold(int addedGold)
    {
        Gold += addedGold;
    }

    public void ResetHealth()
    {
        IsAlive = true;
        Health = MaxHealth;
    }
    public Player(string name)
    {
        Name = name;
        Experience = 0;
        Level = 1;
        MaxHealth = 100;
        Health = MaxHealth;
        IsAlive = true;
        Gold = 0;
    }
}