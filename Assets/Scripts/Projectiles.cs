
using UnityEngine;

public enum projectileType
{
    arrow, slime
};
public class Projectiles : MonoBehaviour
{
    [SerializeField]
    int attackDamage;

    [SerializeField]
    projectileType pType;

    public int AttackDamage
    {
        get { return attackDamage; }
    }

    public projectileType PType
    {
        get { return pType; }
    }
}
