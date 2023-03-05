using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace teste.CaixaEletronico.Data
{
    public class CaixaDataContext : DbContext
    {
        private readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());
        public DbSet<Caixa> Caixa { get; set; }
    }
}