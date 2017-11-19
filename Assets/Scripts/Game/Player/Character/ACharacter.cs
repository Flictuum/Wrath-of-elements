﻿using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter
{
	protected int hp;
	protected int armor;
	protected int attack;
	protected int rangeMovement;
	protected int rangeAttack;
	protected Material material;

    public int getHp()
    {
        return hp;
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
        return armor;
	}

	public int getAttack()
	{
        return attack;
	}

	public Material getMaterial()
	{
		return material;
	}

    public void applyDamage(int damage)
    {
        hp -= (damage - getArmor());
    }
}