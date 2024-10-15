

using MandrilAPI.models;
using MandrilAPI.Models;

namespace MandrilAPI.Services
{
    public class MandrilDataStore
    {
        public List<Mandril> Mandriles { get; set; }

        public static MandrilDataStore Current {get;} = new MandrilDataStore();

        public MandrilDataStore()
         {
            Mandriles = new List<Mandril>
            {
                new Mandril
                {
                    Id = 1,
                    Nombre = "Mandril Uno",
                    Apellido = "Apellido Uno",
                    Habilidades = new List<Habilidad>
                    {
                        new Habilidad { Id = 1, Nombre = "Fuerza", Potencia = Habilidad.EPotencia.Extremo },
                        new Habilidad { Id = 2, Nombre = "Agilidad", Potencia = Habilidad.EPotencia.Moderado }
                    }
                },
                new Mandril
                {
                    Id = 2,
                    Nombre = "Mandril Dos",
                    Apellido = "Apellido Dos",
                    Habilidades = new List<Habilidad>
                    {
                        new Habilidad { Id = 3, Nombre = "Inteligencia", Potencia = Habilidad.EPotencia.RePotente },
                        new Habilidad { Id = 4, Nombre = "Velocidad", Potencia = Habilidad.EPotencia.Suave }
                    }
                },
                new Mandril
                {
                    Id = 3,
                    Nombre = "Mandril Tres",
                    Apellido = "Apellido Tres",
                    Habilidades = new List<Habilidad>
                    {
                        new Habilidad { Id = 5, Nombre = "Resistencia", Potencia = Habilidad.EPotencia.Intenso },
                        new Habilidad { Id = 6, Nombre = "Sigilo", Potencia = Habilidad.EPotencia.Extremo }
                    }
                },
                
            };
        }
    }
}