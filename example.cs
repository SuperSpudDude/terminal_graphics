using System;
using terminal_graphics;

namespace terminal_graphics{
    class Example{
        static void Main(string[] args){
            Panel panel =  new Panel(40,20);
            
            // points can be added in any other these ways
            panel.add(new Point(3,3));
            panel.add(new Point(20,3,"point with a name"));
            // to address a point after adding it you will have to create and initialise it as a seperate object:
            Point p1 = new Point(15,15);
            Point p2 =  new Point(5,5,"another name");
            panel.add(p1);
            panel.add(p2);
            // connect two points (create a new vector)
            panel.connectPoints(p1, p2);

            panel.add(new Label(2,17,"you can also use labels\nwith multiline too :D"));
            // you can toggle labels on or off with panel.toggleLabels() (this also turns off point names)
            panel.Display();
        }
    }
}