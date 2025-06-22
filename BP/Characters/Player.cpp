#include<iostream>
#include<string>

#include"../Utilities/struct.h"
#include"Character.h"
#include"Player.h"

using namespace std;

Player::Player(int id, int health, int mana, int stamina, string name)
: Character(id, health, mana, name), maxStamina(stamina), currentStamina(stamina) {
    if (stamina < 0)
        throw out_of_range("Plyer: Stamina must be greater than 0!");
}

bool Player::buy(const item& newWeapon) {
    if (newWeapon.buyCost > coins) {
        cout << "\033[31mNie masz wystarczająco monet!\033[0m\n";
        return false;
    }
    cout << "Sprzedano aktualna bron (\033[95m" << weapon.name << "\033[0m) za \033[33m" << weapon.sellCost << "\033[0m monet.\n";
    coins += weapon.sellCost;
    coins -= newWeapon.buyCost;
    weapon = newWeapon;
    cout << "Wyposazono nowa bron: \033[35m" << newWeapon.name << "\033[0m\n";
    cout << "Pozostalo monet: \033[33m" << coins << "\033[0m\n";
    return true;
}
