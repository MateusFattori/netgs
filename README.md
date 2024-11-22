## Integrantes

Bianca Barreto RM:551848

Julia Akemi RM:98032

Pedro Baraldi Sá RM:98060

Mateus Fattori RM:97904

# Importante 

## **Para poder utilizar e testar o codigo tem que usar no Viusal Studio usar a opiço de clonar repositorio**

## **Comando git clone**

```
git clone https://github.com/MateusFattori/netgs.git
```


# netgs - API de Dicas de Economia de Energia

## Descrição

A **API de Dicas de Economia de Energia** oferece um conjunto de dicas úteis para ajudar os usuários a economizarem energia em diferentes contextos. A API está estruturada para fornecer dicas simples e práticas para a economia de energia, organizadas por categorias, como "Residencial" e "Comercial". A API permite o acesso a essas dicas, além de realizar a criação de novas categorias e novas dicas para uma gestão mais eficiente.

A API utiliza o **MongoDB** para persistência de dados, e **Swagger** para documentação automática da API. Além disso, a aplicação está equipada com **testes automatizados** para garantir que todos os endpoints e lógicas de negócios funcionem conforme esperado.

---

## Tecnologias Usadas

- **.NET 8**: Framework para o desenvolvimento da API.
- **MongoDB**: Banco de dados NoSQL utilizado para armazenar as dicas e categorias.
- **Swashbuckle.AspNetCore**: Usado para gerar a documentação da API no Swagger.
- **xUnit**: Framework de testes automatizados utilizado para cobrir as funcionalidades da API.

---

## Como Rodar o Projeto no Visual Studio

### **Pré-requisitos**

1. **Instalar o .NET 8 SDK**:
   - Certifique-se de ter o **.NET 8 SDK** instalado. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Instalar o MongoDB**:
   - A API utiliza o **MongoDB** para persistência de dados. Você pode instalar o MongoDB localmente ou usar uma instância na nuvem, como o **MongoDB Atlas**.
   - Para instalação local, siga as instruções do MongoDB [aqui](https://www.mongodb.com/try/download/community).
   - Se preferir utilizar o **MongoDB Atlas** (na nuvem), siga a documentação no [site oficial](https://www.mongodb.com/cloud/atlas).

3. **Configuração do MongoDB no `appsettings.json`**:
   - Depois de configurar o MongoDB, abra o arquivo `appsettings.json` e adicione a string de conexão para o MongoDB.

   Exemplo de configuração:

   ```json
   {
     "MongoDB": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "EconomiaDeEnergia"
     },
     "AllowedHosts": "*"
   }

## Passos para Executar a Aplicação no Visual Studio
1. Clone o Repositório: Abra o Visual Studio e, em seguida, clone o repositório com o seguinte comando:

bash
Copiar código
git clone https://github.com/seu-usuario/netgs.git
2. **Abra o Projeto no Visual Studio**:

- No Visual Studio, clique em File > Open > Project/Solution e abra a pasta do projeto que você acabou de clonar.
- O Visual Studio vai carregar o projeto automaticamente.
3. **Restaurar as Dependências**:

- O Visual Studio irá restaurar as dependências automaticamente quando você abrir o projeto, mas caso não aconteça, você pode forçar a restauração das dependências clicando em Tools > NuGet Package Manager > Restore NuGet Packages.
3. **Executar a API**:

- No Visual Studio, clique no botão Run ou pressione F5 para iniciar a aplicação. A API estará disponível em https://localhost:5001 ou outra porta configurada automaticamente.
- Você pode verificar no Swagger a documentação da API acessando o endpoint https://localhost:5001/swagger.

## Como Rodar os Testes

### Passos para Executar os Testes Automatizados

1. **Abra o projeto netgs.Tests no Visual Studio.**

2. **No Visual Studio, vá até a barra de ferramentas e clique em Test > Run All Tests para rodar todos os testes automatizados.**

3. **Você também pode rodar os testes diretamente pelo terminal com o comando**:
```
bash
Copiar código
dotnet test
```

O Visual Studio mostrará os resultados dos testes na janela Test Explorer.

**Observação**: Certifique-se de que o MongoDB está rodando e a API está conectada corretamente, para que os testes de integração funcionem.

