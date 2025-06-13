#include<iostream>
#include<string>
#include<vector>

using namespace std;

struct connection {
    const int weight;
    const pair<int, string> start;
    const pair<int, string> end;
    connection(int weigth, pair<int, string> start, pair<int, string> end) 
        : weight(weight), start(start), end(end) {
        if(start == end)
            throw invalid_argument("Cannot loop connection!");
        if(weight <= 0)
            throw out_of_range("Weight must be grater than 0!");
    }
};
