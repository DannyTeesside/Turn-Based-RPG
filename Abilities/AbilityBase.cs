using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Create New Ability")]
public class AbilityBase : ScriptableObject
{

    [SerializeField] string abilityName;
    [SerializeField] int manaCost;
    [SerializeField] int damage;
    [TextArea(10, 14)] [SerializeField] string description;



    public string GetAbilityName()
    {
        return abilityName;
    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public int GetDamage()
    {
        return damage;
    }

    public string GetDescription()
    {
        return description;
    }
}
