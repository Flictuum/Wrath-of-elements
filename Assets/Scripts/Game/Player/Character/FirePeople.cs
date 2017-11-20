using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePeople : ACharacter {
	
    public FirePeople()
    {
		this.totalHp = this.hp = 5;
        this.attack = 12;
        this.armor = 8;
		this.attackBonus = 0;
		this.armorBonus = 0;
        this.rangeAttack = 4;
        this.rangeMovement = 3;
		this.material = Resources.Load("Materials/Lava") as Material;
	}
}