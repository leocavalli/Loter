using Loter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace teste
{
    class Program
    {
        const int megaSena = 60, lotoFacil = 25, lotoMania = 100, quina = 80;

        static void Main(string[] args)
        {
            var GameDuration = "S";
            int iniRandon = 0, endRandom = 0;

            while (GameDuration != "N")
            {
                int numerator = 0;
                Console.Write("Sessões: ");
                var sessionGames = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jogos: ");
                int gamesQt = Convert.ToInt32(Console.ReadLine()); ;
                int select = 5;
                int gameSelect = 0;

                while (gameSelect == 0)
                {
                    Console.WriteLine("megaSena = 1 --*-- lotoFacil = 2 --*-- lotoMania = 3 --*-- quina = 4\n");
                    Console.Write("Escolha a modalidade: ");
                    select = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\n");

                    if (select == 1)
                    {
                        gameSelect = megaSena;
                        numerator = 6;
                        iniRandon = 1; endRandom = 61;
                    }
                    else if (select == 2)
                    {
                        gameSelect = lotoFacil;
                        numerator = 15;
                        iniRandon = 1; endRandom = 26;
                    }
                    else if (select == 3)
                    {
                        gameSelect = lotoMania;
                        numerator = 50;
                        iniRandon = 0; endRandom = 100;
                    }
                    else if (select == 4)
                    {
                        gameSelect = quina;
                        numerator = 5;
                        iniRandon = 1; endRandom = 81;
                    }
                    else
                    {
                        gameSelect = 0;
                        Console.WriteLine("Digite um numero válido ");
                    }

                }
                if (gameSelect != lotoMania)
                {
                    Console.WriteLine("Escolha a quantidade de dezenas: ");
                    numerator = Convert.ToInt32(Console.ReadLine());
                }
                var arrayDezenas = new List<Dezenas>();
                int n = 1;
                for (int j = 1; j <= gameSelect; j++)
                {
                    Dezenas dezen = new Dezenas(n, 0);
                    arrayDezenas.Add(dezen);
                    n++;
                }

                Jogo arrayBiDir = new Jogo { };
                var listaJogosConcurso = new List<Jogo>();
                int counter = 0;
                string line;
                List<dynamic> listaSorteiosNum = new List<dynamic>();
                var listaSorteios = new List<string>();
                List<int> concurso = new List<int>();
                var loteria = "";

                if (gameSelect == lotoFacil)
                    loteria = "lotofacil";
                else if (gameSelect == megaSena)
                    loteria = "megasena";
                else if (gameSelect == quina)
                    loteria = "quina";
                else
                    loteria = "lotomania";

                #region LEITURA TXT
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\Users\Leona\OneDrive\Documentos\" + loteria + ".txt");

                while ((line = file.ReadLine()) != null)
                {
                    listaSorteios.Add(line);
                    System.Console.WriteLine(counter + " = " + line);
                    arrayBiDir.numeros = line;
                    arrayBiDir.concurso = counter;
                    listaJogosConcurso.Add(arrayBiDir);
                    counter++;
                    arrayBiDir = new Jogo { };
                }
                file.Close();

                foreach (var item in listaSorteios)
                {
                    var resultados = item.Split(',');


                    foreach (var itens in resultados)
                        concurso.Add(Convert.ToInt32(itens));

                    GeraListaSorteios geraListaSorteios = new GeraListaSorteios();
                    geraListaSorteios.ListaSorteio = concurso;
                    geraListaSorteios.Sorteio = counter;
                    listaSorteiosNum.Add(geraListaSorteios);
                    concurso = new List<int>();
                    counter--;
                }

                foreach (var item in listaSorteiosNum)
                {
                    for (int x = 1; x <= gameSelect; x++)
                    {
                        if (x == 100)
                        {
                            if (item.ListaSorteio.Contains(00))
                                arrayDezenas[x - 1].quantidade++;
                        }
                        if (item.ListaSorteio.Contains(x))
                            arrayDezenas[x - 1].quantidade++;
                    }
                }


                int posicao = 1;
                foreach (var print in arrayDezenas.OrderByDescending(x => x.quantidade))
                {
                    Console.WriteLine((posicao < 10) ? "0" + posicao + "º: " + "  Número " + print.dezena + " se repete em  " + print.quantidade + "jogo(s)"
                                     : posicao + "º: " + "  Número " + print.dezena + " se repete em  " + print.quantidade + "jogo(s)");
                    posicao++;
                }
                #endregion

                Console.Write("\n ");
                Console.Write("\n ");
                Console.WriteLine("Sugestões:\n");

                List<int> removeUni = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                List<int> removeDez = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };


                Console.WriteLine("Digite a quantidade teste: ");
                var testeQtd = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");


                while (sessionGames > 0)
                {
                    int vContMenor = 4;
                    int vContMaior = 6;



                    var listSequenciais = new List<int>();
                    var listSequenciais2 = new List<int>();
                    var listasugestao = new List<List<int>>();
                    var sugestao = new List<int>();

                    var seq = new Lotofacil();
                    seq.listaImpares = 0;
                    int numerosSequenciais = 0;
                    int decimaisSequenciais = 0;
                    int contSeq = 0;


                    #region LOTOMANIA
                    if (gameSelect == lotoMania)
                    {
                        List<int> removeUniAux = new List<int> { };
                        List<int> removeDezAux = new List<int> { };
                        List<int> removeNumber = new List<int>();

                        if (removeUni.Count() == 0)
                            removeUni = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        for (int i = 0; i < 2; i++)
                        {
                            Random randNum = new Random();
                            int numero = removeUni[randNum.Next(removeUni.Count)];
                            removeUni.Remove(numero);
                            if (!removeUniAux.Contains(numero))
                                removeUniAux.Add(numero);
                        }

                        if (removeUni.Count() == 0)
                            removeDez = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
                        Random randNumAux = new Random();
                        int numeroAux = removeDez[randNumAux.Next(removeDez.Count)];
                        removeDez.Remove(numeroAux);
                        if (!removeDezAux.Contains(numeroAux))
                            removeDezAux.Add(numeroAux);

                        while (listasugestao.Count() < gamesQt)
                        {
                            GerarSugestao(sugestao, numerator, numerosSequenciais, removeDezAux, removeUniAux, removeNumber);


                            if (!listasugestao.Contains(sugestao) && !VerificarDuplicidade(sugestao, listaSorteiosNum, listaSorteios, testeQtd, numerator))
                            {
                                listasugestao.Add(sugestao);
                            }
                            sugestao = new List<int>();
                        }

                        foreach (var item in listasugestao)
                        {

                            for (int y = 0; y < item.Count(); y++)
                                Console.Write(item[y] + ",");
                            Console.Write("\n\n");
                        }

                        //if (sessionGames == 1) VarrerSorteios(listaSorteiosNum);
                    }
                    #endregion
                    #region LOTOFACIL

                    else if (gameSelect == lotoFacil)
                    {
                        bool validar = false;
                        if (sessionGames == 1)
                        {
                            VarrerSorteiosLotofacil(listaSorteiosNum);
                            //VerificarIgualdadeSorteios(listaSorteiosNum, testeQtd);
                        }

                        int counterListaSugestao = 1;
                        while (listasugestao.Count() < gamesQt)
                        {
                            GerarSugestaoLotofacil(sugestao, numerator, numerosSequenciais);
                            validar = false;

                            contSeq = 0;
                            foreach (var teste in listaSorteiosNum)
                            {
                                for (int i = 1; i < teste.ListaSorteio.Count; i++)
                                {
                                    int num = teste.ListaSorteio[i];
                                    int nextNum = teste.ListaSorteio[i - 1];
                                    if (num != nextNum + 1)
                                        numerosSequenciais = 0;
                                    else
                                        numerosSequenciais++;
                                    if ((numerosSequenciais + 1 > 6) && (!listSequenciais.Contains(contSeq + 1)))
                                        listSequenciais.Add(contSeq + 1);
                                }
                                numerosSequenciais = 0;
                                contSeq++;
                            }

                            if (!listasugestao.Contains(sugestao) && !VerificarDuplicidadeLotoFacil(counterListaSugestao, sugestao, listaSorteiosNum, listaSorteios, testeQtd) && !validar)
                            {
                                listasugestao.Add(sugestao);
                            }
                            sugestao = new List<int>();
                            listSequenciais2 = new List<int>();
                            counterListaSugestao++;
                        }

                        Console.Write("\n");
                        foreach (var item in listasugestao)
                        {

                            for (int y = 0; y < item.Count(); y++)
                            {
                                Console.Write(item[y]);
                                if (y < item.Count() - 1)
                                    Console.Write(",");
                            }
                            Console.Write("\n");
                        }
                    }

                    #endregion
                    #region MEGASENA
                    else if (gameSelect == megaSena)
                    {

                        while (listasugestao.Count() < gamesQt)
                        {
                            while (sugestao.Count < numerator)
                            {
                                Random randNum = new Random();

                                int numero = randNum.Next(iniRandon, endRandom);
                                if (!sugestao.Contains(numero))
                                    sugestao.Add(numero);
                            }
                            sugestao.Sort();

                            VerificarDuplicidadeMega(sugestao, listaSorteiosNum, listaSorteios, testeQtd, numerator);

                            for (int i = 1; i < sugestao.Count; i++)
                            {
                                int num = sugestao[i];
                                int nextNum = sugestao[i - 1];
                                if (num != nextNum + 1)
                                    numerosSequenciais = 0;
                                else
                                    numerosSequenciais++;
                                if ((num / 10) == (nextNum / 10))
                                    decimaisSequenciais++;
                                else
                                    decimaisSequenciais = 0;
                                if ((numerosSequenciais >= 1 || decimaisSequenciais >= 2) && !listSequenciais2.Contains(contSeq))
                                    listSequenciais2.Add(contSeq);
                                contSeq++;
                            }

                            if (!listasugestao.Contains(sugestao))
                            {
                                listasugestao.Add(sugestao);
                            }
                            sugestao = new List<int>();
                            listSequenciais2 = new List<int>();
                        }

                        foreach (var item in listasugestao)
                        {

                            for (int p = 0; p < item.Count(); p++)
                                Console.Write(item[p] + ",");
                            Console.Write("\n\n");
                        }
                    }
                    #endregion
                    #region QUINA
                    else if (gameSelect == quina)
                    {

                        while (listasugestao.Count() < gamesQt)
                        {
                            while (sugestao.Count < numerator)
                            {
                                Random randNum = new Random();

                                int numero = randNum.Next(iniRandon, endRandom);
                                if (!sugestao.Contains(numero))
                                    sugestao.Add(numero);
                            }
                            sugestao.Sort();

                            for (int i = 1; i < sugestao.Count; i++)
                            {
                                int num = sugestao[i];
                                int nextNum = sugestao[i - 1];
                                if (num != nextNum + 1)
                                    numerosSequenciais = 0;
                                else
                                    numerosSequenciais++;
                                if ((num / 10) == (nextNum / 10))
                                    decimaisSequenciais++;
                                else
                                    decimaisSequenciais = 0;
                                if ((numerosSequenciais >= 1 || decimaisSequenciais >= 2) && !listSequenciais2.Contains(contSeq))
                                    listSequenciais2.Add(contSeq);
                                contSeq++;
                            }

                            if (!listasugestao.Contains(sugestao) && VerificarDuplicidade(sugestao, listaSorteiosNum, listaSorteios, testeQtd, numerator))
                            {
                                listasugestao.Add(sugestao);
                            }
                            sugestao = new List<int>();
                            listSequenciais2 = new List<int>();
                        }

                        foreach (var item in listasugestao)
                        {

                            for (int p = 0; p < item.Count(); p++)
                                Console.Write(item[p] + ",");
                            Console.Write("\n\n");
                        }
                    }
                    #endregion

                    Console.Write("\nFim Sugestões \n\n");
                    contSeq = 0;

                    var listaDaLista = new List<List<int>>();

                    sessionGames--;
                }
                Console.ReadLine();
                Console.Clear();
            }
            //fim


        }

        #region Métodos

        static bool VerificarDuplicidadeMega(List<int> sugestao, List<dynamic> listaSorteiosNum, List<string> listaSorteios, int testeQtd, int numerator)
        {
            var listaTeste = new List<ListaSugestao>();
            int counterListaSugestao = 0;
            int contIgual = 0;
            int contIgualTotal = 0;
            var listaSugAux = new List<int>();
            var pares = new Lotofacil();
            var listaPares = new List<Lotofacil>();

            //foreach (var lista in listasugestao)
            //{

            foreach (var listSort in listaSorteiosNum)
            {
                int counterSorteios = 0;
                foreach (var listSort2 in listaSorteiosNum)
                {
                    if (counterListaSugestao != counterSorteios && !VerificaPar(listaPares, counterSorteios, counterListaSugestao))
                    {
                        for (int v = 0; v < numerator; v++)
                        {
                            if (listSort2.Contains(listSort[v]))
                            {
                                listaSugAux.Add(listSort[v]);
                                contIgual++;
                            }
                        }
                        if (contIgual == testeQtd)
                        {
                            //Console.Write("\nSugestão: " + counterListaSugestao + " --*-- igual => " + contIgual + " --*-- " + (counterSorteios) + " --*-- " + listaSorteios[counterSorteios] + "\n");
                            listaPares.Add(new Lotofacil(counterListaSugestao, counterSorteios));
                            //for (int p = 0; p < listaSugAux.Count(); p++)
                            //{
                            //    Console.Write(listaSugAux[p]);
                            //    if (p < listaSugAux.Count - 1)
                            //        Console.Write(",");
                            //}
                            contIgualTotal++;
                        }

                        contIgual = 0;
                        listaSugAux = new List<int>();
                    }
                    counterSorteios++;
                }
                counterListaSugestao++;
            }
            Console.WriteLine("\n" + "-------Total de iguais: " + contIgualTotal + "-------");
            return false;
        }

        private static bool VerificaPar(List<Lotofacil> listaPares, int counterSorteios, int counterListaSugestao)
        {
            var parComp = new Lotofacil(counterSorteios, counterListaSugestao);
            foreach (var par in listaPares)
            {
                if (par.Equals(parComp))
                    return true;
            }
            return false;
        }

        private static bool ValidarSugestao(List<int> sugestao, int vContMenor, int vContMaior)
        {
            int contMenor = 0;
            int contMaior = 0;
            for (int i = 0; i < 15; i++)
            {
                if (sugestao[i] < 10)
                    contMenor++;
                else if (sugestao[i] >= 10 && sugestao[i] <= 19)
                    contMaior++;
            }
            if (contMenor != vContMenor || contMaior != vContMaior)
                return true;
            return false;

        }

        static bool VerificarDuplicidade(List<int> sugestao, List<dynamic> listaSorteiosNum, List<string> listaSorteios, int testeQtd, int numerator)
        {
            var listaTeste = new List<ListaSugestao>();
            int counterListaSugestao = 0;
            int contIgual = 0;
            var listaSugAux = new List<int>();

            //foreach (var lista in listasugestao)
            //{
            int counterSorteios = 0;
            foreach (var listSort in listaSorteiosNum)
            {
                for (int v = 0; v < numerator; v++)
                {
                    if (sugestao.Contains(listSort[v]))
                    {
                        listaSugAux.Add(listSort[v]);
                        contIgual++;
                    }
                }
                if (contIgual >= testeQtd)
                {
                    Console.Write("Sugestão: " + counterListaSugestao + " --*-- igual => " + contIgual + " --*-- " + (counterSorteios) + " --*-- " + listaSorteios[counterSorteios] + "\n");
                    for (int p = 0; p < listaSugAux.Count(); p++)
                        Console.Write(listaSugAux[p] + " , ");
                    Console.Write("\n\n");
                    return true;
                }

                contIgual = 0;
                listaSugAux = new List<int>();
                counterSorteios++;
            }
            counterListaSugestao++;
            //}
            return false;
        }

        static void GerarSugestao(List<int> sugestao, int numerator, int numerosSequenciais, List<int> removeDezAux = null, List<int> removeUniAux = null, List<int> removeNumber = null)
        {
            int inicio = 0;
            if (removeDezAux.Contains(0))
                inicio = 9;

            while (sugestao.Count < numerator)
            {
                Random randNum = new Random();
                int numero = randNum.Next(inicio, 100);
                int unit = numero > 9 ? numero % 10 : numero;

                if (!sugestao.Contains(numero) && !removeDezAux.Contains(numero - numero % 10) && !removeUniAux.Contains(unit) && !removeNumber.Contains(numero))
                    sugestao.Add(numero);

                sugestao.Sort();

                for (int i = 1; i < sugestao.Count; i++)
                {
                    int num = sugestao[i];
                    int nextNum = sugestao[i - 1];
                    if (num != nextNum + 1)
                        numerosSequenciais = 0;
                    else
                        numerosSequenciais++;
                    if (numerosSequenciais > 4)
                    {
                        sugestao.Remove(num);
                        i = 0;
                        numerosSequenciais = 0;
                    }
                }
            }
        }

        #region lotoFacil

        static void VerificarIgualdadeSorteios(List<dynamic> listaSorteiosNum, int testeQtd)
        {
            Console.Write("------- Começo da Lista de Duplicidade ------- \n");
            int counterSorteios = 0;
            List<Dezenas> sorteioPares = new List<Dezenas>();

            foreach (var listSort in listaSorteiosNum)
            {
                var listaSugAux = new List<int>();
                int contIgual = 0;

                foreach (var listSort2 in listaSorteiosNum)
                {
                    if ((listSort.Sorteio != listSort2.Sorteio) &&
                        (!sorteioPares.Contains(new Dezenas { dezena = listSort.Sorteio, quantidade = listSort2.Sorteio })
                        && !sorteioPares.Contains(new Dezenas { dezena = listSort2.Sorteio, quantidade = listSort.Sorteio })))
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            if (listSort2.ListaSorteio.Contains(listSort.ListaSorteio[v]))
                            {
                                listaSugAux.Add(listSort.ListaSorteio[v]);
                                contIgual++;
                            }
                        }
                        if (contIgual >= testeQtd)
                        {
                            var parSorteio = new Dezenas { dezena = listSort.Sorteio, quantidade = listSort2.Sorteio };
                            sorteioPares.Add(parSorteio);
                            //Console.Write("\n");
                            //Console.WriteLine(listSort.Sorteio + " = " + listSort2.Sorteio);
                            //for (int p = 0; p < listaSugAux.Count(); p++)
                            //{
                            //    Console.Write(listaSugAux[p]);
                            //    if (p < listaSugAux.Count() - 1)
                            //        Console.Write(" , ");
                            //}
                            //Console.Write("\n");
                            counterSorteios++;
                        }
                        contIgual = 0;
                        listaSugAux = new List<int>();
                    }
                }
            }
            sorteioPares.OrderBy(p => p.dezena).ToList();
            foreach (var sort in sorteioPares)
                Console.WriteLine("\n " + sort.dezena + " = : " + sort.quantidade);
            Console.WriteLine("\n" + "-------Total de iguais: " + counterSorteios + " -------");
            Console.WriteLine("------- Fim da Lista de Duplicidade ------- \n");
        }

        static bool VerificarDuplicidadeLotoFacil(int counterListaSugestao, List<int> sugestao, List<dynamic> listaSorteiosNum, List<string> listaSorteios, int testeQtd)
        {
            int contIgual = 0;
            var listaSugAux = new List<int>();

            int counterSorteios = 0;
            foreach (var listSort in listaSorteiosNum)
            {
                for (int v = 0; v < 15; v++)
                {
                    if (sugestao.Contains(listSort.ListaSorteio[v]))
                    {
                        listaSugAux.Add(listSort.ListaSorteio[v]);
                        contIgual++;
                    }
                }
                if (contIgual >= testeQtd)
                {
                    Console.Write("Sugestão: " + counterListaSugestao + " --*-- igual => " + contIgual + " --*-- " + (listSort.Sorteio) + " --*-- " + listaSorteios[counterSorteios] + "\n");
                    for (int p = 0; p < listaSugAux.Count(); p++)
                    {
                        Console.Write(listaSugAux[p]);
                        if (p < listaSugAux.Count() - 1)
                            Console.Write(" , ");
                    }
                    Console.Write("\n\n");
                    return true;
                }

                contIgual = 0;
                listaSugAux = new List<int>();
                counterSorteios++;
            }
            return false;
        }

        static void GerarSugestaoLotofacil(List<int> sugestao, int numerator, int numerosSequenciais)
        {
            while (sugestao.Count < numerator)
            {

                Random randNum = new Random();
                int numero = randNum.Next(1, 26);

                if (!sugestao.Contains(numero))
                    sugestao.Add(numero);

                sugestao.Sort();

                //for (int i = 1; i < sugestao.Count; i++)
                //{
                //    int num = sugestao[i];
                //    int nextNum = sugestao[i - 1];
                //    if (num != nextNum + 1)
                //        numerosSequenciais = 0;
                //    else
                //        numerosSequenciais++;
                //    if (numerosSequenciais > 6)
                //    {
                //        sugestao.Remove(num);
                //        i = 0;
                //        numerosSequenciais = 0;
                //    }
                //}
            }
        }

        private static void VarrerSorteiosLotofacil(List<dynamic> listaSorteiosNum)
        {
            var testeDois = new List<dynamic>();
            var testeUm = new TresNumeros();
            GameSelect menorTemp = new GameSelect("MenorTemp", 0);
            GameSelect medioTemp = new GameSelect("MédioTemp", 0);
            GameSelect maiorTemp = new GameSelect("MaiorTemp", 0);
            List<GameSelect> genList = new List<GameSelect>();
            genList.Add(new GameSelect("Menor", 0));
            genList.Add(new GameSelect("Médio", 0));
            genList.Add(new GameSelect("Maior", 0));
            foreach (var listSorte in listaSorteiosNum)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (listSorte.ListaSorteio[i] < 10)
                        menorTemp.qtdDezPadrao++;
                    else if (listSorte.ListaSorteio[i] >= 10 && listSorte.ListaSorteio[i] < 20)
                        medioTemp.qtdDezPadrao++;
                    else if (listSorte.ListaSorteio[i] >= 20)
                        maiorTemp.qtdDezPadrao++;

                    //Console.Write(listSorte.ListaSorteio[i]);
                    //if (i < 14) Console.Write(",");
                }

                //Console.Write(" *-- (Menor: " + menorTemp.qtdDezPadrao + " >= Médio: " + medioTemp.qtdDezPadrao + " >= Maior: " + maiorTemp.qtdDezPadrao + ") --*\n");
                genList[0].qtdDezPadrao += menorTemp.qtdDezPadrao;
                genList[1].qtdDezPadrao += medioTemp.qtdDezPadrao;
                genList[2].qtdDezPadrao += maiorTemp.qtdDezPadrao;


                testeUm.numUm = menorTemp.qtdDezPadrao;
                testeUm.numDois = medioTemp.qtdDezPadrao;
                testeUm.numTres = maiorTemp.qtdDezPadrao;

                menorTemp = new GameSelect("MenorTemp", 0);
                medioTemp = new GameSelect("MédioTemp", 0);
                maiorTemp = new GameSelect("MaiorTemp", 0);

                testeDois.Add(testeUm);
            }

            //Console.WriteLine(genList[0].nomeJogo + " total: " + genList[0].qtdDezPadrao + " _______ " + genList[0].qtdDezPadrao / listaSorteiosNum.Count());
            //Console.WriteLine(genList[1].nomeJogo + " total: " + genList[1].qtdDezPadrao + " _______ " + genList[1].qtdDezPadrao / listaSorteiosNum.Count());
            //Console.WriteLine(genList[2].nomeJogo + " total: " + genList[2].qtdDezPadrao + " _______ " + genList[2].qtdDezPadrao / listaSorteiosNum.Count());
        }
        #endregion
        static void VarrerSorteios(List<dynamic> listaSorteiosNum)
        {
            int Numsorteio = listaSorteiosNum.Count();
            List<Dezenas> removeUniAux = new List<Dezenas>();
            List<Dezenas> removeDezAux = new List<Dezenas>();
            List<TopNumber> topNumber = new List<TopNumber>();

            GerarArray(removeUniAux, removeDezAux, topNumber);

            foreach (var listSorte in listaSorteiosNum)
            {
                bool menor = false;
                List<int> removeUni = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                List<int> removeDez = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
                Console.Write(Numsorteio + " => ");

                for (int i = 0; i < 20; i++)
                {
                    if (listSorte[i] < 10) menor = true;
                    int unit = listSorte[i] > 9 ? listSorte[i] % 10 : listSorte[i];
                    int dez = listSorte[i] > 9 ? (listSorte[i] / 10) * 10 : 0;
                    removeUni.Remove(unit);
                    if (dez > 0)
                        removeDez.Remove(dez);
                    Console.Write(listSorte[i]);
                    if (i < 19) Console.Write(",");
                }

                if (menor) removeDez.Remove(0);

                if (removeUni.Count() <= 0 && removeDez.Count() <= 0) Console.Write(" *--* Sem excessões *--* ");
                else
                {
                    Console.Write(" *--* Não aparece(m) (");

                    if (removeUni.Count > 0)
                    {
                        Console.Write(removeUni.Count() + " Unidade(s): ");
                        for (int i = 0; i < removeUni.Count(); i++)
                        {
                            Console.Write(removeUni[i]);
                            if (i < removeUni.Count() - 1) Console.Write(",");
                            removeUniAux[removeUni[i]].quantidade++;
                        }
                    }


                    if (removeDez.Count > 0)
                    {
                        if (removeUni.Count() > 0) Console.Write(" & ");
                        Console.Write(removeDez.Count() + " Dezena(s): ");
                        for (int i = 0; i < removeDez.Count(); i++)
                        {
                            Console.Write(removeDez[i]);
                            if (i < removeDez.Count() - 1) Console.Write(",");
                            removeDezAux[(removeDez[i] / 10)].quantidade++;
                        }
                    }
                    Console.Write(") [" + removeUni.Count() + "," + removeDez.Count() + "]");
                }

                Dezenas par = new Dezenas();
                par.dezena = removeUni.Count();
                par.quantidade = removeDez.Count();

                for (int p = 0; p < topNumber.Count(); p++)
                {
                    Dezenas aux = topNumber[p].par;
                    if (aux.Equals(par))
                        topNumber[p].repeticao++;
                }

                Console.WriteLine("\n");
                Numsorteio--;
            }

            var vTopNumber = topNumber.OrderByDescending(r => r.repeticao);

            Console.WriteLine("*-- Contagem de combinações --*");
            foreach (var top in vTopNumber)
                Console.WriteLine("[Unidade(s): " + top.par.dezena + " & Dezena(s): " + top.par.quantidade + "]" + " = " + top.repeticao);

            Console.WriteLine();

        }
        private static void GerarArray(List<Dezenas> removeUniAux, List<Dezenas> removeDezAux, List<TopNumber> topNumber)
        {
            Dezenas par = new Dezenas(0, 0);
            for (int x = 0; x < 10; x++)
            {
                Dezenas units = new Dezenas(x, 0);
                removeUniAux.Add(units);
                Dezenas dezen = new Dezenas(x * 10, 0);
                removeDezAux.Add(dezen);
            }

            for (int i = 0; i < 5; i++)
            {
                for (int n = 0; n < 5; n++)
                {
                    par = new Dezenas(i, n);
                    TopNumber topNumb = new TopNumber(par, 0);
                    if (i + n != 0)
                    {
                        if (!topNumber.Contains(topNumb))
                            topNumber.Add(topNumb);
                    }
                }
            }
        }
        #endregion

    }
}

