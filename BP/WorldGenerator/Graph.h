#ifndef GRAPH
#define GRAPH

#include<iostream>
#include<vector>
#include<string>
#include<array>

#include"../Utilities/RandomGenerator.h"
#include"../Utilities/struct.h"

using namespace std;

class Graph {
    protected:
        vector<vertex> vertices;
        vector<connection> connections;
        static const array<string, 30> names;
        static RandomGenerator rGenerator;
        void addConnection(int start, int end, int weight);
        void addVertex(string name);
        void addVertex(int id, string name);
    private:
        int find(int id);
        int find(string text);
    public:
        Graph() {};
        Graph(vector<string> names);
        Graph(vector<string> names, vector<connection> connections);
        Graph(vector<int> ids, vector<string> names, vector<connection> connections);
        const vector<vertex>& getVertices() const { return vertices; }
        const vector<connection>& getConnections() const { return connections; }
};

#endif