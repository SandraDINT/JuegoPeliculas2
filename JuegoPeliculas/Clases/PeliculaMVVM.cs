using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class PeliculaMVVM : ObservableObject
{
    /*Me he quedado a medias de usar el azureService*/


    private ListaPeliculasService servicioPeliculas;
    private AzureService azureService;
    private List<String> _nivelesDificultad;
    private List<String> _generos;
    public PeliculaMVVM()
    {
        servicioPeliculas = new ListaPeliculasService();
        ContadorPeliculaActual = 1;
        _nivelesDificultad = new List<String> {"Fácil", "Normal", "Difícil" };
        _generos = new List<String> { "Comedia", "Drama", "Acción", "Terror", "Ciencia-Ficción" };
    }

    public List<String> Generos
    {
        get { return _generos; }
        set { SetProperty(ref _generos, value); }
    }
    public List<String> Dificultades 
    { 
        get { return _nivelesDificultad; }
        set {SetProperty(ref _nivelesDificultad, value); } 
    }

    private ObservableCollection<Pelicula> _listaPeliculas;
    public ObservableCollection<Pelicula> Peliculas {
        get { return _listaPeliculas; }
        set { SetProperty(ref _listaPeliculas, value); } 
    }

    private Pelicula _peliculaActual;
    public Pelicula PeliculaActual
    {
        get { return _peliculaActual; }
        set
        {
            SetProperty(ref _peliculaActual, value);
        }
    }

    private int _contadorPeliculaActual;
    public int ContadorPeliculaActual
    {
        get { return _contadorPeliculaActual; }
        set { SetProperty(ref _contadorPeliculaActual, value); }
    }

    private int _totalPeliculas;
    public int TotalPeliculas
    {
        get { return _totalPeliculas; }
        set { SetProperty(ref _totalPeliculas, value); }
    }


    //Métodos
    public void Avanzar()
    {
        if (ContadorPeliculaActual < TotalPeliculas)
        {
            ContadorPeliculaActual++;
            PeliculaActual = _listaPeliculas[ContadorPeliculaActual - 1];
        }

    }
    public void Retroceder()
    {
        if (ContadorPeliculaActual > 1)
        {
            ContadorPeliculaActual--;
            PeliculaActual = _listaPeliculas[ContadorPeliculaActual - 1];
        }
    }
    public void CargarDatos()
    {
        Peliculas = servicioPeliculas.GetPeliculas();
        TotalPeliculas = _listaPeliculas.Count;
    }
    public void ExportarDatos()
    {
        string personasJson = JsonConvert.SerializeObject(Peliculas);
        File.WriteAllText("personas.json", personasJson);
    }

    public void AddPelicula(Pelicula pelicula)
    {
        Peliculas.Add(pelicula);
    }
    public string SubirImagenAzure(string url)
    {

        return "";
    }

}

