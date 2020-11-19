using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClientes.App.Migrations
{
    public partial class PopularBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insere na tabela cliente
            migrationBuilder.Sql("insert into cliente (CreatedAt, updatedAt, Nome, CPF, Nascimento) values (getdate(), getdate(), 'Daniel Magalhaes', '687.662.260-66', '1980-10-31')");
            migrationBuilder.Sql("insert into cliente (CreatedAt, updatedAt, Nome, CPF, Nascimento) values (getdate(), getdate(), 'Rafael Jones', '829.101.770-09', '1983-07-29')");

            // Insere na tabela endereço
            migrationBuilder.Sql("insert into endereco (CreatedAt, updatedAt, Logradouro, Bairro, Cidade, Estado, clienteId) values (getdate(), getdate(), 'Rua Afonso 76', 'Rio dos lagos', 'Rio Claro', 'Minas Gerais', (select top 1 Id from cliente where nome like 'Daniel%'))");
            migrationBuilder.Sql("insert into endereco (CreatedAt, updatedAt, Logradouro, Bairro, Cidade, Estado, clienteId) values (getdate(), getdate(), 'Rua Donaldino Silva 123', 'Cascais', 'Tamoio', 'São Paulo', (select top 1 Id from cliente where nome like 'Daniel%'))");
            migrationBuilder.Sql("insert into endereco (CreatedAt, updatedAt, Logradouro, Bairro, Cidade, Estado, clienteId) values (getdate(), getdate(), 'Rua 13 número 7', 'Chacara', 'Rio Bonito', 'Rio de Janeiro', (select top 1 Id from cliente where nome like 'Rafael%'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from endereco");
            migrationBuilder.Sql("delete from cliente");
        }
    }
}
