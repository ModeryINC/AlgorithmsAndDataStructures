#include<algorithm>
#include<iostream>
#include<memory>
#include<vector>
#include<set>
#include<map>

#include"./Utilities/RandomGenerator.h"
#include"./Utilities/functions.h"
#include"./WorldGenerator/Map.h"
#include"./Characters/Player.h"
#include"./Characters/Enemy.h"
#include"./Utilities/struct.h"

using namespace std;

int main() {
    try {
        string username;
        cout << "Podaj swoja nazwe: ";
        cin >> username;
        Map map = Map::generateMap(1);
        cout << "Mapa wygenerowana!\n";
        Player player(0, 100, 100, 100, username);
        cout << "Gracz utworzony!\n";
        const vector<vertex>& vertices = map.getVertices();
        const vector<connection>& connections = map.getConnections();
        cout << "Pobrano wierzcholki i polaczenia!\n";
        int current = vertices.front().id;
        set<int> visited;
        while (visited.size() < vertices.size()) {
            auto it = find_if(vertices.begin(), vertices.end(), [current](const vertex& v) { return v.id == current; });
            if (it == vertices.end()) {
                cout << "Blad mapy!" << endl;
                break;
            }
            const vertex& v = *it;
            cout << "\nJestes na polu: " << v.name << " (" << v.type << ")" << endl;
            if(visited.find(current) == visited.end()) {
                if (v.type == "Fight")
                    fight(player, v.id);
                else if (v.type == "Chest")
                    chest(player, v.id);
                else if (v.type == "Shop")
                    shop(player, v.id);
                else cout << "To pole jest puste." << endl;
            } else cout << "To pole jest puste." << endl;
            visited.insert(current);
            if (visited.size() == vertices.size()) break;
            vector<int> neighbors = getNeighbors(connections, current);
            cout << "Mozliwe ruchy: ";
            for (int n : neighbors) {
                cout << n << " ";
            }
            cout << "\nWybierz id sasiada: ";
            int next;
            cin >> next;
            if (find(neighbors.begin(), neighbors.end(), next) != neighbors.end()) {
                current = next;
            } else {
                cout << "Nieprawidlowy ruch, sprobuj ponownie." << endl;
            }
        }
        cout << "\nGratulacje! Odwiedziles wszystkie pola!" << endl;
        return 0;
    } catch(const exception& e) {
        cout << e.what();
    }
}