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
        void addConnection(int start, int end, int weight) {
            int start_id = this->find(start),
                end_id = this->find(end);
            if(start_id != -1 || end_id != -1)
                throw invalid_argument("Start or end isnt in ids");
            connections.emplace_back(vertices[start_id], vertices[end_id], weight);
        }
        void addVertex(string name) {
            int id = this->find("max") + 1;
            vertices.emplace_back(id, name);
        }
        void addVertex(int id, string name) {
            if(this->find(id) != -1)
                throw invalid_argument("This id already exist!");
            vertices.emplace_back(id, name);
        }
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
        int find(string text) {
            if((text) == "max") {
                int max = 0;
                for(int i = 0; i < vertices.size(); i++)
                    if(vertices[i].first > max)
                        max = vertices[i].first;
                return max;
            } else if((text) == "min") {
                int min = 0;
                for(int i = 0; i < vertices.size(); i++)
                    if(vertices[i].first < min)
                        min = vertices[i].first;
                return min;
            }
        }
    public:
        Graph() {}
        Graph(vector<string> names) {
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(i, names[i]);
        }
        Graph(vector<string> names, vector<connection> connections) {
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(i, names[i]);
            this->connections = connections;
        }
        Graph(vector<int> ids, vector<string> names, vector<connection> connections) {
            if(ids.size() != names.size())
                throw invalid_argument("Wrong vector sizes!");
            for(int i = 0; i < names.size(); i++)
                vertices.emplace_back(ids[i], names[i]);
            this->connections = connections;
        }
};