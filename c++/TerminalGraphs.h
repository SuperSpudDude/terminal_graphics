#include <string>
#include <vector>
#include <algorithm>
#include <iostream>
#include "Point.h"
#include "Vector.h"

class Label{

};

class Panel{
    bool showLabels = true;
    int width = 0;
    int height = 0;
    std::vector<std::vector<char>> panelArr;
    std::vector<Point> points; 
    std::vector<Vector> vectors;
    std::vector<Label> labels;
    char borderChar = '#';
    char blankChar = ' ';
    char pointChar = '@';
    char vectChar = '~'; 

    public:
        Panel(int w, int h);
        Panel(int w, int h, char brdr, char pnt, char vect);
        int getWidth(){return width; };
        int getHeight(){return height; };
        // Panel(int w, int h, bool labels);
        void add(Point &);
        // void add(Label l);
        // void add(Square s);
        bool checkPointPresent(Point);
        bool checkConnected(Point &, Point &);
        bool checkPointsEqual(Point *, Point *);
        void connectPoints(Point &, Point &);
        void Display();

    private:
        bool checkBothPointsPresent(Point, Point);
        void DrawPoints();
        void DrawVectors();
        // void DrawLabels();
        void DrawBlankPanel();
        void Draw();
        void toggleLabels();
        
};
