using System;

namespace DIOFLIX
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
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

			Console.WriteLine("Obrigado por utilizar nossos serviços. DIOFLIX agradece!! Até breve ;)");
			Console.ReadLine();
        }

        private static void ExcluirFilme()
		{
            Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
            

			repositorio.Exclui(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var Filme = repositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(Filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string? entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string? entradaDescricao = Console.ReadLine();

			Filmes atualizaFilme = new Filmes(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilme, atualizaFilme);
		}
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar Filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Filme cadastrado. Por favor, cadrastre um filme ;)");
				return;
			}

			foreach (var Filme in lista)
			{
                var excluido = Filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Filme.retornaId(), Filme.retornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo Filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string? entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string? entradaDescricao = Console.ReadLine();

			Filmes novoFilme = new Filmes(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoFilme);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIOFLIX ao seu dispor!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Filmes");
			Console.WriteLine("2- Inserir novo Filme");
			Console.WriteLine("3- Atualizar Filme");
			Console.WriteLine("4- Excluir Filme");
			Console.WriteLine("5- Visualizar Filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}