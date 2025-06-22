#include<iostream>
#include<vector>
#include<string>
#include<array>

#include"../Utilities/RandomGenerator.h"
#include"../Utilities/struct.h"
#include"Graph.h"

using namespace std;

const array<string, 30> Graph::names = {
    "Zasnuty Mgla Las",
    "Kamienny Krag Morrigan",
    "Wrzosowisko Lamentow",
    "Jezioro Kelpich Lez",
    "Szczyt Kruka",
    "Dolina Umarlych Piesni",
    "Wrota Tir na nog",
    "Dab Dziewieciu Cieni",
    "Podziemia Fomorian",
    "Kamienny Tron Balora",
    "Zatopiona Wioska Sidhe",
    "Mokradla Szeptow",
    "Ruiny Swiatyni Danu",
    "Kraina Cichego Krzyku",
    "Las Zmiennoksztaltnych",
    "Wzgorze Przysiegi",
    "Kryjowka Redcapa",
    "Jaskinia Dullahana",
    "Rzeka Zapomnianych Imion",
    "Tajemniczy Krag Clurichaunow",
    "Wieza Zlamanego Czasu",
    "Kopalnia Przekletych",
    "Przelecz Wilczych Oczy",
    "Sanktuarium Zielonego Psa",
    "Wielki Krąg Tuatha De Danann",
    "Kamienne Serce Gor",
    "Dolina Ostatniego Switu",
    "Gaj Cieni Morrigan",
    "Grota Dusz Wędrownych",
    "Starozytna Cytadela Ceffyl Dwr"
};

RandomGenerator Graph::rGenerator = RandomGenerator(0, 29);

void Graph::addConnection(int start, int end, int weight) {
    // cout << "Connection: " <<weight << " " << start << " " << end << endl;
    int start_id = this->find(start),
        end_id = this->find(end);
    if (start_id == -1 || end_id == -1) {
        cout << start << ":" << start_id << " | " << end << ":" << end_id << " | ";
        for (auto v : vertices)
            cout << v.id << " ";
        cout << "\n";
        throw invalid_argument("Graph::connection: Start or end isnt in ids!");
    }
    connections.emplace_back(weight, vertices[start_id], vertices[end_id]);
}

void Graph::addVertex(string type) {
    int id = this->find("max") + 1;
    string name = names[rGenerator.next()];
    // cout << "Vertex: " << id << " " << type << " " << name << "\n";
    vertices.emplace_back(id, type, name);
}

void Graph::addVertex(int id, string type) {
    if (this->find(id) != -1)
        throw invalid_argument("Graph::vertex: This id already exist!");
    string name = names[rGenerator.next()];
    vertices.emplace_back(id, type, name);
}

int Graph::find(int id) {
    try {
        if(vertices[id].id == id)
            return id;
    } catch(...) {
        for(int i = 0; i < vertices.size(); i++) 
            if(vertices[i].id == id)
                return i;
    }
    return -1;
}

int Graph::find(string text) {
    if (vertices.size() == 0) return -1;
    if ((text) == "max") {
        int max = 0;
        for (int i = 0; i < vertices.size(); i++)
            if (vertices[i].id > max)
                max = vertices[i].id;
        return max;
    } else if ((text) == "min") {
        int min = 0;
        for (int i = 0; i < vertices.size(); i++)
            if (vertices[i].id < min)
                min = vertices[i].id;
        return min;
    }
    return -1;
}

Graph::Graph(vector<string> types) {
    for(int i = 0; i < types.size(); i++) {
        string name = names[rGenerator.next()];
        vertices.emplace_back(i, types[i], name);
    }
}

Graph::Graph(vector<string> types, vector<connection> connections) {
    if (names.size() || connections.size())
        throw invalid_argument("Graph: Vectors cannot be empty!");
    for (int i = 0; i < names.size(); i++) {
        string name = names[rGenerator.next()];
        vertices.emplace_back(i, types[i], name);
    }
    this->connections = connections;
}

Graph::Graph(vector<int> ids, vector<string> types, vector<connection> connections) {
    if (types.size() || connections.size())
        throw invalid_argument("Graph: Vectors cannot be empty!");
    if (ids.size() != types.size())
        throw invalid_argument("Graph: Wrong vector sizes!");
    for (int i = 0; i < types.size(); i++) {
        string name = names[rGenerator.next()];
        vertices.emplace_back(ids[i], types[i], name);
    }
    this->connections = connections;
}