#include<iostream>
#include<string>

#include"Character.h"

using namespace std;

Character::Character (int id, int health, int mana, string name)
: id(id), maxHealth(health), currentHealth(health), maxMana(mana), currentMana(mana), name(name) {
    if(maxHealth <= 0 || maxMana <= 0)
        throw out_of_range("Mana and Health cannot be less than 1!");
    if(name.empty())
        throw invalid_argument("Name cannot be empty!");
}

Character::Character (int maxHealth, int currentHealth, int maxMana, int currentMana, string name) : id(id) {
    if(maxHealth <= 0 || currentHealth <= 0 || maxMana <= 0 || currentMana < 0)
        throw out_of_range("Mana and Health cannot be less than 0 (or equal)!");
    if(name.empty())
        throw invalid_argument("Name cannot be empty!");
    this->maxHealth = maxHealth;
    this->currentHealth = maxHealth;
    this->maxMana = maxMana;
    this->currentMana = maxMana;
    this->name = name;
}