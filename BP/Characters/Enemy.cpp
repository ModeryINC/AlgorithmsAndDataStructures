#include<iostream>
#include<string>

#include"../Utilities/struct.h"
#include"Player.h"
#include"Enemy.h"

using namespace std;

stats::stats(int id, int health, int mana, int cashDrop, int damage, string name)
: id(id), health(health), mana(mana), cashDrop(cashDrop), name(name), damage(damage) {}

stats Enemy::resolveValue (int id, Types type) {
    switch (type) {
    case Types::CuSith:
        return {id, 130, 1, 10, 4, string("Cu Sith")};
        break;
    case Types::Gwyllion:
        return {id, 100, 1, 8, 5, string("Gwyllion")};
        break;
    case Types::Banshee:
        return {id, 35, 1, 11, 15, string("Banshee")};
        break;
    case Types::Dullahan:
        return {id, 120, 1, 12, 3, string("Dullahan")};
        break;
    default:
        throw invalid_argument("Enemy: Wrong Type!");
    }
}

Enemy::Enemy(int id, int health, int mana, int cashDrop, int damage, string name)
: Character(id, health, mana, name), damage(damage), cashDrop(cashDrop) {}

Enemy::Enemy(int id, Types type)
: Enemy(resolveValue(id, type)) {}

Enemy::Enemy(stats s)
: Character(s.id, s.health, s.mana, s.name), cashDrop(s.cashDrop), damage(s.damage) {}