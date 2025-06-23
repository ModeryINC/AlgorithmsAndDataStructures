#include <windows.h>
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
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);
        
        cout << "\033[36m⋊⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋉\n"
            << "※    CELTIC  GAME   ※\n"
            << "⋊⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋈⋉\033[0m\n";
        
        bool end = false;
        int stage = 1;
        string username;
        
        cout << "Podaj swoja nazwę: ";
        cin >> username;
        
        Player player(0, 100, 100, 100, username);
        
        cout << player.getName() << " \033[32m"
            << player.getHealth() << "hp. \033[31m"
            << player.getDamage() << "dmg. \033[0m";
        // cout << "Gracz utworzony!\n";
        
        while (!end) {
            Map map = Map::generateMap(stage);
            
            // cout << "Mapa wygenerowana!\n";
            
            const vector<vertex>& vertices = map.getVertices();
            const vector<connection>& connections = map.getConnections();
            
            // cout << "Pobrano wierzcholki i polaczenia!\n";
            
            cout << "\n\033[36m⋊⋈⋈⋉ POZIOM " << stage << " ⋊⋈⋈⋉\033[0m\n\n";
            
            int current = vertices.front().id;
            set<int> visited;
            
            while (visited.size() < vertices.size()) {
                auto it = find_if(vertices.begin(), vertices.end(),
                    [current](const vertex& v) { return v.id == current; });
                    
                if (it == vertices.end()) 
                    throw runtime_error("Map error!");
                
                const vertex& v = *it;
                
                cout <<"\nJesteś na polu: \033[36m" << v.id << ") "
                    << v.name << " (" << v.type << ")\033[0m\n";
                
                if (visited.find(current) == visited.end()) {
                    if (v.type == "Fight")
                        fight(player, v.id, stage);
                    else if (v.type == "Chest")
                        chest(player, v.id);
                    else if (v.type == "Shop")
                        shop(player, v.id);
                    else cout << "\033[92mTo pole jest puste.\033[0m\n";
                } else cout << "\033[92mTo pole jest puste.\033[0m\n";
                
                visited.insert(current);
                
                if (visited.size() == vertices.size()) break;
                
                vector<int> neighbors = getNeighbors(connections, current);
                
                while (true) {
                    cout << "Możliwe ruchy: ";
                    for (int n : neighbors) {
                        if(visited.find(n) != visited.end())
                            cout << "\033[35m";
                        cout << n << "\033[0m ";
                    }
                    
                    string answer;
                    cout << "\nWybierz pokój: ";
                    cin >> answer;
                    
                    try {
                        int next = stoi(answer);
                        
                        if (isNeighbor(neighbors, next)) {
                            current = next;
                            break;
                        } else cout << "\033[31mNieprawidłowy ruch, sprobuj ponownie.\033[0m\n";
                    } catch (...) {}
                }
            }
            cout << "\n\033[32mGratulacje! Odwiedziłeś wszystkie pola!\033[0m\n";
            string answer;
            cout << "Czy chcesz przejść na wyzszy pozom? t/n\n";
            cin >> answer;
            
            if (answer != "t" || answer != "T" || answer != "tak")
                end == true;
            stage++;
        }
        cout << "\n\n\033[32mKoniec! Przeszedłeś " << stage - 1 << " poziomy!\033[0m\n\n";
        return 0;
    } catch (const exception& e) {
        cout << "\n\n\033[31mError Occurred: " << e.what() << "\033[0m\n";
    }
}