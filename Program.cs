namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilme();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado, e volte sempre!");
            Console.WriteLine("Aperte Enter para sair...");
            Console.ReadLine();

            static void ExcluirFilme()
            {
                // SerieRepositorio repositorio = new SerieRepositorio();

                Console.Write("Digite o ID do filme: ");

                int indiceFilme = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceFilme);
            }

            static void VisualizarFilme()
            {
                // SerieRepositorio repositorio = new SerieRepositorio();

                Console.Write("Digite o ID do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceFilme);

                Console.WriteLine(serie);
            }

            static void AtualizarFilme()
            {
                // SerieRepositorio repositorio = new SerieRepositorio();

                Console.WriteLine("Digite o id da filme...");
                int indiceFilme = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Genero: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Titulo: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Ano: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Descricao: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceFilme,
                                                                 genero: (Genero)entradaGenero,
                                                                titulo: entradaTitulo,
                                                                ano: entradaAno,
                                                                descricao: entradaDescricao);

                repositorio.Atualiza(indiceFilme, atualizaSerie);
            }

            static void ListarFilme()
            {
                // SerieRepositorio repositorio = new SerieRepositorio();

                Console.WriteLine("Listando series...");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma serie cadastrada.");
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();

                    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "Excluido" : "Ativo"));
                }
            }

            static void InserirFilme()
            {
                // SerieRepositorio repositorio = new SerieRepositorio();

                Console.WriteLine("Inserindo filme...");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Genero: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Titulo: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Ano: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Descricao: ");
                string entradaDescricao = Console.ReadLine();

                Serie novoFilme = new Serie(id: repositorio.ProximoId(),
                                                                 genero: (Genero)entradaGenero,
                                                                titulo: entradaTitulo,
                                                                ano: entradaAno,
                                                                descricao: entradaDescricao);
                repositorio.Insere(novoFilme);
            }

            static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo à DIO Filmes!");
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("1 - Listar filmes");
                Console.WriteLine("2 - Inserir novo filme");
                Console.WriteLine("3 - Atualizar filme da galeria");
                Console.WriteLine("4 - Excluir filmes da galeria");
                Console.WriteLine("5 - Visualizar dados filme");
                Console.WriteLine("C - Limpar lista filmes");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }
    }
}
