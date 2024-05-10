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
4. Crie a migration inicial:
   ```
   cd TrybeHotel && dotnet ef migrations add InitialCreate
   ```
5. Atualize o banco de dados:
   ```
   dotnet ef database update
   ```   
6.  Inicie a aplicação:
   ```
   cd TrybeHotel && dotnet start
   ```

## 🧪 Testes
Em construção 👷‍♂️

## 🗺️ Funcionalidades
1. Cadastro de usuário através do endpoint ```POST /user```.
   - O corpo da requisição deverá ser no seguinte formato:
     ```
     {
   	 "Name":"Rebeca",
   	 "Email": "rebeca.santos@trybehotel.com",
   	 "Password": "123456"
     }
      ```
2. Login de um usuário cadastrado através do endpoint ```POST /login```.
   - O corpo da requisição deverá ser no seguinte formato:
     ```
     {
   	 "Email": "rebeca.santos@trybehotel.com",
   	 "Password": "123456"
     }
      ```
3. Endpoint ```/city``` para as cidades
   - ```GET /city``` para listar as cidades cadastradas.
   - ```POST /city``` para cadastrar uma cidade.
      - O corpo da requisição deverá ter o seguinte formato:
        ```
         {
      	"Name": "Rio de Janeiro",
      	"State": "RJ"
         }
        ```
   - ```PUT /city``` para atualizar uma cidade.
      - O corpo da requisição deverá ter o seguinte formato:
        ```
         {
         "CityId": 1
      	"Name": "Rio de Janeiro",
      	"State": "RJ"
         }
        ```
   
4. Endpoint ```/hotel``` para os hotéis
   - ```GET /hotel``` para listar os hotéis cadastrados.
   - ```POST /hotel``` para cadastrar um hotel.
      - O corpo da requisição deverá ter o seguinte formato:
        ```
         {
      	"Name":"Trybe Hotel RJ",
      	"Address":"Avenida Atlântica, 1400",
      	"CityId": 2
         }
        ```
   - ```PUT /hotel``` para atualizar um hotel.
      - O corpo da requisição deverá ter o seguinte formato:
        ```
         {
         "Name":"Trybe Hotel RJ",
         "Address":"Avenida Atlântica, 1400",
         "CityId": 2
         }
        ```

5. Endpoint ```/room``` para os quartos
     - ```POST /room``` para criar um quarto.
       - O corpo da requisição deverá seguir o seguinte formato:
         ```
         {
         	"Name":"Suite básica",
         	"Capacity":2,
         	"Image":"image suite",
         	"HotelId": 1
         }
         ```
      - ```GET /room/:hotelid``` para listar os quartos de um determinado hotel.
      - ```DELETE /room/:roomId``` para deletar um determinado quarto.
  
6. Endpoint ```/booking``` para as reservas
      - ```GET /booking/:id``` para listar uma reserva.
      - ```POST /booking``` para criar uma reserva;
        - O corpo da requisição deverá seguir o seguinte formato:
         ```
         {
      	"CheckIn":"2030-08-27",
      	"CheckOut":"2030-08-28",
      	"GuestQuant":"1",
      	"RoomId":1
         }
         ```
7. Endpoint ```GET /geo/status``` para conferir o status da API externa responsável pela geolocalização.
8. Endpoint ```GET /geo/address``` para trazer os hoteis ordenados por distância de um endereço.
   - O corpo da requisição deverá ter o seguinte padrão:
     ```
     {
        "Address":"Rua Arnaldo Barreto",
          "City":"Campinas",
          "State":"SP"
      }
     ```
