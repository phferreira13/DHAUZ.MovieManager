# DHAUZ.MovieManager

Desafio para área de Desenvolvimento – Back-End

API para gerenciar filmes assistidos, utilizando como fonte externa para carregar as informações dos filmes o OMDB.

O Caminho da API do OMDB deve ser configurado no Appsettings.json.

Atualmente utilizando MySQL como banco de dados.

## ROTAS
### (GET) api/Movie 
Irá listar todos os filmes cadastrados na base de dados.
  - Retorno:
 ```
 [
  {
    "id": 0,
    "idIMDB": "string",
    "name": "string",
    "description": "string",
    "releaseDate": "string",
    "genre": "string",
    "watched": true,
    "userScore": 0,
    "inserted": "2022-07-26T01:53:26.087Z",
    "updated": "2022-07-26T01:53:26.087Z"
  }
]
```

### (POST) api/Movie 
Irá inserir um novo registro na base. O sistema irá carregar todas as informações do filme com base no Id IMDB enviado na requisição:
- Solicitação:
  
```
  {
    "idIMDB": "string",
    "userScore": 0,
    "watched": true
  }
  
```

- Retorno:
```
{
  "id": 0,
  "idIMDB": "string",
  "name": "string",
  "description": "string",
  "releaseDate": "string",
  "genre": "string",
  "watched": true,
  "userScore": 0,
  "inserted": "2022-07-26T02:02:05.601Z",
  "updated": "2022-07-26T02:02:05.601Z"
}
```

### (PUT) api/Movie 
Permite atualizar algumas informações do filme na base, com base no Id enviado na requisição. 
Demais dados não são atualizáveis pois são carregados diretamente da API do OMDB.
- Solicitação:
  
```
{
  "id": 0,
  "watched": true,
  "userScore": 0
}
  
```

- Retorno:
```
{
  "id": 0,
  "idIMDB": "string",
  "name": "string",
  "description": "string",
  "releaseDate": "string",
  "genre": "string",
  "watched": true,
  "userScore": 0,
  "inserted": "2022-07-26T02:06:23.742Z",
  "updated": "2022-07-26T02:06:23.742Z"
}
```

### (DELETE) api/Movie/{id}
Permite remover um registro do banco com base no Id passado como parâmetro.
- Solicitação:
  
```
/api/Movie/{id}
  
```

- Retorno:
```
200 - Removido com sucesso!
```

### (GET) api/Movie/compare-with-imdb/{id}
Permite buscar a avaliação do filme na base de dados e também as avaliações presentes na API do OMDB, com base no parâmetro Id informado.
- Solicitação:
  
```
api/Movie/compare-with-imdb/{id}

```

- Retorno:
```
{
  "idIMDB": "string",
  "name": "string",
  "userScore": 0,
  "imdbRating": "string",
  "ratings": [
    {
      "source": "string",
      "value": "string"
    }
  ]
}
```
