using System;
using System.Collections.Generic;

namespace terminal_graphics {
    
    class Panel {
        bool showLabels = true;
        int width = 0;
        int height = 0;
        char[,] panelArr;
        List<Point> points = new List<Point>(); 
        List<Vector> vectors = new List<Vector>();
        List<Label> labels = new List<Label>();
        char borderChar = '█';
        char blankChar = ' ';
        char pointChar = '☼';
        char vectChar = '•'; 

        public Panel(int w, int h){
            // added 2 to account for border on each side of panel
            width = w + 2;
            height = h + 2;
            panelArr = new char[height, width];
        }

        public Panel(int w, int h, bool labels){
            // added 2 to account for border on each side of panel
            width = w + 2;
            height = h + 2;
            panelArr = new char[height, width];
            showLabels = labels;
        }

        public void add(Point p){
            points.Add(p);
        }

        public void add(Label l){
            labels.Add(l);
        }

        public void add(Square s){
            foreach(Point p in s.points){
                points.Add(p);
            }
            foreach(Vector v in s.vectors){
                vectors.Add(v);
            }
        }

        public void connectPoints(Point p1, Point p2){
            if(checkPointsPresent(p1,p2)){
                vectors.Add(new Vector(p1,p2));
            }
        }

        private bool checkPointsPresent(Point p1, Point p2){
            return points.Contains(p1) && points.Contains(p2); 
        }

        private void DrawPoints(){
            foreach (Point p in points){
                panelArr[p.Y, p.X] = pointChar;
                if(showLabels){
                    int x = p.X + 1;
                    foreach(char c in p.name){  
                        if(x >= width-1){
                            break;
                        } else {
                            panelArr[p.Y, x] = c;
                            x++;
                        }
                    }
                }
            }
        }

        private void DrawVectors(){
            // using DDA algorithm
            foreach(Vector v in vectors){
                Point p1 = v.P1;
                Point p2 = v.P2;
                int steps;
                float x = p1.X;
                float y = p1.Y;
                float Xincr = 0;
                float Yincr = 0;
                // work out difference
                int dx = p2.X - p1.X;
                int dy = p2.Y - p1.Y;
                // in order to work out steps we need non zero, posotive integer values for dx and dy (largest unsigned integer value)
                // work out steps needed (pixels needed)
                if(Math.Abs(dx) > Math.Abs(dy)) {
                    steps = dx;
                } else { 
                    steps = dy;
                }
                // if steps is negative convert to positive (steps is never negative)
                if(steps < 0){
                    steps *= -1;
                }
                // calculate x and y increments
                Xincr = (float)dx / (float)steps;
                Yincr = (float)dy / (float)steps;
                // draw vector
                for (int i = 0; i < steps-1; i++){  // -1 so end point is not overwritten
                    x += Xincr;
                    y += Yincr;
                    panelArr[(int)y, (int)x] = vectChar;   
                }
            }
        }
        private void DrawLabels(){
            int x,y;
            foreach(Label l in labels){
                x = l.X;
                y = l.Y;
                foreach(char c in l.value){
                    if(c == '\n'){ 
                       y += 1;
                       x = l.X;
                       continue;
                    }
                    if(x >= width-1){
                        break;
                    } else {
                        panelArr[y,x] = c;
                        x++;
                    }    
                }
            }
        }
        private void DrawBlankPanel(){
            for( int y = 0; y < height; y++){
                for(int x = 0; x < width; x++){
                        if(x == 0 || x == width-1 || y == 0 || y == height-1){
                            panelArr[y,x] = borderChar;
                        } else {
                            panelArr[y,x] = blankChar;
                        }
                }
            }
        }

        private void Draw(){
            // draw panel
            DrawBlankPanel();
            // draw any shapes that are present
            DrawPoints();
            DrawVectors();
            if(showLabels)
                DrawLabels();
        }

        public void toggleLabels(){
            showLabels = !showLabels;
        }

        public void Display(){
            Console.Clear();
            Draw();
            for( int y = 0; y < height; y++){
                for(int x = 0; x < width; x++){
                        Console.Write(panelArr[y, x]);
                }
                Console.Write('\n');
            }
        }
    }
}