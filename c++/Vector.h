#include "Point.h"

class Vector{
    Point *P1;
    Point *P2;
    public:
        Point *getP1(){ return P1;}
        Point *getP2(){ return P2;}
        Vector() = default;
        Vector(Point *, Point *);
};