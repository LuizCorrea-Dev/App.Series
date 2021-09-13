using System;

namespace APP.Series {
	class Program {
		static SeriesRepository repository= new SeriesRepository();
		static void Main(string[] args)	{
			string userOption = getUserOption();

			while (userOption.ToUpper() != "X")	{
				switch (userOption)	{
					case "1":
						ListSeriess();
						break;
					case "2":
						InsertSeries();
						break;
					case "3":
						UpdateSeriess();
						break;
					case "4":
						DeleteSeries();
						break;
					case "5":
						ViewSeries();
						break;
					case "C":
						Console.Clear();
						break;
					default:
					throw new ArgumentOutOfRangeException();
				}
				userOption = getUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void DeleteSeries()	{
			Console.Write("Digite o id da série: ");
			int indiceSeries = int.Parse(Console.ReadLine());

			repository.Delete(indiceSeries);
		}

		private static void ViewSeries()	{
		Console.Write("Digite o id da série: ");
			int indiceSeries = int.Parse(Console.ReadLine());
			var Series = repository.ReturnById(indiceSeries);

			Console.WriteLine(Series);
	 	}

		private static void UpdateSeriess()	{
			Console.Write("Digite o id da série: ");
			int indiceSeries = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre))) {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entryGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entryTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entryYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entryDescription = Console.ReadLine();

			Series updatesSeries = new Series(
				id: indiceSeries,
				genre: (Genre)entryGenre,
				title: entryTitle,
				year: entryYear,
				description: entryDescription
			);

			repository.Update(indiceSeries, updatesSeries);
		}

		private static void ListSeriess()	{
			Console.WriteLine("Lista de séries");

			var list = repository.List();

			if (list.Count == 0) {
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var Series in list) {
				var Deleted = Series.returnsDeleted();
							
				Console.WriteLine("#ID {0}: - {1} {2}", Series.returnId(), Series.returnsTitle(), (Deleted ? "*Excluído*" : ""));
			}
		}

		private static void InsertSeries()	{
			Console.WriteLine("Insira nova série");

			foreach (int i in Enum.GetValues(typeof(Genre))) {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entryGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entryTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entryYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entryDescription = Console.ReadLine();

			Series newSeries = new Series(
				id: repository.NextId(),
				genre: (Genre)entryGenre,
				title: entryTitle,
				year: entryYear,
				description: entryDescription
			);

			repository.Insert(newSeries);
		}

		private static string getUserOption()	{
			Console.WriteLine();
			Console.WriteLine("APP Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Lista de séries");
			Console.WriteLine("2- Insira nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Deletar série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
	}
}
