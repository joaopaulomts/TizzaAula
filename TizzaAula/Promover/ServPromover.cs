﻿namespace TizzaAula
{
    public interface IServPromover
    {
        void Inserir(InserirPromoverDTO inserirDTO);
        List<Promover> Listar();
        Promover BuscarPromover(int id);
        void Efetivar(int id);
    }

    public class ServPromover : IServPromover
    {
        private DataContext _dataContext;
        private IServPizzaria _servPizzaria;

        public ServPromover(DataContext dataContext, IServPizzaria servPizzaria)
        {
            _dataContext = dataContext;
            _servPizzaria = servPizzaria;
        }

        public void Inserir(InserirPromoverDTO inserirDto)
        {
            var promover = new Promover();

            promover.Descricao = inserirDto.Descricao;
            promover.CodigoPizzaria = inserirDto.CodigoPizzaria;
            promover.DataVigencia = inserirDto.DataVigencia;
            promover.Valor = inserirDto.Valor;

            promover.Status = EnumStatusPromover.EmAberto;

            _dataContext.Add(promover);
            _dataContext.SaveChanges();
        }

        public void Efetivar(int id)
        {
            var promover = _dataContext.Promover.Where(p => p.Id == id).FirstOrDefault();

            promover.Status = EnumStatusPromover.Efetivado;

            _servPizzaria.RegistrarPatrocinio(promover.CodigoPizzaria, promover.Valor, promover.DataVigencia);
            _dataContext.SaveChanges();
        }

        public List<Promover> Listar()
        {
            var lista = _dataContext.Promover.ToList();

            return lista;
        }

        public Promover BuscarPromover(int id)
        {
            var promover = _dataContext.Promover.Where(p => p.Id == id).FirstOrDefault();

            return promover;
        }
    }
}
