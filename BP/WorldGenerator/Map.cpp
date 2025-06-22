#include<iostream>
#include<set>

#include"../Utilities/RandomGenerator.h"
#include"Map.h"

using namespace std;

Map Map::generateMap(int stage) {
    stage = stage < 1 ? 1 : stage;
    Map output(stage);
    RandomGenerator typeGenerator(1, 100);
    RandomGenerator weigthGenerator(1, 11);
    const int typesLength = 4;
    const pair<string, int> types[typesLength] = {
        {"Chest", 20},
        {"Fight", 65},
        {"Shop", 81},
        {"Empty", 100}
    };
    int num = stage + 5;
    for (int i = 0; i < num; i++) {
        // cout << "Generowanie wierzcholka!\n";
        int num = typeGenerator.next();
        try {
            for (int j = 0; j <= typesLength; j++) {
                if (num <= types[j].second) {
                    // cout << i << ") Przeszlo!\n";
                    output.addVertex(i == 0 && j == 1 ? types[2].first : types[j].first);
                    break;
                }
            }
        } catch (...) {}
        if(i == 0) continue;
        num = i == 1 ? 0 : RandomGenerator::dynamicGenerator(0, i-1);
        output.addConnection(num, i, weigthGenerator.next());
        // cout << "Dodano polaczenie!\n";
    }
    return output;
}