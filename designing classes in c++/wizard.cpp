//  ****************************************************************************
//  Name:Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: wizard.cpp
//  Compiler Used: VS 2012
//  ****************************************************************************
#include <iostream>
#include <string>
#include <cstdlib>
#include "wizard.h"
#include "player.h"

using namespace std;

Wizard :: Wizard(string wn, int wlev, int wstr, int  Wety, int Wedur, int WelevReq, bool st,int sp)
	:Player(wn,wlev,wstr,st)
{
	weapon1= new Weapon(Wety,Wedur,WelevReq);
	setSpecial(sp);

}

Wizard::~Wizard()
		{
			if ( weapon1 != NULL )
			{	 
				delete weapon1;
				weapon1 = NULL;
			}
		
		}

void Wizard :: read() 
{
		    int wType,wLvl, pLvl;
			string name;
			
			cout << "Enter Name: ";
			cin >> name;
			Player::set_PlayerName(name);
		
			//cout << "Enter warrior type:(1) Warrior (2) Wizard (3) Vampire (4) Sorceress: ";
			//cin >> pType;
			//set_PlayerType(pType);
		
			cout << "Enter Wizard level (1-100): ";
			cin >> pLvl ;
			Player::set_PlayerLevel(pLvl);
		
			//cout << "Enter player strength (1-100): ";
		   // cin >> pStr;
			//Player::set_PlayerStrength(pStr);
		
			cout << "Enter weapon type:(1)lightning bolt (2)Fireballs: ";
			cin >> wType;
			setWeaponType(wType);
		
			//cout << "Enter weapon durability (0-100): ";
			//cin >> wDurab;
			//setWeaponDurability(wDurab);
			
			cout << "Enter weapon level required: (Greater than 0):  ";
			cin >> wLvl;
			setWeaponLevelRequired(wLvl);
			

}

void Wizard :: display() const
		{
			
			cout << "Player type WIZARD" << endl
			     << "Name: " << get_PlayerName() << endl  
			     << "Player Level: " << get_PlayerLevel() << endl 
				 << "Strength level: " << get_PlayerStrength() << endl;
			if(getWeaponType() == 1)
			{
				cout << "Weapon type: lightning bolt " << endl;
			}
			else
			{
				cout << "Weapon type: fireball" << endl;
			} 
			
			cout  << "Weapon durability: " << getWeaponDurability() << endl 
			      << "Level required to use: " << getWeaponLevelRequired() << endl;
			cout << "Special: Stun duration = " << special << " seconds" << endl;
			
		}



int Wizard::getWeaponType() const
{
	return weapon1->get_type();
}

void Wizard :: setWeaponType(int wt)
{
	weapon1->set_type(wt);
}

void Wizard :: setWeaponDurability(int wd)
{
	weapon1->set_durability(wd);
}

int Wizard :: getWeaponDurability() const
{
	return weapon1->get_durability();
}

void Wizard :: setWeaponLevelRequired(int lr)
{
	weapon1->set_levelRequired(lr);
}

int Wizard :: getWeaponLevelRequired() const
{
	return weapon1->get_levelRequired();
}

void Wizard :: setSpecial(int sp)
{
	special = sp;
}