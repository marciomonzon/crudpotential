# Cadastro de Desenvolvedores - API e React

- Foi desenvolvido uma API em ASP.NET Core 3.1 com o Swagger de documentação e como Frontend foi utilizado o React JS;
- Foi utilizado o Postgres como banco de dados;
- ***Foram desenvolvidos testes unitários na API***;
- A API está na pasta CrudDesenvolvedores e o SPA está na pasta crud_frontend.

## API

Nesta API foi utilizado o ASP.NET Core 3.1 e nela usei os seguintes conceitos e tecnologias:

- Orientação a Objeto;
- Objeto DTO;
- Model;
- Interface;
- Injeção de Dependência;
- Classe de Serviço;
- Classe Extensions;
- Fabrica de Objeto;
- Entity Framework Core;
- Linq;
- Banco Postgres.

### Métodos da API

- GET http://localhost:59607/developers (obtem todos os desenvolvedores)
- GET http://localhost:59607/developers?page= (usado como paginação)
- GET http://localhost:59607/developers/id (obter por id)
- POST http://localhost:59607/developers (para a inserção)
- PUT http://localhost:59607/developers/id (com o objetono body) para a atualização
- DELETE http://localhost:59607/developers (para a exclusão)

```
ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = QTDE_REGISTROS_POR_PAGINA)
ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = QTDE_REGISTROS_POR_PAGINA)
ObterDesenvolvedorPorId(int id)
InserirDesenvolvedor(DtoDesenvolvedor dto)(int id)
AtualizarDesenvolvedor(int id, Desenvolvedor desenvolvedor)
ExcluirDesenvolvedor(int id)
```

### Dcumentação da API

Foi implementado o Swagger para a documentação da API. Este mostra todos os métodos e os comentários das prorpiedades e métodos.
Para acessar o swagger, informe: http://localhost:59607/swagger/index.html.

Observação importante: O http://localhost:59607 muda conforme o local de execução. Coloquei apenas para ficar mais didático.

### SPA em React

O frontend foi desenvolvido em React JS como uma SPA.
Os seguintes conceitos foram utilizados:

- Navegação;
- Inserção;
- Edição;
- Visualizar;
- Exclusão;

**Observação importante: para alterar o caminho da api, deve acessar o arquivo services/api.ts**

### Testes unitários

Foi utilizado um banco em memória e os Testes deves ser executados individualmente.

- Test_Obter_Desenvolvedores;
- Test_Obter_Por_Id;
- Test_Validar_Insercao_Nome.

### Script da tabela do banco Postgres

```
CREATE TABLE desenvolvedor
(
    desenvolvedorid SERIAL NOT NULL,
    nome character varying(100) NOT NULL,
    sexo character(1) NOT NULL,
    idade integer NOT NULL,
    hobby character varying(100),
    datadenascimento date NOT NULL,
    CONSTRAINT desenvolvedor_pkey PRIMARY KEY (desenvolvedorid)
)
```


