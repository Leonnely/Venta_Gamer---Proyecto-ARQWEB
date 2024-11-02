using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVICES
{
    public class IdiomaSubject
    {
        private static readonly List<IIdiomaObserver> _observers = new List<IIdiomaObserver>();
        private static readonly object _lock = new object();
        private readonly BLL_GestionIdioma _idiomaManager;
        private static Dictionary<string, string> _textosActuales = new Dictionary<string, string>();

        // Singleton instance
        private static IdiomaSubject _instance;

        private IdiomaSubject()
        {
            _idiomaManager = new BLL_GestionIdioma();
        }

        // Método para obtener la instancia única de IdiomaSubject
        public static IdiomaSubject Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new IdiomaSubject();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool ContieneObservador(IIdiomaObserver observer)
        {
            return _observers.Contains(observer);
        }
        public void Attach(IIdiomaObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                System.Diagnostics.Debug.WriteLine("Observador registrado correctamente.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("El observador ya estaba registrado.");
            }
        }

        public void Detach(IIdiomaObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            System.Diagnostics.Debug.WriteLine("Notificando a los observadores: " + _observers.Count);

            if (_observers.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No hay observadores registrados.");
                return; // Evitar seguir si no hay observadores
            }

            foreach (var observer in _observers)
            {
                System.Diagnostics.Debug.WriteLine("Notificando a un observador.");
                observer.UpdateIdioma(_textosActuales);
            }
        }

        public void CambiarIdiomaDesdeDB(string idioma)
        {
            System.Diagnostics.Debug.WriteLine("Cambiando idioma a: " + idioma);
            _textosActuales = _idiomaManager.ObtenerTextosPorIdioma(idioma);
            System.Diagnostics.Debug.WriteLine("Textos actuales cargados: " + _textosActuales.Count);

            if (_textosActuales.Count > 0)
            {
                Notify(); // Notifica a los observadores del cambio de idioma
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se encontraron textos para el idioma: " + idioma);
            }
        }

        public void CambiarIdiomaDesdeDB(int id)
        {
            _textosActuales = _idiomaManager.ObtenerTextosPorId(id);
            Notify();
        }

        public int ObtenerIdDesdeIdioma(string idioma)
        {
            return _idiomaManager.ObtenerIdDesdeIdioma(idioma);
        }

        public string ObtenerCodigoDesdeId(int id)
        {
            return _idiomaManager.ObtenerCodigoDesdeId(id);
        }

        // Método estático para obtener texto traducido
        public static string GetTexto(string key)
        {
            return _textosActuales.ContainsKey(key) ? _textosActuales[key] : key;
        }
    }
}

