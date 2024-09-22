using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;


namespace SERVICES
{
    public class IdiomaSubject
    {
        private static List<IIdiomaObserver> _observers = new List<IIdiomaObserver>();
        private readonly BLL_GestionIdioma _idiomaManager;
        private static Dictionary<string, string> _textosActuales = new Dictionary<string, string>();

            public IdiomaSubject()
            {
                _idiomaManager = new BLL_GestionIdioma();
            }

            public void Attach(IIdiomaObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IIdiomaObserver observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                Console.WriteLine("Notificando a los observadores: " + _observers.Count);
                foreach (var observer in _observers)
                {
                    Console.WriteLine("Notificando a un observador.");
                    observer.UpdateIdioma(_textosActuales);
                }
            }

            public void CambiarIdiomaDesdeDB(string idioma)
            {
                _textosActuales = _idiomaManager.ObtenerTextosPorIdioma(idioma);
                Notify();
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
