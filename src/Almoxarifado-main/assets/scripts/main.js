
const buttonClick = document.getElementById("btnGravar")

buttonClick.addEventListener("click", function(){
    console.log("Clicou em gravar");
    const objIdDep = document.getElementById("idDepartamento");
    const objNomeDep = document.getElementById("departamento");
    const objData = document.getElementById("dataRequisicao");
    
    const campos = document.querySelectorAll('[data-obrigatorio="true"]')

    let temCampoVazio = false;

    campos.forEach(function(itemElemento){
        console.log(itemElemento.value)

        if (itemElemento.value == "") {
            itemElemento.style.backgroundColor="red";
            temCampoVazio = true;
        } else{
            itemElemento.style.backgroundColor="white";

        }
    })

    if (temCampoVazio) {
        return;
    }

    console.log("final do gravar");


})

function adicionarCorFundoAofocar(){
    const inputs = document.querySelectorAll('input,select')
   
    inputs.forEach(function (itemElemento){
        itemElemento.addEventListener('focus', function(){
            itemElemento.style.backgroundColor="green";
            itemElemento.style.color="white"
        })

        itemElemento.addEventListener('blur', function(){
            itemElemento.style.backgroundColor="white";
            itemElemento.style.color="black"
        })
    })
}

function adicionartCampoAceitarSomenteInteiro(){
    const campos = document.querySelectorAll('[data-soInteiroPositivo="true"]')
    campos.forEach(function(item){

        const teclasAceitas = [48,49,50,51,52,53,54,55,56,57,96,97,98,99,100,101,102,103,104,105]
        item.addEventListener('keyup', function(e){
            if (!teclasAceitas.includes(e.keyCode)) {
                item.value="";
            }
        })
    })
}

function carregarCategoria(){
    const elementCategoria = document.getElementById("categoriaMotivo");
    categorias.forEach(function (objCat){
        let opt = document.createElement('option')
        opt.text = objCat.Descricao;
        opt.value = objCat.idCategoria;
        elementCategoria.appendChild(opt);
    })
}

function carregarMotivoAoAlterarCategoria(){
    const elementCategoria = document.getElementById("categoriaMotivo");

    elementCategoria.addEventListener("change", function(){
        let valorEscolhido = elementCategoria.value;
        const motivosFiltrados = motivos.filter((obj)=> obj.idCategoria==valorEscolhido)

        const elementMotivo = document.getElementById("Motivo");
        elementMotivo.innerHTML = "";
        motivosFiltrados.forEach(function(item){
            let opt = document.createElement('option');
            opt.text = item.Descricao;
            opt.value = item.idMotivo;
            elementMotivo.appendChild(opt);
        })
    })
}

function carregarNomeDepartamentoAoAlterarIDDep(){
    const elementIdDep = document.getElementById("idDepartamento")
    elementIdDep.addEventListener("keyup", function(){
        const valorPesquisar = elementIdDep.value
        const departamentoEncontrado = departamentos.find((dep) => dep.Codigo==valorPesquisar)

        if (departamentoEncontrado!=undefined) {
            document.getElementById("departamento").value=departamentoEncontrado.Descricao;
        }else{
            document.getElementById("departamento").value="";
        }
    })
}


function carregarNomeFuncionarioAoAlterarIDDep(){
    const elementIdFun = document.getElementById("idFuncionario")
    elementIdFun.addEventListener("keyup", function(){
        const valorPesquisar = elementIdFun.value
        const funcionarioEncontrado = funcionarios.find((dep) => dep.idFunc==valorPesquisar)
        console.log(funcionarioEncontrado)
        if (funcionarioEncontrado!=undefined) {
            document.getElementById("NomeFuncionario").value=funcionarioEncontrado.Responsavel;
            document.getElementById("cargo").value=funcionarioEncontrado.idCargo;

        }else{
            document.getElementById("NomeFuncionario").value="";
            document.getElementById("cargo").value="";

        }
    })
}



function carregarProdutosPorID(){
    const elementIdProd = document.getElementById("CodigoProduto");
    elementIdProd.addEventListener("keyup", function(){
        const valorPesquisar = elementIdProd.value;
        const produtoEncontrado = produtos.find((obj)=>obj.idProduto==valorPesquisar);

        if (produtoEncontrado!=undefined) {
            document.getElementById("DescricaoProduto").value=produtoEncontrado.Descricao;
            produtoEncontrado.Descricao;
            document.getElementById("Estoque").value=produtoEncontrado.Estoque;
            
            let cor = verificarRegraPercentualEstoqueMinimo(produtoEncontrado);
            const elementoImg = document.getElementById("imgStatus");
            console.log(elementoImg)
            if (cor=="verde") {
                elementoImg.src="/assets/img/Verde1.png"
            } else if (cor=="vermelho") {
                elementoImg.src="/assets/img/Vemelho.png"
            } else {
                elementoImg.src="/assets/img/Amarelo.png"
            }

        } else{
            const elementoImg = document.getElementById("imgStatus");
            document.getElementById("DescricaoProduto").value="";
            document.getElementById("Estoque").value="";
            elementoImg.src="/assets/img/Branco.png";
        }
        
    })
}


function verificarRegraPercentualEstoqueMinimo(pProduto){
    let vPerc10 = Math.round(pProduto.EstoqueMinimo*10/100) + pProduto.EstoqueMinimo

    if (pProduto.Estoque>vPerc10) {
        return "verde";
    } else if (pProduto.Estoque<pProduto.EstoqueMinimo) {
        return "vermelho";
    } else {
        return "amarelo";
    }
}

document.getElementById("BtnInserirItens").addEventListener('click', function(){

    const tabelaItens = document.getElementById("tabelaItens")

    let codigoProduto = document.getElementById("CodigoProduto").value;
    let quantidade = document.getElementById("Quantidade").value;

    const produtoEncontrado = produtos.find((obj) => obj.idProduto==codigoProduto);

    const linha = document.createElement("tr");

    const tdCodigo = document.createElement("td");
    const tdDescricao = document.createElement("td");
    const tdQuantidade = document.createElement("td");
    const tdUnidade = document.createElement("td");
    const tdPreco = document.createElement("td");
    const tdTotal = document.createElement("td");

    tdCodigo.innerHTML = codigoProduto;
    tdDescricao.innerHTML = produtoEncontrado.Descricao;
    tdQuantidade.innerHTML = quantidade;
    tdUnidade.innerHTML = produtoEncontrado.Unidade;
    tdPreco.innerHTML = "R$" + (produtoEncontrado.Preco).toFixed(2);
    tdTotal.innerHTML = "R$" + (produtoEncontrado.Preco*quantidade).toFixed(2);

    linha.appendChild(tdCodigo);
    linha.appendChild(tdDescricao);
    linha.appendChild(tdQuantidade);
    linha.appendChild(tdUnidade);
    linha.appendChild(tdPreco);
    linha.appendChild(tdTotal);

    tabelaItens.appendChild(linha);
})

carregarProdutosPorID();
carregarCategoria();
adicionarCorFundoAofocar();
adicionartCampoAceitarSomenteInteiro();
carregarMotivoAoAlterarCategoria();
carregarNomeDepartamentoAoAlterarIDDep();
carregarNomeFuncionarioAoAlterarIDDep();