using System;
using GFT.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GFT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string CONNECTION_STRING = "GFTContext";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MigrateDatabase(Configuration.GetConnectionString(CONNECTION_STRING));
            services.AddDbContext<GFTContext>(o => o.UseSqlServer(Configuration.GetConnectionString(CONNECTION_STRING)));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDatabase(string connectionString)
        {
            try
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = @"
                        IF DB_ID('GFTTest') IS NULL
                        BEGIN
	                        CREATE DATABASE [GFTTest];
                        END";
                    command.ExecuteNonQuery();

                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.CommandText = @"
                        USE [GFTTest];

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clientes')
                        BEGIN
	                        CREATE TABLE Clientes (
		                        ClienteId INT PRIMARY KEY NOT NULL IDENTITY (1, 1),
		                        Nome VARCHAR(100) NOT NULL,
		                        Ativo BIT NOT NULL DEFAULT 1,
	                        );
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Produtos')
                        BEGIN
	                        CREATE TABLE Produtos (
		                        ProdutoId INT PRIMARY KEY NOT NULL IDENTITY (1, 1),
		                        Descricao TEXT NOT NULL,
		                        Ativo BIT NOT NULL DEFAULT 1,
	                        )
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pedidos')
                        BEGIN
	                        CREATE TABLE Pedidos (
		                        PedidoId INT PRIMARY KEY NOT NULL IDENTITY (1, 1),
		                        ClienteId INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteId),
		                        ProdutoId INT NOT NULL FOREIGN KEY REFERENCES Produtos(ProdutoId),
		                        Ativo BIT NOT NULL DEFAULT 1,
	                        )
                        END

                        IF (SELECT COUNT(*) FROM Clientes) = 0
                        BEGIN
	                        INSERT INTO Clientes (Nome)
	                        VALUES ('José Silva'), ('Maria Paula'), ('Roberta Souza')
                        END

                        IF (SELECT COUNT(*) FROM Produtos) = 0
                        BEGIN
	                        INSERT INTO Produtos (Descricao)
	                        VALUES ('Cabo USB'), ('Monitor 22'), ('Fonte 9V')
                        END

                        IF (SELECT COUNT(*) FROM Pedidos) = 0
                        BEGIN
	                        INSERT INTO Pedidos (ClienteId, ProdutoId)
	                        VALUES (1,1), (1,2), (2,3), (3,1)
                        END";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //log de erro
                throw;
            }
        }
    }
}
