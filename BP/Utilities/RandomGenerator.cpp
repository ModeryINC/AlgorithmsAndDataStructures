#include <random>

#include"RandomGenerator.h"

using namespace std;

RandomGenerator::RandomGenerator(int min, int max)
: gen(random_device{}()), dist(min, max) {}

int RandomGenerator::next() { return dist(gen); }

int RandomGenerator::dynamicGenerator(int min, int max) {
    mt19937 gen(random_device{}());
    uniform_int_distribution<> dist(min, max);
    return dist(gen);
}
