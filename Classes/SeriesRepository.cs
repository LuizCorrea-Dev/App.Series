using System;
using System.Collections.Generic;
using APP.Series.Interfaces;

namespace APP.Series {
	public class SeriesRepository : IRepository<Series>	{
    private List<Series> listSeries = new List<Series>();
		
		public void Update(int id, Series obj)	{
			listSeries[id] = obj;
		}

		public void Delete(int id) {
			listSeries[id].Delete();
		}

		public void Insert(Series obj)	{
			listSeries.Add(obj);
		}

		public List<Series> List() {
			return listSeries;
		}

		public int NextId()	{
			return listSeries.Count;
		}

		public Series ReturnById(int id)	{
			return listSeries[id];
		}
	}
}