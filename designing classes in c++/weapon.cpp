//  ****************************************************************************
//  Name: Avery Ali
//  Date: 4/15/14
//  COMSC 110 Computer Programming II
//  Assignment: 16
//  File Name: weapon.cpp
//  Compiler Used: VS 2012
//  ****************************************************************************

//  Compiler directives ********************************************************
#include <iostream>
#include "weapon.h"
using namespace std;



//  Class member function implementations **************************************

/*
Weapon() function specifications
Prototype: weapon();
Precondition: none
Postcondition: none
Algorithm: 
1. set default values for weapon type,durability, and levelrequired

*/
Weapon :: Weapon()
{
	type = 1;
	durability = 25;
	levelRequired = 1;
}



/*
weapon(int weaponType, int weaponDurability, int weaponlevel) function specifications
Prototype: weapon(int,int,int);
Precondition: pass three int values
Postcondition: none
Algorithm: 
1. check to see if the three values are valid then store the valid number in private memory

*/
Weapon :: Weapon(int weaponType,int  WeaponDurabilty, int  WeaponLevel)
{
	type = checkType(weaponType);
	durability = checkDurability(WeaponDurabilty);
	levelRequired = checkLevel(WeaponLevel);
}

/*
get_type() function specifications
Prototype: int get_type() const;
Precondition: none
Postcondition: return the type of weapon
Algorithm: 
1. return weapon type 

*/
int Weapon :: get_type() const
{
	return type;
}

/*
get_durability() function specifications
Prototype: int get_durability() const;
Precondition: none
Postcondition: return the durability of weapon
Algorithm: 
1. return weapon durability 

*/
int Weapon :: get_durability() const
{
	return durability;
}

/*
get_levelRequired() function specifications
Prototype: int get_levelRequired() const;
Precondition: none
Postcondition: return the level required to use weapon
Algorithm: 
1. return level required to use weapon

*/
int Weapon :: get_levelRequired() const
{
	return levelRequired;
}

/*
set_type(int ty) function specifications
Prototype: void set_type(int);
Precondition: have int value passed
Postcondition: set valid number to type
Algorithm: 
1. check to see if value is valid, if so set it equal to type

*/
void Weapon :: set_type( int ty)
{
	type = checkType(ty);
}

/*
set_durability(int db) function specifications
Prototype: void set_durability(int);
Precondition: have int value passed
Postcondition: set valid number to durability
Algorithm: 
1. check to see if value is valid, if so set it equal to durability

*/
void Weapon :: set_durability( int db)
{
	durability = checkDurability(db);
}

/*
set_levelRequired(int lr) function specifications
Prototype: void set_levelRequired(int);
Precondition: have int value passed
Postcondition: set valid number to levelRequired
Algorithm: 
1. check to see if value is valid, if so set it equal to levelRequired

*/
void Weapon :: set_levelRequired( int lr)
{
	levelRequired = checkLevel(lr);
}
// Non-member function implementations *****************************************

/*
checkType(int wType); function specifications
Prototype: int checkType(int);  
Precondition: have an int value passed
Postcondition: return a valid number (int)
Algorithm: 
1. using a while loop, check to see if the weapon type is between 1 and 4 inclusive.
1.2 if not, loop until they enter a valid number
2. return valid weapon type

*/
int checkType(int wType)
{
	
		while(wType < 1 || wType > 2)
			{
				cout << "Enter a valid weapon type: ";
				cin >> wType;
			}
		return wType;
	
}

/*
checkDurability(int wDurability); function specifications
Prototype: int checkDurability(int);  
Precondition: have an int value passed
Postcondition: return a valid number (int)
Algorithm: 
1. using a while loop, check to see if the player type is between 1 and 100 inclusive.
1.2 if not, loop until they enter a valid number
2. return valid weapon durability

*/
int checkDurability(int wDurability)
{
	
	while(wDurability < -110 || wDurability > 100)
		{
			cout << "Enter a valid weapon durability that is greater than 0 and less than or equal to 100: ";
			cin >> wDurability;
		}

	return wDurability;

}

/*
checkLevel(int wLevel); function specifications
Prototype: int checkLevel(int);  
Precondition: have an int value passed
Postcondition: return a valid number (int)
Algorithm: 
1. using a while loop, check to see if the player type is greater than 0.
1.2 if not, loop until they enter a valid number
2. return valid weapon level

*/
int checkLevel(int wLevel)
{
	
	while(wLevel < 1)
		{
			cout << "Enter a valid weapon level greater than 0: ";
			cin >> wLevel;
		}

	return wLevel;

}