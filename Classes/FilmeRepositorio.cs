using System;
using System.Collections.Generic;
using DIOFLIX.Interfaces;
namespace DIOFLIX
{
    public class FilmeRepositorio : IRepositorio<Filmes>
	{
        private List<Filmes> listaFilme = new List<Filmes>();
		public void Atualiza(int id, Filmes objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilme[id].Excluir();
		}

		public void Insere(Filmes objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filmes> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filmes RetornaPorId(int id)
		{
			return listaFilme[id];
		}
	}
}