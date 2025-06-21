#ifndef ENEMY
#define ENEMY

#include<iostream>
#include<string>

#include"../Utilities/struct.h"
#include"Player.h"

using namespace std;

struct stats {
    int id, health, mana, cashDrop, damage;
    string name;
    stats(int id, int health, int mana, int cashDrop, int damage, string name);
};


class Enemy : public Character {
    public:
        enum Types {
            CuSith,
            Gwyllion,
            Banshee,
            Dullahan
        };
    private:
        int damage;
        int cashDrop;
        static stats resolveValue (int id, Types type);
    public:
        Enemy(int id, int health, int mana, int cashDrop, int damage, string name);
        Enemy(int id, Types type);
        Enemy(stats s);
        int getDamage() { return damage; }
};

#endif