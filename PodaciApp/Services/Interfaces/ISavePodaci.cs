using PodaciApp.Dtos;
using System.Collections.Generic;

namespace PodaciApp.Services.Interfaces
{
    
    public interface ISavePodaci
    {
        public string SaveData(string connectionString, IEnumerable<PodatakDto> data);
    }
}