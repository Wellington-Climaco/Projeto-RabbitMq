# Aplicações distribuidas - Rabbitmq | Docker

## 📘 Sobre o Projeto

Esse projeto foi criado para consolidar alguns conceitos de rabbitmq, mass transit e docker. Nele não me apeguei a usar nenhuma arquitetura ou conceitos complexos, o foco foi fazer a comunicação entre dois projetos que não sabem um do outro via rabbitmq e fazer a conteinerização deles 

## ❓ Como executar o projeto

- Certifique-se de que você tenha o Docker instalado em sua máquina.
- Navegue até o diretório raiz do projeto onde o arquivo docker-compose.yml está localizado.
- Execute o seguinte comando para construir as imagens e iniciar os contêineres:

```
docker-compose up --build
```

Esse comando irá fazer a preparação de todo o ambiente.

- Para acessar o RabbitMQ UI, abra seu navegador e entre em  http://localhost:15672. As credenciais padrão são guest/guest.
- Para acessar a API entre em http://localhost:5000

  
- Nesse projeto utilizei o SQL server e para acessar o banco de dados utilize:
```
Hostname: localhost
Porta: 1433
Usuário: sa
Senha: 1q2w3e4r@#$
```
 

