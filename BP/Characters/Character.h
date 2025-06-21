#ifndef CHARACTER
#define CHARACTER

#include<iostream>
#include<string>

using namespace std;

class Character {
    protected:
        const int id;
        int maxHealth, currentHealth,
            maxMana, currentMana;
        string name;
        Character (int id, int health, int mana, string name);
    public:
        Character (int maxHealth, int currentHealth, int maxMana, int currentMana, string name);
        void takeDamage(int dmg) { currentHealth -= dmg; }
        int getHealth() const { return currentHealth; }
        string getName() { return name; }
};

#endif