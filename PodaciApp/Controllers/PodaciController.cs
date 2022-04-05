using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PodaciApp.Dtos;
using PodaciApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PodaciApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodaciController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IReadFilePodaci readFilePodaci;
        private readonly ISavePodaci savePodaci;

        public PodaciController(IConfiguration iConfig, IReadFilePodaci iReadFilePodaci, ISavePodaci iSavePodaci)
        {
            configuration = iConfig;
            readFilePodaci = iReadFilePodaci;
            savePodaci = iSavePodaci;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string filePath = configuration.GetSection("FilePath").Value;
            IEnumerable<PodatakDto> result = readFilePodaci.ReadData(filePath);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(IEnumerable<PodatakDto> podaci)
        {
            string connectionString = configuration.GetConnectionString("PodaciDb");
            string result = savePodaci.SaveData(connectionString, podaci.Where(x => x.Ispravan));
            return Ok(result);
        }
    }
}
