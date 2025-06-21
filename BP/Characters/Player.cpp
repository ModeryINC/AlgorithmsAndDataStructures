#include<iostream>
#include<string>

#include"../Utilities/struct.h"
#include"Character.h"
#include"Player.h"

using namespace std;

Player::Player(int id, int health, int mana, int stamina, string name)
: Character(id, health, mana, name), maxStamina(stamina), currentStamina(stamina) {
    if(stamina < 0)
        throw out_of_range("Stamina must be greater than 0!");
}

bool Player::buy(const item& newWeapon) {
    if (newWeapon.buyCost > coins) {
        cout << "Nie masz wystarczająco monet!" << endl;
        return false;
    }
    cout << "Sprzedano aktualna bron (" << weapon.name << ") za " << weapon.sellCost << " monet." << endl;
    coins += weapon.sellCost;
    coins -= newWeapon.buyCost;
    weapon = newWeapon;
    cout << "Wyposazono nowa bron: " << newWeapon.name << endl;
    cout << "Pozostalo monet: " << coins << endl;
    return true;
}
