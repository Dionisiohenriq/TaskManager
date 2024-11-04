# TaskManager


## Para rodar o projeto:

->Instale o Docker para sua versão de S.O.

->Após instalado, rodar o comando dentro da pasta do projeto ( onde estiver o docker-compose.yml )
  <br/>--> docker compose --project-name taskmanager up -d
  <br/>--> a Api irá rodar no endereço: http://localhost:8080/swagger

-> A aplicação ainda precisa de ajustes, mas já roda com a API (backend) e banco de dados SQLServer. 

-> A arquitetura foi baseada em SOLID e CleanCode, para servir como avaliação de repertório.

-> A aplicação foi dockerizada para facilitar a execução e visualização da api em funcionamneto.

-> O banco de dados pode ser vizualizado com as credenciais : "host: localhost:1433; user: sa; password: strong(!)Password" - A partir de qualquer SGBD (exemplo: DBeaver, SQLManagementStudio, AzureData, etc.).


