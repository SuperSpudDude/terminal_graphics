#include "Point.h"

Point::Point(int x, int y){
    X = x;
    Y = y;
    name = "point(" + x + ',' + y + ')';
}
Point::Point(int x, int y, std::string n){
    X = x;
    Y = y;
    name = n;
    hasName = true;
}
bool Point::at(int x, int y){
    if(x == X && y == Y)
        return true;
    else
        return false;
}