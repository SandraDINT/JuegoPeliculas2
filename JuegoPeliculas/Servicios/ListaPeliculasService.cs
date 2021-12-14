using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ListaPeliculasService
{
    private const string RUTA_FICHERO_JSON = @"G:\DAM\2DAM\DINT\T5\Proyecto_JuegoPeliculas\recursos\peliculas.json";
    public ObservableCollection<Pelicula> GetPeliculas()
    {
        ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();
        string peliculasJson = File.ReadAllText(RUTA_FICHERO_JSON);
        peliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        return peliculas;
    }
}

