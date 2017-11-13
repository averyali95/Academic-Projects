/*
****************************************************************************
Name: Avery Ali
Date: 5/1/14
COMSC 110 Computer Programming II
Assignment: 18
File Name: Designing Classes.cpp
Compiler Used: VS 2012
****************************************************************************

Problem Statement **********************************************************
   Use class inheritance (“is a”, derived class), composition (“has a”, container class), field and base class initialization, 
	polymorphic vector with pointers and virtual functions.  


Data Requirements **********************************************************
	int playernum, 

Algorithm Design ***********************************************************
    . Create overloaded >> operator functions to behave the same as the read functions. 
	. Create overloaded << operator functions to behave the same as the display functions. 
	. Create an overloaded += operator function which can be used when randomly 
	  modifying levels during game play. 
	. Create overloaded >= operator functions which can be used to compare the strength 
	  of 2 players. This would be used if there is no designated winner, one with a level >= 
	  200, to find the player with the highest positive level which will then be the winner. If 
	  any two player objects have equal level values, randomly generate a positive number 
	  for each and add it to their levels. Then the one with the greater level will the winner. 
	. Create an overloaded = operator function which can assign a derived class object to 
   	  another derived class object. These should only assign the level, strength and status 
	  data members that are in the base class.
Testing Specifications *****************************************************
     Name: Avery
     Player type: 2
	 Player Level:  99
	 Strength level:  99
	 Weapon type: 3
	 Weapon durability: 99
     Level required to use: 40


*/
// End of documentation

// Compiler directives : libraries and namespaces **************************

#include <iostream>
#include <string>
#include <vector>
#include <cstdlib>
#include <ctime>
#include "player.h"
#include "weapon.h"
#include "wizard.h"
#include "warrior.h"
using namespace std;

void instruct();
int generateRandomNumber(const int min, const int max);
int playerAmount();
// main function ***********************************************************

int main ()
{
	srand (time(0));

	int playersNum;
	
	vector<Player*> warriors;

	instruct();

	playersNum = playerAmount();

	for(int i = 0; i < playersNum; i++)
	{
		int answer;
		do
		{
		cout << "Press (1) to be a wizard, (2) to be a warrior: ";
		cin >> answer;
		} while(answer < 1 || answer > 2);
		
		if(answer==1)
		{
			warriors.push_back(new Wizard());
		}

		else
		{
			warriors.push_back(new Warrior());
		}
		
		cin >> warriors[i];
		cout << endl;

		

	}

	


	for(int k = 0; k < 20; k++)
	{
	
		for(int i = 0; i < playersNum; i++)
		{
			if(warriors[i]->get_status() == true)
			{
			/////////////////////////////////STRENGTH//////////////////////////////
				int strengthbefore = warriors[i]->get_PlayerStrength(); 
				int strengthafter;
		
				warriors[i]->set_PlayerStrength(strengthbefore + generateRandomNumber(-20,20)); //generate new random strength
				strengthafter= warriors[i]->get_PlayerStrength();   //set the new strength so we can compare it to before 
				
				if(strengthafter > strengthbefore+14) // if the new strength is 15 higher thand the old, then we raise their level
				{
					warriors[i] += 1;
				}
	
				if(warriors[i]->get_PlayerStrength() <= 0 ) //if their strength drops bellow 0 they are out
				{
						warriors[i]->set_status(false);
						cout << "Player " << i+1 << " you are out! ";
						
				 }
			   
			  
///////////////////////////////////////Weapon durability/////////////////////////////////////////////
			
			
				int weaponDbefore = warriors[i]->getWeaponDurability(); //get their weapon durability and set it to a variable
	
				warriors[i]->setWeaponDurability(weaponDbefore + generateRandomNumber(-10,10)); //generate and set their new random weapon durab level
	
				if(warriors[i]->getWeaponDurability() <= 0) //if their durability becomes less than 0 they are out
				{
					if(warriors[i]->get_status() == true)
					{
						warriors[i]->set_status(false);
					    cout << "Player " << i+1 << " you are out! ";
						
					}
				}

				cout << warriors[i] <<endl;
			 
				
			
			 }//end of if
		
			
		
		}//end of for
	
		
	}//end of big for
	cout << endl;
	for(int i=0; i < playersNum; i++)
			{
				if(warriors[i]->get_status() == true)
					{
						if(warriors[i]->get_PlayerStrength() > 199 && warriors[i]->getWeaponDurability() > 0) //check for automatic winner
						{
							cout << "Player " << i+1 << " is the winner!!" << endl;
							break;
						}
				    
						if(warriors[i]->get_PlayerLevel() > 0)
						{

							double highest = warriors[0]->get_PlayerStrength();  //compares all the players strengths if they are left in the game
							
							for (int i = 1; i < warriors.size(); i++)
						    {
									 if (warriors[i]->get_PlayerStrength() > highest)
									 {
										 highest = warriors[i]->get_PlayerStrength();
									 }
							 }
	 
							 for (int i = 0; i < warriors.size(); i++) //displays winner if one
							 {  
							    if (warriors[i]->get_PlayerStrength() == highest)
								{
									
									cout << "Winner: Player "<< i+1 << " with " << warriors[i]->get_PlayerStrength() << " strength!"<< endl;
									cout << warriors[i];
									cout << endl;
								}
	
						     }
	
							 for (int i = 0; i < warriors.size(); i++) //displays losers
							 {
								if (warriors[i]->get_PlayerStrength() != highest)
								{
									
									cout << "LOSER" << endl;
									cout << warriors[i];
									cout << endl;
								}
							 
							 }
						     break;
						}
						else 
						{	//displays if there are no winners
							cout << "No winners " ;
							break;
						}
						
					}//ends if(warriors[i]->get_status() == true)

				
			}//ends entire for loop
	
	
	
	
	for(int i = 0; i < playersNum; i++) //pointer cleanup
	{
		if (warriors[i] != NULL)
		{
			delete warriors[i];
			warriors[i] = NULL;
		}
	}
	
	// End of program statements
	cout << "Please press enter once or twice to continue...";
	cin.ignore().get();    			// hold console window open
	return EXIT_SUCCESS;           	// successful termination
    
}
// end main() **************************************************************

void instruct()
{
	cout << "Welcome to the warriors game!" << endl 
		 << "You will choose a name and have some of your atributes chosen" << endl
		 << "for you. The person with the highest strength wins, if your " <<endl
		 << "strength or weapon durability at any time becomes less than 0," << endl
		 << "you are out. These numbers will be randomly generated for you. " << endl
		 << "If everyone's strength is below zero the highest one will win. "<< endl
		 << "You start off with 25 strength and 25 weapon durability. Good luck" << endl;
}

int generateRandomNumber(const int min, const int max)
{
	return min + rand() % (max-min-1);
}

int playerAmount()
{
	int num;
	cout << "How many players are there? [1-10] 0 to exit: ";
	cin >> num;
	while (num < 0 || num > 10)
	{
		cout << "Enter a valid number [1-10] 0 to exit: ";
		cin >> num;
	}
	if(num == 0)
	{
		cout << "Good bye!" << endl;
		return 0;
	}
	else
		return num;

}