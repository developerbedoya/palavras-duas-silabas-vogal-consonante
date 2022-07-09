using ListaPalavras;

var vogais = new char[] { 'a', 'e', 'i', 'o', 'u' };
var consonantes = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 
    'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};

var listaPalavrasDuasSilabas = PermutacaoSilabas.Cria(vogais, consonantes);

var listaPalavrasPTBR = (await DicionarioWeb.Obtem("pt_BR"))
    .FiltraPorTamanhoMaximoPalavra(4)
    .FiltraPorDicionario(listaPalavrasDuasSilabas);

// See https://aka.ms/new-console-template for more information
listaPalavrasPTBR.Palavras.AsParallel().ForAll(Console.WriteLine);
