using PodaciApp.Dtos;
using PodaciApp.Services.Interfaces;
using System.Collections.Generic;

namespace PodaciApp.Services
{
    public class ReadFilePodaci : IReadFilePodaci
    {
        public IEnumerable<PodatakDto> ReadData(string filePath)
        {
            List<PodatakDto> result = new List<PodatakDto>();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] cols = line.Split(";");
                PodatakDto podatakDto = new PodatakDto();
                podatakDto.Ime = cols[0];
                podatakDto.Prezime = cols[1];
                podatakDto.PostanskiBroj = cols[2];
                podatakDto.Grad = cols[3];
                podatakDto.Telefon = cols[4];
                podatakDto.Ispravan = int.TryParse(podatakDto.PostanskiBroj, out int a);
                result.Add(podatakDto);
            }

            return result;
        }
    }
}