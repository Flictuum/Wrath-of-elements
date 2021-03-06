﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPeople : ACharacter {
	
    public WaterPeople()
	{
		this.totalHp = this.hp = 10;
		this.attack = 7;
		this.armor = 9;
		this.attackBonus = 0;
		this.armorBonus = 0;
		this.rangeAttack = 5;
		this.rangeMovement = 30;
		this.material = Resources.Load("Materials/Water") as Material;
    }
}
