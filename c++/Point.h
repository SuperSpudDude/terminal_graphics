#include <string>

class Point{
    std::string name = "";
    int X = 0;
    int Y = 0;
    public:
        bool hasName = false;
        int getX(){ return X;}
        int getY(){ return Y;}
        std::string getName(){ return name; }  
        Point() = default;
        Point(int, int);
        Point(int x, int y, std::string n);
        bool at(int, int);
};