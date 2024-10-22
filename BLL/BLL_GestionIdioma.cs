using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class BLL_GestionIdioma
    {
        private readonly DAL.DAL_GestionIdioma _idiomaRepository;

        public BLL_GestionIdioma()
        {
            _idiomaRepository = new DAL.DAL_GestionIdioma();
        }

        public Dictionary<string, string> ObtenerTextosPorIdioma(string codigoIdioma)
        {
            return _idiomaRepository.GetTextsByLanguage(codigoIdioma);
        }


        public Dictionary<string, string> ObtenerTextosPorId(int idiomaId)
        {
            return _idiomaRepository.GetTextsByLanguageId(idiomaId);
        }

        public int ObtenerIdDesdeIdioma(string codigoIdioma)
        {
            return _idiomaRepository.ObtenerIdDesdeIdioma(codigoIdioma);
        }

        public string ObtenerCodigoDesdeId(int id)
        {
            return _idiomaRepository.ObtenerCodigoDesdeId(id);
        }

        public List<Idioma> ObtenerIdiomas()
        {
            return _idiomaRepository.ObtenerIdiomas();
        }
    }
}
