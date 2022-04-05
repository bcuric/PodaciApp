using PodaciApp.Dtos;
using System.Collections.Generic;

namespace PodaciApp.Services.Interfaces
{
    public interface IReadFilePodaci
    {
        public IEnumerable<PodatakDto> ReadData(string filePath);
    }
}