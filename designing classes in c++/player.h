//  ****************************************************************************
//  Name:Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: player.h
//  Compiler Used: VS 2012
//  ****************************************************************************

//  Compiler directives
#ifndef PLAYER_H
#define PLAYER_H

#include <iostream>
#include "weapon.h"


using namespace std;

int checkPType(int);
int checkPLevel(int);
int checkPStrength(int);

// Class definitions and function prototypes go here
class Player
{
public:
	

	Player(string pn = "No Name", int lev = 1, int str = 25, int wty = 1, int wdur = 25, int wlevReq = 1,bool stat = true);
	
	~Player();

	virtual void read() = 0;
	
	void operator += (const int lev);

	bool operator >= ( Player &);

	void operator = (Player &);

	friend ostream & operator << (ostream & out, const Player * p1);

	friend istream & operator >> (istream & in, Player * p1);

	virtual void display() const = 0;
	
	
	void set_PlayerName(string);


	void set_PlayerLevel(int);

	void set_PlayerStrength(int);

	void set_status(bool);
	
    virtual void setWeaponType(int)=0;

	virtual void setWeaponDurability(int)=0;

	virtual void setWeaponLevelRequired(int)=0;
	


	virtual int getWeaponType() const=0;

	virtual int getWeaponDurability() const=0;

	virtual int getWeaponLevelRequired() const=0;

	string get_PlayerName() const;



	int get_PlayerLevel() const;

	int get_PlayerStrength() const;

	bool get_status() const;


private:
	Weapon* weapon2;
	string playerName;
	
	int level;
	int strength;
	bool status;

};



// end of the compiler directives
#endif
