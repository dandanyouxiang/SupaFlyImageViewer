using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SupaFlyImageViewer
{
    public class Options
    {
        [Option('f', "FilePath", Required = true)]
        public string ImageFilePath { get; set; }
    }
}
