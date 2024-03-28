﻿using SQLite;

namespace AppMauiListaCompras.Models
{
    public class Produto
    {

        string _descricao;
        double _quantidade;
        double _preco;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                    throw new Exception("Descr~ição inválida.");
                _descricao = value;
            }
        }

        
        public double Preco
        {
            get
            {
                return _preco;
            }
            set
            {
                if (!double.TryParse(value.ToString(), out _preco))
                    _preco = 0.0;

                if (value == 0)
                    throw new Exception("Preço inválido");

                _preco = value;
            }
        }

        public double Quantidade
        {
            get
            {
                return _quantidade;
            }
            set
            {
                if (!double.TryParse(value.ToString(), out _quantidade))
                    _quantidade = 0.0;

                if (value == 0)
                    throw new Exception("Quantidade inválida.");
                _quantidade = value;
            }
        }




        public double Total {get => Quantidade * Preco; }
    }
}
