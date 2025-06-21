#include<algorithm>
#include <thread>
#include<vector>
#include<chrono>

#include"../Characters/Player.h"
#include"../Characters/Enemy.h"
#include"RandomGenerator.h"
#include"functions.h"
#include"struct.h"

vector<int> getNeighbors(const vector<connection>& connections, int vertexId) {
    vector<int> neighbors;
    for (const auto& conn : connections) {
        if (conn.start.id == vertexId) neighbors.push_back(conn.end.id);
        if (conn.end.id == vertexId) neighbors.push_back(conn.start.id);
    }
    sort(neighbors.begin(), neighbors.end());
    neighbors.erase(unique(neighbors.begin(), neighbors.end()), neighbors.end());
    return neighbors;
}

void fight(Player& player, int vertexId) {
    int enemyCount = RandomGenerator::dynamicGenerator(1, 3);
    cout << "Walka! Przeciwnikow: " << enemyCount << endl;
    for (int i = 0; i < enemyCount; i++) {
        int type = RandomGenerator::dynamicGenerator(0, 3);
        Enemy enemy = Enemy(vertexId * 10 + i, static_cast<Enemy::Types>(type));
        // cout << "Enemy: " << enemy.getName() << " " << enemy.getHealth() << endl;
        while (enemy.getHealth() > 0) {
            cout << "fefe\n";
            enemy.takeDamage(player.getDamage());
            player.takeDamage(enemy.getDamage());
            if(player.getHealth() <= 0) {
                cout << "Przegrales!";
                exit(0);
            }
            cout << player.getName() << ": " << player.getHealth() << "hp. | " << player.getDamage() << "dmg.\n";
            cout << i+1 << ") " << enemy.getName() << ": " << enemy.getHealth() << "hp. | " << enemy.getDamage() << "dmg.\n";
            this_thread::sleep_for(chrono::milliseconds(500));
        }
        cout << "Pokonales " << enemy.getName() << "!\n";
        this_thread::sleep_for(chrono::milliseconds(2500));
    }
}

void chest(Player& player, int vertexId) {
    int healPotion = RandomGenerator::dynamicGenerator(10, 100);
    cout << "Znalazles skrzynie z health potion! Dostajesz " << healPotion << "hp.\n";
    player.takeDamage(-healPotion);
}

void shop(Player& player, int vertexId) {
    int itemsCount = RandomGenerator::dynamicGenerator(1, 3);
    cout << "Witaj w sklepie! Dostepne przedmioty:" << endl;
    vector<item> shopItems;
    const string itemsNames[30] = {
        "Mlotek Od Latajacego Druida",
        "Toporzek Swietego Zdzicha",
        "Maczuga Przodka",
        "Dzidzia Przeznaczenia",
        "Sztylecior z Lochu",
        "Kusza Goryczy",
        "Mieczyk Wstydu",
        "Bat Ogrowej Babci",
        "Halabarda Cichego Janka",
        "Kijek Elfiego Smutku",
        "Topor Dwoch Lewych Rak",
        "Lancetnik Mglistej Cebuli",
        "Luk Zaczarowanego Kartofla",
        "Zbrojny Widel",
        "Nozyk Herbaciany z Avalon",
        "Szabla Rozpaczy i Troche Glodu",
        "Kij Proroka Stefana",
        "Runiczna Packa Na Muchy",
        "Mlot Pocztyliona",
        "Latajacy Kamien Pokoju",
        "Glewia Smoczego Wiesniaka",
        "Pierscien Oslizglego Wojownika",
        "Naramiennik z Krzywego Krowa",
        "Kostur Do Duszenia Sernika",
        "Szpon Czarodzieja Mietka",
        "Tarcza Z Kapusty",
        "Zlota Cegla Mocy",
        "Kusza z Miednicy",
        "Miecz Oblednej Cioci",
        "Lyzka Wojny"
    };
    for (int i = 0; i < itemsCount; i++) {
        int dmg = RandomGenerator::dynamicGenerator(5, 20);
        int buy = RandomGenerator::dynamicGenerator(10, 50);
        int sell = RandomGenerator::dynamicGenerator(5, buy);
        int nameId = RandomGenerator::dynamicGenerator(0, 29);
        shopItems.emplace_back(vertexId * 100 + i, itemsNames[nameId], dmg, buy, sell);
        cout << i << ": " << shopItems.back().name << " (obrazenia: " << dmg << ", cena: " << buy << ")" << endl;
    }
    cout << "Wybierz numer przedmiotu do zakupu lub -1 by wyjsc: ";
    int wybor;
    cin >> wybor;
    if (wybor >= 0 && wybor < itemsCount) {
        cout << "Kupiles: " << shopItems[wybor].name << endl;
        player.buy(shopItems[wybor]);
    } else {
        cout << "Nie kupiles nic." << endl;
    }
}