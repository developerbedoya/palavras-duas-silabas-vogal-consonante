using System.Text.RegularExpressions;

namespace ListaPalavras;
public class DicionarioWeb : IListaPalavras
{
    private IEnumerable<string> _palavras;

    public IEnumerable<string> Palavras { get => _palavras; }

    private DicionarioWeb(IEnumerable<string> palavras) 
    {
        _palavras = palavras;
    }

    public static async Task<DicionarioWeb> Obtem(string codigoLinguagem)
    {
        string baseUrl = "https://raw.githubusercontent.com/";
        string requestUrl = $"LibreOffice/dictionaries/master/{codigoLinguagem}/{codigoLinguagem}.dic";
        
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        string conteudoDicionario = await httpClient.GetStringAsync(requestUrl);
        var regexPalavraDicionario = new Regex("[^/]+", RegexOptions.Compiled);
        
        var listaPalavras = conteudoDicionario.Split('\n')
            .Select(p => regexPalavraDicionario.Matches(p).FirstOrDefault()?.Value ?? "")
            .Where(p => !string.IsNullOrWhiteSpace(p));
        
        return new DicionarioWeb(listaPalavras);
    }

    public DicionarioWeb FiltraPorTamanhoMaximoPalavra(int numeroMaximoLetras)
    {
        _palavras = _palavras.Where(p => p.Length <= numeroMaximoLetras);
        return this;
    }

    public DicionarioWeb FiltraPorDicionario(IListaPalavras dicionario)
    {
        _palavras = _palavras.Where(p => dicionario.Palavras.Contains(p));
        return this;
    }
}