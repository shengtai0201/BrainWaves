using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWaves.Models
{
    public interface IBrainWavesService
    {
        IList<CategorySeries> Read(IOrderedEnumerable<IFileInfo> directoryContents);
    }
}
