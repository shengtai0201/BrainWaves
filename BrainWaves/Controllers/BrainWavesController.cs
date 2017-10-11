using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrainWaves.Models;
using Microsoft.Extensions.FileProviders;

namespace BrainWaves.Controllers
{
    [Produces("application/json")]
    [Route("api/BrainWaves")]
    public class BrainWavesController : Controller
    {
        private readonly IBrainWavesService service;
        private readonly IFileProvider fileProvider;
        public BrainWavesController(IBrainWavesService service, IFileProvider fileProvider)
        {
            this.service = service;
            this.fileProvider = fileProvider;
        }

        [HttpGet]
        public IEnumerable<CategorySeries> Get()
        {
            var directoryContents = this.fileProvider.GetDirectoryContents("wwwroot/csv").OrderBy(f => f.Name);
            return this.service.Read(directoryContents);
        }
    }
}
