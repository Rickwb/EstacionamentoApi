using EstacionamentoApi.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstacionamentoApi.Services
{
    public class EstacionamentoService
    {


        private List<Ticket> _tickets;
        private List<Cliente> _clientes;
        private List<Estacionamento> _estacionamentos;
        private List<Ticket> _todosTickectsPagos { get; set; }
        private ClienteService _clienteService;

        public EstacionamentoService(IConfiguration configuration)
        {
            _clientes ??= new List<Cliente>();
            _tickets ??= new List<Ticket>();
            ConfigurationCarro = configuration.GetSection("TabelaPrecosCarro");
            ConfigurationMoto = configuration.GetSection("TabelaPrecosMoto");
            QuantidadeVagas = configuration.GetValue<int>("QuantidadeVagas");
            Estacionamento = new Estacionamento("EstacionamentoLocal","48798542364");

        }
        public Estacionamento Estacionamento { get; set; }
        public int QuantidadeVagas { get; set; }
        public IConfigurationSection ConfigurationCarro { get; set; }
        public IConfigurationSection ConfigurationMoto { get; set; }


        public Cliente CadastrarCliente(Cliente cli)
        {
            
            if (Estacionamento.QtdVagasOcupadas==QuantidadeVagas)
            {
                return null;
            }
            Estacionamento.QtdVagasOcupadas++;
            _clientes.Add(cli);
            _tickets.Add(cli.TicketAtual);
            return cli;
        }
        public List<Cliente> GetAllClientes() => _clientes;

        public Cliente GetCliente(Guid idCliente) => (Cliente)_clientes.SingleOrDefault(c => c.Id == idCliente);

        public bool RemoverCliente(Guid idCliente)
        {
            Estacionamento.QtdVagasOcupadas--;
            return _clientes.Remove(GetCliente(idCliente));
        }

        public Cliente AtualizarCliente(Guid idCliente, Cliente cliente)
        {
            int index = _clientes.IndexOf(GetCliente(idCliente));
            _clientes.Insert(index, cliente);
            return cliente;
        }

        public void RemoverTicket(Guid idTicket)
        {
            var ti = _tickets.SingleOrDefault(t => t.Id == idTicket);
            if (ti.Equals(ti.Cliente.TicketAtual))
            {
                _tickets.Remove(ti);
                _todosTickectsPagos.Add(ti);
                ti.Cliente.TicketAtual = new Ticket(ti.Cliente);
            }
        }

        public decimal CalcularValor(Guid idTicket)
        {
            var ti = _tickets.SingleOrDefault(ticket => ticket.Id == idTicket);
            CalcularTempo(idTicket);
            if (ti.TempoTotal.HasValue)
            {
                if (ti.Cliente.Veiculo is Moto)
                {

                    if (ti.Diaria > 0)
                    {
                        ti.TotalPagar = ti.Diaria < ti.TempoTotal.Value.Days ? ti.TempoTotal.Value.Days * ConfigurationMoto.GetValue<Decimal>("PrecoMotoDiaria") + ti.TempoTotal.Value.Hours * ConfigurationMoto.GetValue<Decimal>("PrecoMotoHora") : ti.TempoTotal.Value.Days * ConfigurationMoto.GetValue<Decimal>("PrecoMotoDiaria");
                    }
                    else
                    {
                        ti.TotalPagar = ti.TempoTotal.Value < TimeSpan.FromMinutes(15) ? ti.TotalPagar = ConfigurationMoto.GetValue<Decimal>("PrecoMotoAte15Minutos") : ti.TotalPagar = ConfigurationMoto.GetValue<Decimal>("PrecoMotoHora") + (ti.TempoTotal.Value.Hours - 1) * ConfigurationCarro.GetValue<Decimal>("PrecoMotoHora"); ;
                    }
                }
                else
                {

                    if (ti.Diaria > 0)
                    {
                        if (ti.Lavacao)
                            ti.TotalPagar = ti.Diaria < ti.TempoTotal.Value.Days ? ti.TempoTotal.Value.Days * ConfigurationCarro.GetValue<Decimal>("PrecoCarroDiariaLavacao") + ti.TempoTotal.Value.Hours * ConfigurationCarro.GetValue<Decimal>("PrecoCarroPorHora") : ti.TempoTotal.Value.Days * 50;
                        else
                            ti.TotalPagar = ti.Diaria < ti.TempoTotal.Value.Days ? ti.TempoTotal.Value.Days * ConfigurationCarro.GetValue<Decimal>("PrecoCarroDiaria") + ti.TempoTotal.Value.Hours * ConfigurationCarro.GetValue<Decimal>("PrecoCarroPorHora") : ti.TempoTotal.Value.Days * ConfigurationCarro.GetValue<Decimal>("PrecoCarroDiaria");
                    }
                    else
                    {
                        ti.TotalPagar = ti.TempoTotal.Value < TimeSpan.FromMinutes(15) ? ti.TotalPagar = ConfigurationCarro.GetValue<Decimal>("PrecoCarroAte15Minutos") : ti.TotalPagar = ConfigurationCarro.GetValue<Decimal>("PrecoCarroPorHora") + (ti.TempoTotal.Value.Hours - 1) * ConfigurationCarro.GetValue<Decimal>("PrecoCarroPorHora"); ;
                    }
                }
            }
            return ti.TotalPagar;

        }
        public void CalcularTempo(Guid IdTicket)
        {

            var ti = _tickets.SingleOrDefault(ti => ti.Id == IdTicket);
            ti.HorarioSaida = DateTime.Now;
            if (!(ti.HorarioSaida > ti.HorarioChegada))
                throw new Exception("O tempo de chegada não esta correto");

            ti.TempoTotal = (TimeSpan)(ti.HorarioChegada - ti.HorarioSaida);

        }
    }
}
