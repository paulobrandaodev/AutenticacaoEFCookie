﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutenticacaoEFCookie.Dados;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutenticacaoEFCookie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ambiente = BuildWebHost(args);
            using(var escopo = ambiente.Services.CreateScope()){
                var servico = escopo.ServiceProvider;
                try{
                    var contexto = servico.GetRequiredService<AutenticacaoContexto>();
                    CodeFirstBanco.Inicializar(contexto);
                }catch(System.Exception ex){
                    var saida = servico.GetRequiredService<ILogger<Program>>();
                    saida.LogError(ex.Message, "Erro ao criar o banco");
                }
            }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
