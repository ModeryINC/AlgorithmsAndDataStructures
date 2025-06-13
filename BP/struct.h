#ifndef STRUCT
#define STRUCT

#include<iostream>
#include<string>
#include<vector>

using namespace std;

struct connection {
    const int weight;
    const pair<int, string> start;
    const pair<int, string> end;
    connection(int weigth, pair<int, string> start, pair<int, string> end);
};

#endif