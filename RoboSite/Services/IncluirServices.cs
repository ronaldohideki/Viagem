using ApiSite.Models;
using RoboSite.Dados;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoboSite.Services
{
    class IncluirServices
    {
        private DadosPagina _dadosPagina;

        public IncluirServices(DadosPagina dadosPagina)
        {
            _dadosPagina = dadosPagina;
        }
        public void IncluirNoBanco()
        {
            using (var contexto = new ApplicationDbContext())
            {
                var dadosPaginaServices = new DadosPaginaServices(contexto);           
                dadosPaginaServices.Salvar(_dadosPagina);                
            }
        }

        public void IncluirNoArquivo()
        {
            var arquivo = "C:\\Projetos\\teste.csv";

            FileInfo arq = new FileInfo(arquivo);
            
            if (! arq.Exists)
            {
                using (StreamWriter tw = new StreamWriter(arquivo, false, Encoding.Default))
                {                                        
                    tw.WriteLine("Ip;NomePagina;Navegador");                    
                    tw.Close();
                }
            }

            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    sb.AppendLine(s);
                }
                sr.Close();
            }

            var dados = _dadosPagina.Ip + ";" + _dadosPagina.NomePagina + ";" + _dadosPagina.Navegador;
            sb.AppendLine(dados);

            using (StreamWriter tw = new StreamWriter(arquivo, false, Encoding.Default))
            {
                tw.Write(sb);
                tw.Close();
            }
            
        }

    }
}
