#include<set>

#include"../Utilities/RandomGenerator.h"
#include"Map.h"

Map Map::generateMap(int stage) {
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
    for(int i = 0; i < 5 + stage; i++) {
        // cout << "Generowanie wierzcholka!\n";
        int num = typeGenerator.next();
        try {
            for(int j = 0; j < typesLength; j++) {
                if(num < types[j].second) {
                    // cout << i << ") Przeszlo!\n";
                    output.addVertex(types[j].first);
                    break;
                }
            }
        } catch(...) {}
        if(i == 0) continue;
        num = i == 1 ? 0 : RandomGenerator::dynamicGenerator(0, i-1);
        output.addConnection(num, i, weigthGenerator.next());
        // cout << "Dodano polaczenie!\n";
    }
    return output;
}