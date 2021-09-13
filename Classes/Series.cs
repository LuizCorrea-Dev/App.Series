using System;

namespace APP.Series {
  public class Series : EntityBase {
		// Atributos
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
		private bool Deleted {get; set;}

    // Métodos
		public Series(int id, Genre genre, string title, string description, int year) {
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
      this.Deleted = false;
		}

    public override string ToString()	{
			string sReturn = "";
			sReturn += "Gênero: " + this.Genre + Environment.NewLine;
			sReturn += "Título: " + this.Title + Environment.NewLine;
			sReturn += "Descrição: " + this.Description + Environment.NewLine;
			sReturn += "Ano de Início: " + this.Year + Environment.NewLine;
			sReturn += "Deletado: " + this.Deleted;
			return sReturn;
		}

    public string returnsTitle() {
			return this.Title;
		}

		public int returnId()	{
			return this.Id;
		}

    public bool returnsDeleted() {
			return this.Deleted;
		}
    
		public void Delete() {
    	this.Deleted = true;
    }    
	}
}