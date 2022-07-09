namespace ListaPalavras;

using System.Collections.Generic;

public class PermutacaoSilabas : IListaPalavras
{
    private IEnumerable<string> _palavras;

    public IEnumerable<string> Palavras { get => _palavras; }

    private PermutacaoSilabas(IEnumerable<string> palavras)
    {
        _palavras = palavras;
    }

    public static PermutacaoSilabas Cria(IEnumerable<char> listaVogais, IEnumerable<char> listaConsonantes)
    {
        var combinacoesSilabicas = new List<string>();
        var combinacoesPalavras = new List<string>();

        foreach (var vogal in listaVogais)
        {
            foreach (var consonante in listaConsonantes)
            {
                combinacoesSilabicas.Add($"{consonante}{vogal}");
            }
        }

        foreach (var primeiraSilaba in combinacoesSilabicas) 
        {
            foreach (var segundaSilaba in combinacoesSilabicas) 
            {
                combinacoesPalavras.Add($"{primeiraSilaba}{segundaSilaba}");
            }
        }

        return new PermutacaoSilabas(combinacoesPalavras);
    }
}