# Teste DTI

![Preview-Screen](https://github.com/RafaelCunhafs/Teste_DTI/blob/master/Preview.png)

## About this Project

This project is an simple CRUD API RESTful for client control.

## Features included
- Create client
- Edit Client
- Delete Client
- Delete multiple Clients
- Sort Client table

## Getting Started

### Installing

**Cloning the Repository**

```
$ git clone https://github.com/RafaelCunhafs/Teste_DTI

```

**Installing dependencies**

*   After cloning this project restore his dependencies; "dotnet restore" for .net project & "npm install" for angular project.
*   If you get any errors, consider running manually the steps to build the project and note where the errors occur.
    Open command prompt and do the below steps:  
    1. run 'dotnet restore' from the two project folders - Restore nuget packages
    2. run 'npm install' from the project with package.json - Restore npm packages
    3. Try running the application again - Test to make sure it all works    

## Using the API

### Post

`POST /api/clientes`

### Body Example
```json
{
    "nome": "Nome do cliente",
    "endereco" : "Endereço do cliente",
    "celular" : "Celular do cliente", 
    "email" : "Email do cliente",
    "cpf" : "CPF do cliente"
}
```

### Response Example
```json
{
    "id": "80a40f5b-96b2-4c98-a265-176cdff18442",
    "nome": "Nome do cliente",
    "endereco" : "Endereço do cliente",
    "celular" : "Celular do cliente", 
    "email" : "Email do cliente",
    "cpf" : "CPF do cliente"
}
```

### Get

`GET /api/clientes`

### Response Example
```json
[
    {
        "id": "b3f2ac6e-0645-41b9-8546-ffe7d7659506",
        "nome": "Murilo Matheus Francisco Farias",
        "endereco": "Rua das Acarapé 722, Ricardo de Albuquerque, Rio de Janeiro, RJ",
        "celular": "(21) 99862-4961",
        "email": "murilomatheusfranciscofarias_@numero.com.br",
        "cpf": "479.666.767-90"
    },
    {
        "id": "bf475635-5a57-4959-8a1e-2f48af6fd465",
        "nome": "Regina Maitê Ribeiro",
        "endereco": "Rua Doze 286, Parque das Laranjeiras, Formosa, GO",
        "celular": "(61) 99404-5160",
        "email": "reginamaiteribeiro@andressamelo.com.br",
        "cpf": "043.345.652-39"
    }
]
```

### Get By Id

`GET /api/clientes/{id}`

### Response Example
```json
{
    "id": "bf475635-5a57-4959-8a1e-2f48af6fd465",
    "nome": "Regina Maitê Ribeiro",
    "endereco": "Rua Doze 286, Parque das Laranjeiras, Formosa, GO",
    "celular": "(61) 99404-5160",
    "email": "reginamaiteribeiro@andressamelo.com.br",
    "cpf": "043.345.652-39"
}
```

### Put

`PUT /api/clientes/{id}`

### Body Example
```json
{
    "nome": "Nome do cliente",
    "endereco" : "Endereço do cliente",
    "celular" : "Celular do cliente", 
    "email" : "Email do cliente",
    "cpf": "CPF do cliente"
}
```

### Response Example
```json
{
    "id": "80a40f5b-96b2-4c98-a265-176cdff18442",
	"nome": "Nome do cliente",
	"endereco" : "Endereço do cliente",
	"celular" : "Celular do cliente", 
	"email" : "Email do cliente",
	"cpf" : "CPF do cliente"
}
```

### Delete

`DELETE /api/clientes/{id}`

### Response Example
```json
{
    "id": "097763db-f8f4-4c5a-a785-e01595c2b4e4",
    "nome": "Olivia Cristiane Carvalho",
    "endereco": "Rua das Orquídeas 905, Samarita, São Vicente, SP",
    "celular": "(13) 98719-7190",
    "email": "oliviacristianecarvalho_@smbcontabil.com.br",
    "cpf": "103.149.310-74"
}
```

## Technologies used
- [.NET](https://docs.microsoft.com/en-us/dotnet/core/introduction/) - .Net Core 3.1 form the API RESTful
- [xUnit](https://xunit.net/) - xUnit for testing
- [Angular](https://angular.io/) - Angular +8 for the Front
- [Angular Material](https://material.angular.io/) - Angular Material for useful components
