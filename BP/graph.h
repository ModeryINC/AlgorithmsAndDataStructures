#ifndef GRAPH
#define GRAPH

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
        int find(int id);
    public:
        Graph();
        Graph(vector<string> names);
        Graph(vector<string> names, vector<connection> connections);
        Graph(vector<int> ids, vector<string> names, vector<connection> connections);
        void addConnection(int start, int end, int weight);
};

#endif