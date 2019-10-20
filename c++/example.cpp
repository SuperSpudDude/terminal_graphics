#include "TerminalGraphs.h"

int main(){
    Panel panel = Panel(40, 20, '#', '@', '+');
    // points can be added in any other these ways
    Point p = Point(3,3);
    panel.add(p);
    Point pName = Point(20,3,"point with a name");
    panel.add(pName);
    // to address a point after adding it you will have to create and initialise it as a seperate object:
    Point p1 = Point(35,15);
    Point p2 = Point(5,5);
    panel.add(p1);
    panel.add(p2);
    // connect two points (create a new vector)
    panel.connectPoints(p1, p2);

    //panel.add(new Label(2,17,"you can also use labels\nwith multiline too :D"));
    // you can toggle labels on or off with panel.toggleLabels() (this also turns off point names)
    panel.Display();
    //panel.toggleLabels();
    
    
    // //repeatedly changing p1 and displaying output
    // int x = 1;
    // while(true){
    //     if(p1.X == 30)
    //         x = -1;
    //     if(p1.X == 5)
    //         x = 1;
    //     p1.X += x;
    //     panel.Display();
    //     Thread.Sleep(100);
    // }
    return 0;
}