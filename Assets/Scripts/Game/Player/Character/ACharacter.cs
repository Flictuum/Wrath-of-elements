using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter
{
	protected int hp;
	protected int totalHp;
	protected int armor;
	protected int attack;
	protected int rangeMovement;
	protected int rangeAttack;
	protected Material material;
    protected int attackBonus;
    protected int armorBonus;

    public int getHp()
    {
        return hp;
    }

	public int GetTotalHp() {
		return totalHp;
	}

	public int getRangeMovement()
	{
        return rangeMovement;
	}

	public int getRangeAttack()
	{
        return rangeAttack;
	}

	public int getArmor()
	{
        return armor + armorBonus;
	}

	public int getAttack()
	{
        return attack + attackBonus;
	}

	public Material getMaterial()
	{
		return material;
	}

    public void applyDamage(int damage)
    {
		if (getArmor () >= damage) return;
        hp -= (damage - getArmor());
    }

    public void setAttackBonus(int bonus)
    {
        attackBonus = bonus;
    }

	public void setArmorBonus(int bonus)
	{
        armorBonus = bonus;
	}

	public void addAttackBonus(int bonus)
	{
		attackBonus += bonus;
	}

	public void addArmorBonus(int bonus)
	{
		armorBonus += bonus;
	}
}
