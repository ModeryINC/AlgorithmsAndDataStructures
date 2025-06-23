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
    for (int i = 0; i < (stage + 5); i++) {
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
    for (int i = 0; i < (stage + 1); i++) {
        RandomGenerator vertexGenerator(0, (stage + 4));
        RandomGenerator weigthGenerator(1, 11);
        int v1 = 0, v2 = 0;
        bool isConnectionDifrent = false;
        while (!isConnectionDifrent) {
            while (v1 == v2) {
                v1 = vertexGenerator.next();
                v2 = vertexGenerator.next();
            }
            vector<connection> connections = output.getConnections();
            bool isInConnections = false;
            for (connection c : connections)
                if (c.start.id == v1 && c.end.id == v2 || c.start.id == v2 && c.end.id == v1)
                    isInConnections = true;
            
            if (!isInConnections) {
                output.addConnection(v1, v2, weigthGenerator.next());
                isConnectionDifrent = true;
            }
        }
    }
    return output;
}