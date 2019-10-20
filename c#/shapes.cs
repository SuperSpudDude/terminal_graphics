using System;
using System.Collections.Generic;

namespace terminal_graphics{
    // TODO: add point(/vertex?) and build shapes from that
    public class Point {
        public string name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y){
            X = x;
            Y = y;
            name = "point(" + x + ',' + y + ')';
        }

        public Point(int x, int y, string n){
            X = x;
            Y = y;
            name = n;
        }
        public bool at(int x, int y){
            if(x == X && y == Y)
                return true;
            else
                return false;
        }
    }

    public class Vector {
        public Point P1 {get;}
        public Point P2 {get;}
        public Vector(Point p1, Point p2){
            P1 = p1;
            P2 = p2;
        }
    }
    public class Shape {
        public List<Point> points = new List<Point>();
        public List<Vector> vectors = new List<Vector>();
    }

    class Square : Shape {
        public Square(int x, int y, int sideLen){
            
            Point tl = new Point(x, y); 
            Point tr = new Point(x+sideLen, y);
            Point bl = new Point(x, y+sideLen);
            Point br = new Point(x+sideLen, y+sideLen);
            points.Add(tl);
            points.Add(tr);
            points.Add(bl);
            points.Add(br);
            // connected in a clockwise fashion
            Vector top = new Vector(tl,tr);
            Vector right = new Vector(tr,br);
            Vector bottom = new Vector(br,bl);
            Vector left = new Vector(bl,tl);
            vectors.Add(top);
            vectors.Add(right);
            vectors.Add(bottom);
            vectors.Add(left);
        }
    }
    class Rectangle : Shape {}
    class eqTriangle : Shape {}

    class Label : Point{
        //public List<char> value = new List<char>();
        public char[] value;
        public Label(int x, int y, string val) : base(x,y){
            X = x;
            Y = y;
            value = val.ToCharArray();
        }
    }

    
}