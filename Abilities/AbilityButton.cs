using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{

    [SerializeField] AbilityBase ability;
    [SerializeField] TextMeshProUGUI displayAbilityName;
    string abilityName;
    int damage;
    int manaCost;
    string description;


    private void OnEnable()
    {
        displayAbilityName.text = ability.GetAbilityName().ToString();
        abilityName = ability.GetAbilityName();
        damage = ability.GetDamage();
        manaCost = ability.GetManaCost();
        description = ability.GetDescription();
    }

    public AbilityBase GetAbility()
    {
        return ability;
    }

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
