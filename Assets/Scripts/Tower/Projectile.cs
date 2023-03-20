using UnityEngine;

public enum projectileType
{
    arrow, slime, fireball, mage, bomb
};
public abstract class Projectile : MonoBehaviour
{
    public int attackDamage;

    public projectileType pType;

    public Enemy enemy;

    public int AttackDamage
    {
        get { return attackDamage; }
    }

    public projectileType PType
    {
        get { return pType; }
    }
}
