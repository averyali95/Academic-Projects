//  ****************************************************************************
//  Name:Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: warrior.cpp
//  Compiler Used: VS 2012
//  ****************************************************************************
#include <iostream>
#include <string>
#include "warrior.h"
#include "player.h"

using namespace std;

Warrior :: Warrior(string wn, int wlev, int wstr, int  Wety, int Wedur, int WelevReq, bool st,int sp)
	:Player(wn,wlev,wstr,st)
{
	weapon2= new Weapon(Wety,Wedur,WelevReq);
	set_special(sp);
}

Warrior::~Warrior()
		{
			if ( weapon2 != NULL )
			{	 
				delete weapon2;
				weapon2 = NULL;
			}
		
		}

void Warrior :: read() 
{
		    int wType,wLvl, pLvl;
			string name;
			
			cout << "Enter Name: ";
			cin >> name;
			Player::set_PlayerName(name);
		
			//cout << "Enter warrior type:(1) Warrior (2) Wizard (3) Vampire (4) Sorceress: ";
			//cin >> pType;
			//set_PlayerType(pType);
		
			cout << "Enter Warrior level (1-100): ";
			cin >> pLvl ;
			Player::set_PlayerLevel(pLvl);
		
			//cout << "Enter player strength (1-100): ";
		    //cin >> pStr;
			//Player::set_PlayerStrength(pStr);
		
			cout << "Enter weapon type:(1)LongSword (2)Mace: ";
			cin >> wType;
			setWeaponType(wType);
		
			//cout << "Enter weapon durability (0-100): ";
			//cin >> wDurab;
			//setWeaponDurability(wDurab);
			
			cout << "Enter weapon level required: (Greater than 0):  ";
			cin >> wLvl;
			setWeaponLevelRequired(wLvl);
			


}

void Warrior :: display() const
		{
			
			cout << "Player type WARRIOR" << endl
			     << "Name: " << get_PlayerName() << endl  
			     << "Player Level: " << get_PlayerLevel() << endl 
				 << "Strength level: " << get_PlayerStrength() << endl;
			if(getWeaponType() == 1)
			{
				cout << "Weapon type: LongSword" << endl;
			}
			else
			{
				cout << "Weapon type: Mace" << endl;
			}
			cout << "Weapon durability: " << getWeaponDurability() << endl 
			     << "Level required to use: " << getWeaponLevelRequired() << endl;
			cout << "Special: increased damage = " << special << " seconds" << endl;
			
		}


int Warrior::getWeaponType() const
{
	return weapon2->get_type();
}

void Warrior :: setWeaponType(int wt)
{
	weapon2->set_type(wt);
}

void Warrior :: setWeaponDurability(int wd)
{
	weapon2->set_durability(wd);
}

int Warrior :: getWeaponDurability() const
{
	return weapon2->get_durability();
}

void Warrior :: setWeaponLevelRequired(int lr)
{
	weapon2->set_levelRequired(lr);
}

int Warrior :: getWeaponLevelRequired() const
{
	return weapon2->get_levelRequired();
}

void Warrior :: set_special(int sp)
{
	special = sp;
}

int Warrior :: get_Special() const
{
	return special;
}