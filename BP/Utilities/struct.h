#ifndef STRUCT
#define STRUCT

#include<iostream>
#include<string>

using namespace std;

struct vertex {
    int id;
    string type;
    string name;
    vertex(int id, string type, string name);
};

struct connection {
    int weight;
    vertex start;
    vertex end;
    connection(int weigth, vertex start, vertex end);
};

struct item {
    int id;
    string name;
    int damage, buyCost, sellCost;
    item(int id, string name, int damage, int buyCost, int sellCost);
};

#endif