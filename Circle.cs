using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Circle
    {
        public double x { get; set; }
        public double y { get; set; }
        public double radius { get; set; }
        public Vertex vertex { get; set; }
        public Circle(double x, double y, double radius, Vertex vertex)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.vertex = vertex;
        }
    }
}
