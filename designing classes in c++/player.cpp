//  ****************************************************************************
//  Name: Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: player.cpp

//  Compiler Used: VS 2012
//  ****************************************************************************

//  Compiler directives ********************************************************
#include <iostream>
#include <string>
#include "player.h"
#include "weapon.h"
using namespace std;



//  Class member function implementations **************************************


/*
Player(name,wep,type,lvl,str,stat) function specifications
Prototype: Player(string,Weapon,int,int,int);
Precondition: Have user pick name, create a weapon, pick player type, level, and strength and pass into function
Postcondition: set private data values to those passed
Algorithm: 
1. Set player name to the name that was passed
2. set the weapon to the weapon the user passes
3. Set type to the type that the user chose
4. Set strength to what the user chose
5. Set the level to what the user chose
6. set the status to whatever is passed

*/
Player::Player(	string pn, int lev, int str, int  wty, int wdur, int wlevReq,bool stat)		
		{
			set_PlayerName(pn);
			//set_PlayerType(ty);
			set_PlayerLevel(lev);
			set_PlayerStrength(str);
			set_status(stat);
		    weapon2 = new Weapon(wty,wdur,wlevReq);
		}
		
		
//  Destructor ************************************************************
	//  Precondition - None
	//  Postcondition - None
Player::~Player()
		{
			if ( weapon2 != NULL )
			{	 
				delete weapon2;
				weapon2 = NULL;
			}
		
		}


ostream & operator << (ostream & out, const Player * p1)
{
	p1->display();
	return out;
}

istream & operator >> (istream & in, Player * p2)
{
	p2->read();
	return in;
}

void Player:: operator += (const int lev)
{
	set_PlayerLevel(get_PlayerLevel()+lev);
}

bool Player:: operator >= ( Player & p2)
{
	return (get_PlayerStrength() >= p2.get_PlayerStrength());
}

void Player:: operator = (Player & p3)
{
	level= p3.get_PlayerLevel();
	strength=p3.get_PlayerStrength();
	status = p3.get_status();
}




/*
get_PlayerName() function specifications
Prototype: string get_PlayerName() const;
Precondition: none
Postcondition: return pLayerName
Algorithm: 
1. return the playername that is stored in the private memory

*/
string Player :: get_PlayerName() const
{
	return playerName;
}


/*
get_PlayerLevel() function specifications
Prototype: int get_playerLevel() const;
Precondition: none
Postcondition: return level
Algorithm: 
1. return the level that is being stored in private data

*/
int Player :: get_PlayerLevel() const
{
	return level;
}

/*
get_PlayerStrength() function specifications
Prototype: int get_PlayerStrength() const;
Precondition: none
Postcondition: return strength
Algorithm: 
1. retunr strength found in private data

*/
int Player :: get_PlayerStrength() const
{
	return strength;
}

bool Player :: get_status() const
{
	return status;
}


/*
set_PlayerName(string pn) function specifications
Prototype: void set_PlayerName(string);
Precondition: string must be passed.
Postcondition: set playerName in private data to the string passed
Algorithm: 
1. Set playerName = to what user passed.

*/
void Player :: set_PlayerName(string pn)
{
	playerName = pn;
}



/*
set_PlayerLevel(int pl) function specifications
Prototype:  void set_PlayerLevel(int);
Precondition:  must have an int value passed
Postcondition: call checkPLevel function to validate number passed
Algorithm: 
1. Check player level, then set Level to the number returned from the checker

*/
void Player :: set_PlayerLevel(int pl)
{
	level = checkPLevel(pl);
}

/*
set_PlayerStrength(int ps) function specifications
Prototype:  void set_PlayerStrength(int);
Precondition:  must have an int value passed
Postcondition: call checkPStrength function to validate number passed
Algorithm: 
1. Check player strength, then set strength to the number returned from the checker

*/
void Player :: set_PlayerStrength(int ps)
	{
		strength = checkPStrength(ps);
	}

void Player :: set_status(bool st)
{
	status = st;
}



// Non-member function implementations *****************************************

/*
checkPStrength(int Pstr); function specifications
Prototype: int checkPStrength(int);  
Precondition: have an int value passed
Postcondition: return a valid number (int)
Algorithm: 
1. using a while loop, check to see if the player strength is between 1 and 100 inclusive.
1.2 if not, loop until they enter a valid number
2. return valid player strength

*/
int checkPStrength(int Pstr)
{
	while(Pstr <  -100 || Pstr > 300)
		{
			cout << "Enter a valid strength that is greater than 0 and less than or equal to 100: ";
			cin >> Pstr;
		}

	return Pstr;

}

/*
checkPLevel(int Plvl); function specifications
Prototype: int checkPLevel(int);  
Precondition: have an int value passed
Postcondition: return a valid number (int)
Algorithm: 
1. using a while loop, check to see if the playe's level is between 1 and 100 inclusive.
1.2 if not, loop until they enter a valid number
2. return valid player level

*/
int checkPLevel(int Plvl)
{
	while(Plvl <=  0 || Plvl > 100)
		{
			cout << "Enter a valid player level that is greater than 0 and less than or equal to 100: ";
			cin >> Plvl;
		}

	return Plvl;

}