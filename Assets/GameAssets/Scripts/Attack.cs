using System.Collections;
using System.Collections.Generic;

public class Attack
{
    public enum Type { DOT, Burst}
    Type type;     
    float damage;

    public Attack()
    {
        damage = 10f;
        type = Type.Burst;
    }
    public Attack(float dmg, Attack.Type attackType)
    {
        damage = dmg;
        type = attackType;
    }

    public void DealDamage()
    {
        if(type == Type.DOT)
        {
            // Deal Damage over time
        }
        else
        {
            // Deal Damage Directly
        }
        
        // Call event to check status of thing that was hit?
    }
    
}
