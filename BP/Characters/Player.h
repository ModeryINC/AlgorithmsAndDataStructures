#ifndef PLAYER
#define PLAYER

#include<iostream>
#include<string>

#include"../Utilities/struct.h"
#include"Character.h"

using namespace std;

class Player : public Character {
    private:
        int maxStamina, currentStamina;
        item weapon = item(7777, "Pala", 7, 0, 0);
        int coins = 100;
    public:
        Player(int id, int health, int mana, int stamina, string name);
        bool buy(const item& newWeapon);
        void addCoins(int amount) { coins += amount; }
        int getCoins() const { return coins; }
        item getWeapon() const { return weapon; }
        int getDamage() const { return weapon.damage; }
};

#endif