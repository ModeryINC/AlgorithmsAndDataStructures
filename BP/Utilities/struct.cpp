#include<iostream>
#include<string>

#include"struct.h"

using namespace std;

vertex::vertex(int id, string type, string name)
: id(id), type(type), name(name) {
    if (id < 0)
        throw invalid_argument("Vertex: Id cannot br less than 0!");
    if (type.empty())
        throw invalid_argument("Vertex: Type cannot be empty!");
    if (name.empty())
        throw invalid_argument("Vertex: Name cannot be empty!");
}

connection::connection(int weight, vertex start, vertex end) 
: weight(weight), start(start), end(end) {
    if (start.id == end.id)
        throw invalid_argument("Connection: Cannot make loop connection!");
    if (weight <= 0)
        throw out_of_range("Connection: Weight must be grater than 0!");
}

item::item(int id, string name, int damage, int buyCost, int sellCost)
: id(id), name(name), damage(damage), buyCost(buyCost), sellCost(sellCost) {
    if (id < 0)
        throw out_of_range("Item: Id cannot be less than 0!");
    if (name.empty())
        throw invalid_argument("Item: Name cannot be empty!");
    if (damage < 1)
        throw out_of_range("Item: Damage cannot be less than 1!");
    if (buyCost < 0 || sellCost < 0)
        throw out_of_range("Item: Cost cannnot be less than 0!");
}