using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWaves.Models
{
    public class BrainWavesService : IBrainWavesService
    {
        public IList<CategorySeries> Read(IOrderedEnumerable<IFileInfo> directoryContents)
        {
            List<CategorySeries> list = new List<CategorySeries>();

            foreach (var fileInfo in directoryContents)
            {
                var stream = fileInfo.CreateReadStream();
                var reader = new StreamReader(stream);

                int index = 0;
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    var item = new CategorySeries();

                    var values = line.Split(',');
                    if (double.TryParse(values[0], out double delta))
                        item.Delta = delta;
                    else
                        continue;

                    item.Index = index++;

                    item.Theta = Convert.ToDouble(values[1]);
                    item.Alpha = Convert.ToDouble(values[2]);
                    item.Beta = Convert.ToDouble(values[3]);
                    item.Gamma = Convert.ToDouble(values[4]);

                    list.Add(item);
                }

                reader.Close();
                reader.Dispose();
                stream.Close();
                stream.Dispose();
            }

            return list;
        }
    }
}
