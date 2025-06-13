#include<algorithm>
#include<iostream>
#include<optional>
#include<numeric>
#include<utility>
#include<vector>
#include<string>
#include<map>

#include"struct.h"

using namespace std;

class Graph {
    protected:
        vector<pair<int, string>> vertices;
        vector<connection> connections;
    private:
        int find(int id) {
            try {
                if(vertices[id].first == id)
                    return id;
            } catch(exception& _) {
                for(int i = 0; i < vertices.size(); i++)
                    if(vertices[i].first = id)
                        return i;
                return -1;
            }
        }
    public:
        Graph() {}
        Graph(vector<string> names) {
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(i, names[i]);
        }
        Graph(vector<string> names, vector<connection> connections) {
            if(names.size() != connections.size())
                throw invalid_argument("Wrong vector sizes!");
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(i, names[i]);
            this->connections = connections;
        }
        Graph(vector<int> ids, vector<string> names, vector<connection> connections) {
            if(ids.size() != names.size() || ids.size() != connections.size())
                throw invalid_argument("Wrong vector sizes!");
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(ids[i], names[i]);
            this->connections = connections;
        }
        void addConnection(int start, int end, int weight) {
            int start_id = this->find(start),
                end_id = this->find(end);
            if(start_id != -1 || end_id != -1)
                throw invalid_argument("Start or end isnt in ids");
            connections.emplace_back(vertices[start_id], vertices[end_id], weight);
        }
};