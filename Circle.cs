using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Circle
    {
        public float x { get; set; }
        public float y { get; set; }
        public float radius { get; set; }
        public Vertex vertex { get; set; }
        public Circle(float x, float y, float radius, Vertex vertex)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.vertex = vertex;
        }
    }
}
