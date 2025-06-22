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

bool isNeighbor(const vector<int>& neighbors, int vertexId) {
    for (int n : neighbors)
        if (n == vertexId) return true;
    return false;
}

void fight(Player& player, int vertexId, int stage) {
    int enemyCount = RandomGenerator::dynamicGenerator(1, 3);
    cout << "Walka! Przeciwników: \033[31m" << enemyCount << "\033[0m\n";
    
    for (int i = 0; i < enemyCount; i++) {
        int type = RandomGenerator::dynamicGenerator(0, 3);
        Enemy enemy = Enemy(vertexId * 10 + i, static_cast<Enemy::Types>(type));
        
        // cout << "Enemy: " << enemy.getName() << " " << enemy.getHealth() << endl;
        
        while (enemy.getHealth() > 0) {
            enemy.takeDamage(player.getDamage());
            player.takeDamage(enemy.getDamage());
            
            cout << player.getName() << ": \033[32m"
                << player.getHealth() << "hp. \033[0m| \033[31m"
                << player.getDamage() << "dmg.\033[0m\n"
                << i+1 << ") " << enemy.getName() << ": \033[32m"
                << enemy.getHealth() << "hp. \033[0m| \033[31m"
                << enemy.getDamage() << "dmg.\033[0m\n\n";
            
            if (player.getHealth() <= 0) {
                cout << "\033[31mPrzegrałeś! Przeszedłeś \033[32m" << stage - 1 << " poziomy\033[31m!\033[0m\033[0m";
                exit(0);
            }
            
            this_thread::sleep_for(chrono::milliseconds(500));
        }
        
        player.addCoins(enemy.getCashDrop());
        
        cout << "\033[32mPokonałeś " << enemy.getName()
            << "!\033[0m i zyskałeś \033[33m" << enemy.getCashDrop()
            << "\033[0m monet.\n";
        
        int enemiesLeft = enemyCount - i - 1;
        if (enemiesLeft > 1)
            cout << "Pozostało \033[31m" << enemiesLeft << "\033[0m wrogów!\n\n";
        else if (enemiesLeft == 1)
            cout << "Pozostał \033[31m 1 \033[0m wróg!\n";
        
        this_thread::sleep_for(chrono::milliseconds(2500));
    }
}

void chest(Player& player, int vertexId) {
    int healPotion = RandomGenerator::dynamicGenerator(10, 100);
    
    player.takeDamage(-healPotion);
    
    cout << "\033[33mZnalazles skrzynie z health potion! Dostajesz " << healPotion << "hp.\033[0m\n\n"
            "Aktualnie masz: \033[32m" << player.getHealth() << "hp\033[0m.\n";
}

void shop(Player& player, int vertexId) {
    int itemsCount = RandomGenerator::dynamicGenerator(1, 3);
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
    
    cout << "Witaj w sklepie! Dostepne przedmioty:" << endl;
    
    for (int i = 0; i < itemsCount; i++) {
        int dmg = RandomGenerator::dynamicGenerator(10, 25);
        int buy = RandomGenerator::dynamicGenerator(dmg + 10, 55);
        int sell = RandomGenerator::dynamicGenerator(5, buy);
        int nameId = RandomGenerator::dynamicGenerator(0, 29);
        
        shopItems.emplace_back(vertexId * 100 + i, itemsNames[nameId], dmg, buy, sell);
        
        cout << i << ": \033[35m" << shopItems.back().name
            << "\033[0m (obrazenia: \033[31m"
            << dmg << "dmg\033[0m, cena: \033[33m"
            << buy << "\033[0m monety)\n";
    }
    auto playerWeapon = player.getWeapon();
    cout << "Aktualna Broń: \033[35m" << playerWeapon.name
            << "\033[0m (obrazenia: \033[31m"
            << playerWeapon.damage << "dmg\033[0m, cena: \033[33m"
            << playerWeapon.sellCost << "\033[0m monety)\n";
    
    string answer;
    cout << "Wybierz numer przedmiotu do zakupu lub -1 by wyjsc: ";
    cin >> answer;
    
    try {
        int chose = stoi(answer);
        if (chose >= 0 && chose < itemsCount) {
        cout << "Kupiles: \033[35m" << shopItems[chose].name << "\033[0m\n";
        player.buy(shopItems[chose]);
    } else cout << "Nie kupiles nic.\n";
    } catch (...) {}
}