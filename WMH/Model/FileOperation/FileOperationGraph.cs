using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.FileOperation
{
    public static class FileOperationGraph
    {
        public static void SaveToFile(string path, IList<Vertex> vertexes)
        {
            CreateFolderPath(path);
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(path, false))
            {
                foreach (Vertex v in vertexes)
                {
                    file.WriteLine(v.X + " " + v.Y);
                }
            }
        }

        public static Graph LoadFromFile(string path)
        {
            Graph graph = new Graph();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                double x=0, y=0;
                string[] split = line.Split(' ');
                double.TryParse(split[0], out x);
                double.TryParse(split[1], out y);
                graph.Vertexes.Add(new Vertex(x, y));
            }
            return GraphGenerator.GraphGenerator.generateGraph(graph);
        }

        private static void CreateFolderPath(string path)
        {
            int index = path.LastIndexOf("\\");
            string folderPath = path.Substring(0, index);

            bool subPath = System.IO.Directory.Exists(folderPath);
            if (!subPath)
                System.IO.Directory.CreateDirectory(folderPath);
        }
    }
}
