//  ****************************************************************************
//  Name:Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: wizard.h
//  Compiler Used: VS 2012
//  ****************************************************************************

//  Compiler directives
#ifndef WIZARD_H
#define WIZARD_H

#include <iostream>
#include "player.h"
#include "weapon.h"

using namespace std;



// Class definitions and function prototypes go here
class Wizard: public Player
{
public:
	//  Constructor ***********************************************************
	//  Uses default parameters or arguments passed
	//  Default arguments = No Name-nm, 1-lev, 25-str, 1-wty, 1-wdur, 1 wlevReq, true-st
	//  Precondition - None
	//  Postcondition - object is initialized with valid values
	Wizard(string nm = "No name" , int lev = 1, int str = 25, int wty = 1, int wdur = 25, int wlevReq = 1,bool st = true,int sp = 3);
	
	//  Destructor ************************************************************
	//  Precondition - None
	//  Postcondition - None
	~Wizard();
	
	//All virtually derived class functions from the player class.
	virtual void display() const;

	virtual void read();


	virtual void setWeaponDurability(int);

	virtual void setWeaponLevelRequired(int);
	
	virtual void setWeaponType(int);
	
	void setSpecial(int);


	virtual int getWeaponDurability() const;

	virtual int getWeaponLevelRequired() const;
	
	virtual int getWeaponType() const;

	
	
	

	
	
private:
	Weapon* weapon1;
	int special;
	
};



// end of the compiler directives
#endif
