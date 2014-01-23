using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.FileOperation
{
    public static class FileOperationResult
    {
        public static void SaveResultToFile(IList<Edge> resultEdges, string path, Stopwatch stopWatch)
        {
            string folderPath = CreateFolderPath(path);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(folderPath + "\\summary", true))
            {
                if (stopWatch != null)
                {
                    file.WriteLine(FormatTime(stopWatch));
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                if (stopWatch != null)
                {
                    file.WriteLine(FormatTime(stopWatch));
                }
                file.WriteLine(new WMH.TabuSearch.CostFinder().GetCost(resultEdges));
                foreach (Edge e in resultEdges)
                {
                    file.WriteLine(e.Start.X + " " + e.Start.Y + "   " + e.End.X + " " + e.End.Y);
                }
            }
        }
        private static string FormatTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            return elapsedTime;
        }

        private static string CreateFolderPath(string path)
        {
            int index = path.LastIndexOf("\\");
            string folderPath = path.Substring(0, index);

            bool subPath = System.IO.Directory.Exists(folderPath);
            if (!subPath)
                System.IO.Directory.CreateDirectory(folderPath);
            return folderPath;
        }

    }
}
