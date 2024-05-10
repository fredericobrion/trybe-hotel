# Trybe Hotel

## 📝 Descrição:
Uma API RESTful para uma rede de hotéis. É possível cadastrar cidades, hotéis, quartos e reservas. A API possui rotas autenticadas para maior segurança da aplicação. Além disso é possível encontrar os hotéis mais pertos a partir de um endereço buscado.

## 💻 Tecnologias utilizadas:
- <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">C#</a>
- <a href="https://learn.microsoft.com/pt-br/ef/" target="_blank">Entity Framework</a>
- <a href="https://www.microsoft.com/pt-br/sql-server" target="_blank">SQL Server</a>
- <a href="https://dotnet.microsoft.com/en-us/apps/aspnet" target="_blank">ASP.NET Core</a>

## ⚙️ Iniciando a aplicação:
1. Clone o repositório e acesse o diretório da aplicação:
   ```
   git clone git@github.com:fredericobrion/trybe-hotel.git && cd trybe-hotel
   ```
2. Certifique-se de ter um servidor SQL Server ativo. Se não tiver, você pode iniciar um utilizando Docker com o comando:
   ```
   docker-compose up -d --build
   ```
3. Restaure as dependências do projeto:
   ```
   cd src && dotnet restore
   ```
4.  Inicie a aplicação:
   ```
   cd TrybeHotel && dotnet start
   ```

## 🧪 Testes
Em construção 👷‍♂️

