//  ****************************************************************************
//  Name:Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: weapon.h
//  Compiler Used: VS 2012
//  ****************************************************************************

//  Compiler directives
#ifndef WEAPON_H
#define WEAPON_H

#include <iostream>

using namespace std;

int checkType(int);
int checkDurability(int);
int checkLevel(int);

// Class definitions and function prototypes go here
class Weapon
{
public:
	Weapon();

	Weapon(int ,int ,int );


	void set_type(int);

	void set_durability(int);

	void set_levelRequired(int);

	int get_type() const;

	int get_durability() const;

	int get_levelRequired() const;

	
private:
	int type;
	int durability;
	int levelRequired;

};



// end of the compiler directives
#endif











