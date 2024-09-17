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

        public Dictionary<string, string> ObtenerTextosPorIdioma(string languageCode)
        {
            return _idiomaRepository.GetTextsByLanguage(languageCode);
        }


        public Dictionary<string, string> ObtenerTextosPorId(int languageId)
        {
            return _idiomaRepository.GetTextsByLanguageId(languageId);
        }

        public int ObtenerIdDesdeIdioma(string idioma)
        {
            return _idiomaRepository.ObtenerIdDesdeIdioma(idioma);
        }
    }
}
