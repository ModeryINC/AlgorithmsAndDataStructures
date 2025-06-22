#ifndef FUNCTIONS
#define FUNCTIONS

#include<algorithm>
#include <thread>
#include<vector>
#include<chrono>

#include"../Characters/Player.h"
#include"../Characters/Enemy.h"
#include"RandomGenerator.h"
#include"struct.h"

vector<int> getNeighbors(const vector<connection>& connections, int vertexId);
bool isNeighbor(const vector<int>& neighbors, int vertexId);
void fight(Player& player, int vertexId, int stage);
void chest(Player& player, int vertexId);
void shop(Player& player, int vertexId);

#endif