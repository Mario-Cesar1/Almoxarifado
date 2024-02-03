const categorias = [
    {
        "idCategoria": 1,
        "Descricao": "Gestão",
    },
    {
        "idCategoria": 2,
        "Descricao": "Cliente",
    },
    {
        "idCategoria": 3,
        "Descricao": "RP",
    },
]
const motivos=[
    {
        "idMotivo": 1,
        "Descricao": "Planejamento",
        "idCategoria": 1
    },
    {
        "idMotivo": 2,
        "Descricao": "Financeiro",
        "idCategoria": 1
    },
    {
        "idMotivo": 3,
        "Descricao": "Quebra de Máquina",
        "idCategoria": 2
    }
]


const produtos=[
    {
        "idProduto": 1,
        "Descricao": "Papel A4",
        "Estoque": 10,
        "EstoqueMinimo": 5,
        "Preco": 5,
        "Unidade": "Und",
    },
    {
        "idProduto": 2,
        "Descricao": "Mel doce",
        "Estoque": 5,
        "EstoqueMinimo": 5,
        "Preco": 5,
        "Unidade": "Und",
    },
    {
        "idProduto": 3,
        "Descricao": "Memória Ram",
        "Estoque": 3,
        "EstoqueMinimo": 5,
        "Preco": 5,
        "Unidade": "Und",
    }
]



const departamentos=[
    {
        "Codigo": 1,
        "Descricao": "Financeiro" 
    },
    {
        "Codigo": 2,
        "Descricao": "RH" 
    }
]


const funcionarios = [
    {
        idFunc: 1,
        Responsavel: "José",
        idCargo: "Comissionado"
    },
    {
        idFunc: 2,
        Responsavel: "Luiz",
        idCargo: "Gestor"
    },
    {
        idFunc: 3,
        Responsavel: "Maria",
        idCargo: "Gerente"
    }
]