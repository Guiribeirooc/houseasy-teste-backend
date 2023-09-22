# Cadastro de Usuários - Houseasy

## O que a solução faz?
A Solução é capaz de inserir, editar e excluir o cadastro de usuários.

## Arquitetura do Projeto
A solução foi feita em um projeto de Arquitetura de camadas, em .NET, estruturada de forma simples, separando as responsabilidades por camada.
A aplicação poderá ser executada por completa, backend e frontend, executando os dois projetos em conjunto.
A API está documentada com Swagger.

## Execução do código
Para executar o teste do código, pode ser utilizado:
- O próprio Swagger, inicializando o Projeto HouseasyAPI.
- Projeto completo, executando em conjunto o projeto Houseasy e HouseasyAPI.

Obs: O projeto está com segurança JWT, onde, se for testar via Swagger será necessário obter o token para poder efetuar os testes. O Login e Senha estão localizados no projeto Houseasy, no appsettings.json. Para executar a migração do banco de dados, o projeto que deverá ser utilizado para isso será o HouseasyInfra, utilizando os comandos "add-migration" e "update-database". Não esqueça de trocar a string de conexão para efetuar o update, que está localizado no projeto HouseasyAPI, no appsettings.json

A aplicação está configurada para iniciar na tela Home. Ao clicar em "Usuários, será redirecionado para a view de lista de usuários, onde ao finalizar uma execução, sempre será retornado a esta tela. Nesta tela será possível: cadastrar um novo usuário, alterar os dados do usuário já cadastrado e excluir os dados do mesmo.
        
