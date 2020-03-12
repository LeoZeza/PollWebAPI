# PollWebAPI
> PollWebAPI � uma API RESTful, desenvolvida em C#, para retornar dados sobre uma enquete.


## Instala��o dos componentes necess�rios

Ferramentas que utilizei para implementa��o e teste da API:

1. [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15/)

2. [Visual Studio 2017 Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=15/)

3. [Postman](https://www.postman.com/downloads//)

4. [LocalDB](http://download.microsoft.com/download/8/D/D/8DD7BDBA-CEF7-4D8E-8C16-D9F69527F909/ENU/x64/SqlLocalDB.MSI/)


## Restaura��o do banco de dados

- Com o SSMS j� aberto, abrir um servidor local e localize o Pesquisador de Objetos
- Clicar com o direito em Banco De Dados 
- Clicar em Restaurar Banco de Dados...
- Selecionar Dispositivo
- Localizar o backup do banco, que est� na pasta junto com a solu��o
- Realizar o backup

## Executando o projeto no Visual Studio

- Abrir o projeto PollWebApi
- Compilar solu��o
- Executar

## Requisi��es suportadas pela API

GET /poll/:id

```sh
Retorna os dados de uma enquente (id), caso o id n�o exista no banco, o retorno � um 404 Not Found
```

GET /poll/:id/stats

```sh
Retorna as estat�sticas sobre a enquente (id).
```

POST /poll

```sh
Cria uma nova enquete e retorna o id.
```

POST /poll/:id/vote

```sh
Registra um voto para uma op��o da enquete e retorna option_id. Caso ela n�o exista no sistema, o retorno ser� um 404 Not Found.
```

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/ec51f18e4cf298f00327)