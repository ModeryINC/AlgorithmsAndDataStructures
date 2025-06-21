#ifndef RANDOMGENERATOR
#define RANDOMGENERATOR

#include <random>

using namespace std;

class RandomGenerator {
    mt19937 gen;
    uniform_int_distribution<> dist;
public:
    RandomGenerator(int min, int max);
    int next();
    static int dynamicGenerator(int min, int max);
};

#endif