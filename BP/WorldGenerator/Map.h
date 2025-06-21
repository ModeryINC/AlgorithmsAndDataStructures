#ifndef MAP
#define MAP

#include<set>

#include"../Utilities/RandomGenerator.h"
#include"../Utilities/struct.h"
#include"Graph.h"

using namespace std;

class Map : public Graph {
    private:
        const int stage;
        set<int> visitedVertex;
    public:
        Map(int stage) : Graph(), stage(stage <= 0 ? 1 : (stage < 5 ? stage : 5)) {};
        static Map generateMap(int level);
};

#endif