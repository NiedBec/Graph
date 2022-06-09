using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graph
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Circles circles = new Circles();
        string FileName;
        Graph graph = new Graph();
        int countOfVertex;
        Graphics g;
        IEnumerable<string> distinctNames; // продолжить с данного момента
        List<Circle> c = new List<Circle>();                                   // 
        double pi = 3.14159265;
        List<Vertex> vertexes = new List<Vertex>();
        List<Edge> edges = new List<Edge>();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, 10, 50, 150, 200);
            picture.Image = bmp;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               FileName = openFileDialog1.FileName;
            }

            //var graph = new Graph();
            //File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), FileName), "11\nMaximov Petrov\nMaximov Igorev\nMaximov Smirnov\n" +
            //                                                                                   "Petrov Maximov\nPetrov Igorev\nPetrov Smirnov\n" +
            //                                                                                   "Igorev Petrov\nIgorev Maximov\nIgorev Smirnov\n" +
            //                                                                                   "Smirnov Maximov\nSmirnov Petrov\nSmirnov Igorev\n" +
            //                                                                                   "Pashaev Takashov\nPashaev Sallahov\n" +
            //                                                                                   "Takashov Pashaev\nTakashov Sallahov\n" +
            //                                                                                   "Sallahov Pashaev\nSallahov Takashov\n" +
            //                                                                                   "Matveev Ivleev\nMatveev Rashadov\nMatveev Rakitskiy\n" +
            //                                                                                   "Rashadov Matveev\nRashadov Rakitskiy\nRashadov Ivleev\n" +
            //                                                                                   "Rakitskiy Rashadov\nRakitskiy Matveev\nRakitskiy Ivleev\n" +
            //                                                                                   "Ivleev Rakitskiy\nIvleev Rashadov\nIvleev Matveev\n");
            char[] charSeparators = new char[] { ' ', '\r','\n' };
            var dataString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),FileName)).Split(charSeparators,StringSplitOptions.RemoveEmptyEntries);
            countOfVertex = Int32.Parse(dataString[0]);
            var b = new string[dataString.Length - 1];
            Array.Copy(dataString, 0, b, 0, 0);
            Array.Copy(dataString, 0 + 1, b, 0, dataString.Length - 0 - 1);
            distinctNames = b.Distinct();
            foreach(string Name in distinctNames)
            {
                Console.WriteLine(Name);
            }

            var data = distinctNames.ToList();

            //Выглядит это следующим образом. Пусть a — исходный массив, b — результирующий массив, n — номер удаляемого элемента.
            //var b = new int[a.Length - 1]; Предположим, что массивы целочисленные
            //Array.Copy(a, 0, b, 0, n);
            //Array.Copy(a, n + 1, b, n, a.Length - n - 1);
            // https://ru.stackoverflow.com/questions/414655/%D0%9F%D0%BE%D0%B6%D0%B0%D0%BB%D1%83%D0%B9%D1%81%D1%82%D0%B0-%D0%BF%D1%80%D0%B8%D0%B2%D0%B5%D0%B4%D0%B8%D1%82%D0%B5-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80-%D0%BA%D0%BE%D0%B4%D0%B0-%D1%83%D0%B4%D0%B0%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F-%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D0%B0-%D0%B8%D0%B7-%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%D0%B0-%D0%BF%D0%BE-%D0%BD%D0%BE%D0%BC%D0%B5%D1%80%D1%83-%D0%9D%D0%BE%D0%BC%D0%B5%D1%80
            



            var bID = new int[dataString.Length-1];

            var dataID = new int[data.Count];
            for(int i=0; i<data.Count; ++i)
            {
                dataID[i] = i;
            }

            for(int i =0; i < b.Length; ++i)
            {
                for(int j=0;j<data.Count; ++j)
                {
                    if(b[i] == data[j])
                    {
                        bID[i] = dataID[j];
                    }
                }
            }

            for (int i = 0; i < data.Count; ++i)
            {
                vertexes.Add(new Vertex(data[i],i));
            }

            for (int i = 0; i < data.Count; ++i)
            {
                graph.AddVertex(vertexes[i]); 
            }

            int step = 0;
            while(step < bID.Length)
            {
                graph.AddEdge(vertexes[bID[step]], vertexes[bID[step + 1]]);
                edges.Add(new Edge(vertexes[bID[step]], vertexes[bID[step + 1]], 1));
                step += 2;
            }



            //for (int i = 0; i < data.Count; ++i)
            //{
            //    ;
            //}

            //var matrix = graph.GetMatrix();
            //dataGridView1.RowCount = graph.VertexCount;
            //dataGridView1.ColumnCount = graph.VertexCount;

            //for(int i = 0; i < graph.VertexCount; i++)
            //{
            //    dataGridView1.Columns[i].HeaderText = data[i];
            //    for (int j = 0; j < graph.VertexCount; j++)
            //    {
            //        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
            //    }
            //}


            //GetVertex(graph, vertexes[1]);


            var groupId = new int[data.Count];
            
            for(int i =0;i < data.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (graph.Wave(vertexes[i], vertexes[j]))
                    {
                        groupId[i] = j;
                    }
                }
            }
            textBox1.Text = groupId.Distinct().Count().ToString();


            for (int i = 0; i < vertexes.Count; i++)
            {
                c.Add(new Circle(0, 0, 20, vertexes[i]));
            }

            for (int i = 0; i < vertexes.Count; i++)
            {
                circles.AddCircle(c[i]);
            }

            for (int i = 0; i < countOfVertex; i++)
            {
                c.Add(new Circle(0, 0, 20));
            }
            for (int i = 0; i < countOfVertex; i++)
            {
                circles.AddCircle(c[i]);
            }
            Draw();
        }
        private static void GetVertex(Graph graph, Vertex vertex)
        {
            Console.WriteLine(vertex.ID + ": ");
            foreach (var v in graph.GetVertexLists(vertex))
            {
                Console.WriteLine(v.ID + ", ");
            }
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            double step = pi / (double)(circles.circlesCount);
            double rast = 100;
            double radius = (double)(circles.circlesCount) * Math.Cos(step)+rast;
            // r = 11*cosL;
            for (int i = 0; i < countOfVertex/2; i++)
            {
                radius = radius * Math.Cos(step)+rast;
                c[i].x = (float)(radius * Math.Cos(step));
                c[i].y = (float)(radius * Math.Sin(step));
                // Radius will changes and Angle will changes for each iteration
                g.DrawEllipse(pen,350+(float)(c[i].x),350+(float)(c[i].y), 20, 20);
                step += pi / countOfVertex;
                c[i].x = 350 + c[i].x;
                c[i].y = 350 + c[i].y;
            }
            step = pi / (double)(circles.circlesCount);
            for (int i = countOfVertex / 2; i < countOfVertex; i++)
            {
                radius = radius * Math.Cos(step) + rast;
                c[i].x = (float)(radius * Math.Cos(step));
                c[i].y = (float)(radius * Math.Sin(step));
                // Radius will changes and Angle will changes for each iteration
                g.DrawEllipse(pen, 350 - (float)(c[i].x), 350 - (float)(c[i].y), 20, 20);
                step += pi / countOfVertex;
                c[i].x = 350 - c[i].x;
                c[i].y = 350 - c[i].y;
            }
            // need to draw Edges from c to c i think=)
            char[] charSeparators = new char[] { ' ', '\r', '\n' };
            var dataString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), FileName)).Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            countOfVertex = Int32.Parse(dataString[0]);
            var b = new string[dataString.Length - 1];
            Array.Copy(dataString, 0, b, 0, 0);
            Array.Copy(dataString, 0 + 1, b, 0, dataString.Length - 0 - 1);
            distinctNames = b.Distinct();
            foreach (string Name in distinctNames)
            {
                Console.WriteLine(Name);
            }

            var data = distinctNames.ToList();

            //Выглядит это следующим образом. Пусть a — исходный массив, b — результирующий массив, n — номер удаляемого элемента.
            //var b = new int[a.Length - 1]; Предположим, что массивы целочисленные
            //Array.Copy(a, 0, b, 0, n);
            //Array.Copy(a, n + 1, b, n, a.Length - n - 1);
            // https://ru.stackoverflow.com/questions/414655/%D0%9F%D0%BE%D0%B6%D0%B0%D0%BB%D1%83%D0%B9%D1%81%D1%82%D0%B0-%D0%BF%D1%80%D0%B8%D0%B2%D0%B5%D0%B4%D0%B8%D1%82%D0%B5-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80-%D0%BA%D0%BE%D0%B4%D0%B0-%D1%83%D0%B4%D0%B0%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F-%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D0%B0-%D0%B8%D0%B7-%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%D0%B0-%D0%BF%D0%BE-%D0%BD%D0%BE%D0%BC%D0%B5%D1%80%D1%83-%D0%9D%D0%BE%D0%BC%D0%B5%D1%80


            //List<Vertex> vertexes = new List<Vertex>();
            //List<Edge> edges = new List<Edge>();

            var bID = new int[dataString.Length - 1];

            var dataID = new int[data.Count];
            for (int i = 0; i < data.Count; ++i)
            {
                dataID[i] = i;
            }

            for (int i = 0; i < b.Length; ++i)
            {
                for (int j = 0; j < data.Count; ++j)
                {
                    if (b[i] == data[j])
                    {
                        bID[i] = dataID[j];
                    }
                }
            }
            if (edges.Count>=1)
            {
                for (int i = 0; i < bID.Length; i += 2)
                {
                    g.DrawLine(pen, c[bID[i]].x + 10, c[bID[i]].y + 10, c[bID[i + 1]].x + 10, c[bID[i + 1]].y + 10);

                }
            }
            
            picture.Image = bmp;
        }


        //private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void pictureBox1_Click_1(object sender, EventArgs e)
        //{

        //}


    }
}
